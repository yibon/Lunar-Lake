using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<string> Inventory = new List<string>();
    // invetory will carry over
    DataManager dataManager;

    // Start is called before the first frame update
    void Awake()
    {  
        Inventory.Add("F02");
        Inventory.Add("F01");
    }

    // Update is called once per frame
    void Update()
    {
        //if player catches fish, invetory.Add(fishID);
    }
}
