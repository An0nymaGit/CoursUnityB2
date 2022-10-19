
using Unity.Collections;
using UnityEngine;

public class GameManagerArrayNew : MonoBehaviour
{
    [SerializeField] private GameObject[,] gameObjects; 
    [SerializeField] private GameObject[,,] gameObjects1; 
    public GameObject prefab;
    [SerializeField] private float decalement = 0.1f;
    [SerializeField] private int sizeX = 10;
    [SerializeField] private int sizeY = 20;
    [SerializeField] private int sizeZ = 20;

    public Material matWhite;
    public Material matBlack;

    void Start()
    {
        gameObjects = new GameObject[sizeX, sizeY];
        gameObjects1 = new GameObject[sizeX, sizeY, sizeZ];
        //Damier2D(gameObjects,prefab);
        Damier3D(gameObjects1, prefab);
    }

    void Damier2D(GameObject[,] array, GameObject gb)
    {
        float espacementX = decalement;
        for (int x = 0; x < gameObjects.GetLength(0); x++)
        {
            float espacementY = decalement;
            for (int y = 0; y < gameObjects.GetLength(1); y++)
            {
                gameObjects[x,y] = Instantiate(gb, new Vector3(x+espacementX,0,y+espacementY), Quaternion.identity, transform);
                /*if (x % 2 == 0)
                {
                    if (y % 2 == 0)
                    {
                        gameObjects[x, y].GetComponent<MeshRenderer>().material = matWhite;
                    }
                    else
                    {
                        gameObjects[x, y].GetComponent<MeshRenderer>().material = matBlack;
                    }
                }
                else
                {
                    if (y % 2 == 0)
                    {
                        gameObjects[x, y].GetComponent<MeshRenderer>().material = matBlack;
                    }
                    else
                    {
                        gameObjects[x, y].GetComponent<MeshRenderer>().material = matWhite;
                    }
                }*/
                if ((x+y%2==0))
                {
                    gameObjects[x, y].GetComponent<MeshRenderer>().material = matWhite;
                }
                else
                {
                    gameObjects[x, y].GetComponent<MeshRenderer>().material = matBlack;
                }
                espacementY += decalement;
            }
            espacementX += decalement;
        }
    }

    void Damier3D(GameObject[,,] array, GameObject gb)
    {
        float espacementX = decalement;
        for (int x = 0; x < gameObjects1.GetLength(0); x++)
        {
            float espacementY = decalement;
            for (int y = 0; y < gameObjects1.GetLength(1); y++)
            {
                float espacementZ = decalement;
                for (int z = 0; z < gameObjects1.GetLength(2); z++)
                {
                    gameObjects1[x, y, z] = Instantiate(gb, new Vector3(x + espacementX, y + espacementY, z + espacementZ), Quaternion.identity, transform);
                    if (x % 2 == 0)
                    {
                        if (y % 2 == 0)
                        {
                            if (z % 2 == 0)
                            {
                                gameObjects1[x,y,z].GetComponent<MeshRenderer>().material = matWhite;
                            }
                            else
                            {
                                gameObjects1[x,y,z].GetComponent<MeshRenderer>().material = matBlack;
                            }
                        }
                        else
                        {
                            if (z % 2 == 0)
                            {
                                gameObjects1[x,y,z].GetComponent<MeshRenderer>().material = matBlack;
                            }
                            else
                            {
                                gameObjects1[x,y,z].GetComponent<MeshRenderer>().material = matWhite;
                            }
                            
                        }
                    }
                    else
                    {
                        if (y % 2 == 0)
                        {
                            if (z % 2 == 0)
                            {
                                gameObjects1[x,y,z].GetComponent<MeshRenderer>().material = matBlack;
                            }
                            else
                            {
                                gameObjects1[x,y,z].GetComponent<MeshRenderer>().material = matWhite;
                            }
                        }
                        else
                        {
                            if (z % 2 == 0)
                            {
                                gameObjects1[x,y,z].GetComponent<MeshRenderer>().material = matWhite;
                            }
                            else
                            {
                                gameObjects1[x,y,z].GetComponent<MeshRenderer>().material = matBlack;
                            }
                        }
                    }
                    espacementZ += decalement;
                }
                espacementY += decalement;
            }
            espacementX += decalement;
        }
    }
}
