using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class KappaEvent : MonoBehaviour
{
    //bool to check if the quest is cleared
    public bool clearQuest;
    //gameobject to show player what to interact with in case stoopid
    public GameObject questionMark; //slightly greyed out (Yellow)
    public GameObject exclaimationMark; //Sky Blue

    //Kappa's inventory to check if player submit item
    public List<GameObject> kappaInventory = new List<GameObject>();
    //keeping track of weather item is correct
    private int kappaItems;

    // Start is called before the first frame update
    void Start()
    {
        clearQuest = false; //quest havent clear
        exclaimationMark.SetActive(true); //quest has not been clicked
    }

    // Update is called once per frame
    void Update()
    {
        if (clearQuest) 
        {
            //end phase and transistion to analytics screen (either cam pan or actual transitoin into another scene)
                // analytics show the fishes they have in the inventory and how their rods has increase
                // after next button selected, a screen pops up to allow player to choose which rod they want to bring next.
        }
    }

    //interacting with Kappa code
    public void ClickKappa()
    {
        if (exclaimationMark.activeInHierarchy == true && clearQuest == false)
        {
            //play Quest start dialouge
            //this will teach the player how to play the game and also show the player which fish to catch

            exclaimationMark.SetActive(false);
            questionMark.SetActive(true);
        }
        else if (questionMark.activeInHierarchy == true && clearQuest == false)
        {
            // this will ask the player if they are ready to submit
                // playing dialougue and showing options
                    // if no, they will remind the player which fish to catch
                    // if yes, player will give items
                        // if player gives item and they are correct, clearQuest == true; (use kappa items probably?)
                        // if player gives item and they are wrong, player cannot submit the quest and will have to exit
        }
    }


    public void KappaItem()
    {
        //youtube how to submit quest item from inventory


        //checks if the item is the correct item by looking through the list
        foreach (GameObject item in kappaInventory) 
        {
            if (item.name == "F01" || item.name == "F02" || item.name == "F03")
            {
                kappaItems++;
            }
        }
    }
}
