using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using Color = UnityEngine.Color;


public class LaserManager : MonoBehaviour
{
    [SerializeField] private Vector3 origin;
    [SerializeField] private Vector3 direction;
    [SerializeField] public float length = 30f;

    [Range(0,150)] public int nombreRebond = 5;

    public List<Vector3> pointList;
    public LineRenderer lineRenderer;

    private void Start()
    {
        pointList = new ();
    }


    void Update()
    {
        pointList.Clear();
        pointList.Add(transform.position);
        
        RecursiveTirLaser(transform.position, transform.forward, nombreRebond, length);
        
        lineRenderer.positionCount = pointList.Count;
        lineRenderer.SetPositions(pointList.ToArray());
    }

    void RecursiveTirLaser(Vector3 origin, Vector3 direction, int maxBounce, float length)
    {
        RaycastHit raycastHit;
        if (length <= 0)
        {
            Debug.DrawRay(origin, direction*length, Color.red,0f);
        }
        else if (maxBounce == 0)
        {
            Debug.DrawRay(origin, direction*length, Color.red,0f);
        }
        else
        {
            if (Physics.Raycast(origin, direction, out raycastHit, length)) //ne pas faire de boucle for dans une fonction récursive
            {
                Debug.DrawRay(origin, direction * raycastHit.distance, Color.cyan, 0f); 
                Debug.DrawRay(raycastHit.point, raycastHit.normal, Color.magenta, 0f);
                
                Vector3 lastpoint = raycastHit.point;
                length -= raycastHit.distance;
                maxBounce--;
                pointList.Add(lastpoint);
                Debug.Log("coucou");
                RecursiveTirLaser(lastpoint ,Vector3.Reflect(direction, raycastHit.normal), maxBounce, length);
            }
            else
            { 
                Debug.DrawRay(origin, direction*length, Color.red,0f);
                pointList.Add(origin+direction*length);
            }
        }
    }
    
    
    void TirLaser()
    {
        origin = transform.position;
        direction = transform.forward;
        RaycastHit raycastHit;
        
        if (Physics.Raycast(origin, direction, out raycastHit, length)) //out = permet à la fonction d'exploiter le paramètre et le changer
        {
            Debug.DrawRay(origin, direction * raycastHit.distance, Color.cyan,0f); //toujours Debug les raycasts
            Debug.DrawRay(raycastHit.point, raycastHit.normal, Color.magenta,0f);
            Vector3 newDirection1 = Vector3.Reflect(direction, raycastHit.normal);
            if (Physics.Raycast(raycastHit.point, newDirection1, out raycastHit, length))
            {
                Debug.DrawRay(raycastHit.point,newDirection1*-raycastHit.distance,Color.green,0f);
                Debug.DrawRay(raycastHit.point, raycastHit.normal, Color.magenta,0f);
                Vector3 newDirection2 = Vector3.Reflect(newDirection1, raycastHit.normal);
                if (Physics.Raycast(raycastHit.point, newDirection2, out raycastHit, length))
                {
                    Debug.DrawRay(raycastHit.point,newDirection2*-raycastHit.distance,Color.yellow,0f);
                }
            }
            else
            {
                Debug.DrawRay(raycastHit.point, newDirection1*length,Color.red,0f);
            }
        }
        else
        {
            Debug.DrawRay(origin, direction * length, Color.red,0f);
        }
    }

    void NewTirLaser(int nombreRebonds)
    {
        origin = transform.position;
        direction = transform.forward;
        RaycastHit raycastHit;

        if (Physics.Raycast(origin, direction, out raycastHit, length)) 
        {
            Debug.DrawRay(origin, direction * raycastHit.distance, Color.cyan, 0f); 
            Debug.DrawRay(raycastHit.point, raycastHit.normal, Color.magenta, 0f);
            Vector3 newDirection = Vector3.Reflect(direction, raycastHit.normal);
            Vector3 lastpoint = raycastHit.point;

            for (int i = 0; i < nombreRebonds; i++)
            {
                if (Physics.Raycast(raycastHit.point, newDirection, out raycastHit, length))
                {
                    Debug.DrawRay(raycastHit.point, newDirection * -raycastHit.distance, Color.green, 0f);
                    Debug.DrawRay(raycastHit.point, raycastHit.normal, Color.magenta, 0f);
                    newDirection = Vector3.Reflect(newDirection, raycastHit.normal);
                    lastpoint = raycastHit.point;
                }
                else
                {
                    Debug.DrawRay(lastpoint, newDirection*length, Color.red,0f);
                    nombreRebonds = 0;
                }
            }
        }
        else
        {
            Debug.DrawRay(origin, direction * length, Color.red,0f);
        }
    }

    
}
