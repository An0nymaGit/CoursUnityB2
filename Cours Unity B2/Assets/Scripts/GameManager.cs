using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour //si MonoBehaviour, alors attachable à un gameObject
{
    [SerializeField] private List<int>
        scores = new(); //serialize = private mais dans l'inspector //liste public OU serialize (visible dans l'inspector) = liste initialisée //raccourci new() pour new du truc d'avant

    [SerializeField] private List<GameObject> players = new();


    void Start()
    {
        AddNumber(10);
        SayList();
        RemoveNumber(scores);
    }

    void Update()
    {

    }

    void AddNumber(int maxIndex)
    {
        for (int i = 0; i < maxIndex; i++)
        {
            //if (i % 2 != 0)
            {
                scores.Add(i);
            }
        }
    }

    void SayList()
    {
        for (int i = 0; i < scores.Count; i++)
        {
            Debug.Log(scores[i]);
        }
    }

    void RemoveNumber(List<int> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            if (i % 2 == 0)
            {
                list[i] = 0;
            }
        }

        while (list.Contains(0))
        {
            list.Remove(0);
        }
    }

    void AddNumber2(int maxIndex)
    {
        bool delete = false;
        for (int i = scores.Count - 1; i > -1; i--)
        {
            if (delete == true)
            {
                scores.RemoveAt(i);
            }

            delete = !delete;
        }
    }
}
