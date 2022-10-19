using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerNew : MonoBehaviour
{
    public Item cheese;

    public List<Item> inventory;
    
    void Start()
    {
        Debug.Log(inventory[2].weight);
        //inventory.RemoveAt(2);
    }

    void Update()
    {

    }
}

[Serializable]
public class Item
{
    public string name;
    public int price;
    public float weight;
}

