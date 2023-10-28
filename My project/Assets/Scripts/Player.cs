using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<string> Inventory = new List<string>();
    // invetory will carry over
    DataManager dataManager;

    public static Player Instance { get; private set; }

    public bool addedFishToInventory = false; // if fish added to inventory, set to true and update to log book. if fish remove no need to check

    
    // Start is called before the first frame update
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }

        else
        {
            Instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //if player catches fish, invetory.Add(fishID);
    }

    public void FishCaughtAndAddIntoInventory(string FishID)
    {
        Inventory.Add(FishID);
        addedFishToInventory = true;
        Debug.Log("I caught " + FishID);
    }
}
