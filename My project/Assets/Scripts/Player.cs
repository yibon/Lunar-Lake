using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<FishStatus> Inventory = new List<FishStatus>();
    // invetory will carry over
    DataManager dataManager;

    // Start is called before the first frame update
    void Start()
    {  
        Inventory.Add(dataManager.FishDataByID("F01"));
        Inventory.Add(dataManager.FishDataByID("F02"));
        Inventory.Add(dataManager.FishDataByID("F03"));
    }

    // Update is called once per frame
    void Update()
    {
        //if player catches fish, invetory.Add(fishID);
    }
}
