using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class KappaEvent : MonoBehaviour
{
    //bool to check if the quest is cleared
    public Events events;
    //gameobject to show player what to interact with in case stoopid
    public GameObject questionMark; //slightly greyed out (Yellow)
    public GameObject exclaimationMark; //Sky Blue
    
    // Start is called before the first frame update
    void Start()
    {
        events.eventID = "E01";
        exclaimationMark.SetActive(true); //quest has not been clicked
    }

    // Update is called once per frame
    void Update()
    {

    }

    //interacting with Kappa code
    public void ClickKappa()
    {
        if (exclaimationMark.activeInHierarchy == true)
        {
            //play Quest start dialouge
            //this will teach the player how to play the game and also show the player which fish to catch

            exclaimationMark.SetActive(false);
            questionMark.SetActive(true);
        }
        else if (questionMark.activeInHierarchy == true)
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
        //check to see if player has all the items
        // if dont have all the items, ask them to go back
        // if all items present, submit quest.        
        int counter = 0;
        foreach (string item in questItem)
        {
            if (player.Inventory.Contains(item))//player's inventory has this item
            {
                counter++;
            }
        }

        if (counter == questItem.Count)
        {
            foreach (string item in questItem)
            {
                player.Inventory.Remove(item);
            }
            return true;
        }
        return false;
    }
}
