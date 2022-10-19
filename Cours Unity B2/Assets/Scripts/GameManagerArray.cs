using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class GameManagerArray : MonoBehaviour
{
    [SerializeField] private GameObject[] gameObjects; //privilégier les arrays aux listes car moins gourmandes en perf
    public GameObject prefab;
    [SerializeField] private float decalement = 0.1f;
    [SerializeField] private int nombrePrefab = 10;

    public Material matWhite;
    public Material matBlack;
    
    void Start()
    {
        gameObjects = new GameObject[nombrePrefab];
        AddInArray(gameObjects, prefab);
    }

    void AddInArray(GameObject[] array,GameObject gb)
    {
        float espacement = decalement;
        for (int i = 0; i < array.Length; i++)
        {
            gameObjects[i] = Instantiate(gb, new Vector3(i+espacement,0,0), Quaternion.Euler(0,0,0), transform);
            gameObjects[i].GetComponent<MeshRenderer>().material = i%2==0 ? matWhite : matBlack; //autre façon de faire une boucle if
            espacement += decalement;
            //espacement += espacement;
        }
        /*for (int i = 0; i < array.Length; i++)
        {
            gameObjects[i] = Instantiate(gb, new Vector3(i*1(1+decalement),0,0), Quaternion.identity, transform);
        }*/
    }
}
