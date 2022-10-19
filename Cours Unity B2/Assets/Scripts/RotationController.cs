using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationController : MonoBehaviour
{
    [SerializeField] public float limitX = 75; //rotation vertical de la caméra
    [SerializeField] public float limitY = 180; //rotation horizontal de la caméra

    [SerializeField] public float rotationSpeed = 500; //sensi de la souris
    [SerializeField] Transform head;

    private float rotationX;

    public float inputRotationX;
    public float inputRotationY;

   
    void Update()
    {
        rotationX -= inputRotationX * rotationSpeed * Time.deltaTime; //axe Y inversé
        rotationX = Mathf.Clamp(rotationX, -limitX, limitX);
        head.localRotation = Quaternion.Euler(rotationX, 0, 0); 
        
        transform.localRotation *= Quaternion.Euler(0,inputRotationY * rotationSpeed * Time.deltaTime,0);
    }
    
    
    
    
    
    
}

