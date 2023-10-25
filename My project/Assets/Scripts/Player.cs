using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public DataManager dataManager;
    // invetory will carry over
    public List<string> Inventory = new List<string>();
    // if fish added to inventory, set to true and update to log book. if fish remove no need to check
    public bool addedFishToInventory = false;
    

    public static Player Instance { get; private set; }
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

    public void ChoosingRod()
    {
        if (SceneManager.GetActiveScene().buildIndex == 2 || SceneManager.GetActiveScene().buildIndex == 3)
        {
            //let player chose rod
        }
    }
}
