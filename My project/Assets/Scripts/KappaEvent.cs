using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class KappaEvent : MonoBehaviour
{
    Events events;
    DataManager dataManager;
    Player player;
    //gameobject to show player what to interact with in case stoopid
    public GameObject questionMark; //slightly greyed out (Yellow)
    public GameObject exclaimationMark; //Sky Blue
    
    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().ToString() == "Level 1") //making sure it is Level 1
        {
            this.events = dataManager.EventDataByID("E01"); //setting the Kappa's event
            exclaimationMark.SetActive(true); //quest has not been clicked
        }
        else
        {
            this.events = dataManager.EventDataByID("E01"); 

        }

        CheckingInventoryForQuestItems();
        Debug.Log(CheckingInventoryForQuestItems());
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Sprites_0")
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                ClickedKappa();
            }
        }
    }

    //interacting with Kappa code
    public void ClickedKappa()
    {
        if (events.isDone == false) //quest not done
        {
            if (exclaimationMark.activeInHierarchy == true) //first interaction
            {
                //play Quest start dialouge
                //this will teach the player how to play the game and also show the player which fish to catch

                exclaimationMark.SetActive(false);
                questionMark.SetActive(true);
            }
            else if (questionMark.activeInHierarchy == true) //2nd interaction onwards
            { 
                if (CheckingInventoryForQuestItems()) //inventory check fail
                {
                    //play dialougue of incompleted quest
                }
                else //yes
                {
                    
                    //plays dialougue of quest is completed and see if player want to submit

                    //if () //player still want to play
                    //{

                    //}
                    //else //player want to submit quest
                    //{
                        CompletedQuest();
                    //}
                }
            }
        }
        else //quest done, player gets to listen to hint for manta
        {
            //play hint dialougue
        }
        
    }

    public bool CheckingInventoryForQuestItems()
    {
        //look at inventory and find all that has item name link to quest.
        int clearCon = 0;

        string[] ClearCon = events.eventClearCondiditon.Split(",");
        foreach (string c in ClearCon)
        {
            int numOfQuestFish = 0;
            if (player.Inventory.Contains(dataManager.FishDataByID(c))) //list contains the element of the fish to find
            {
                numOfQuestFish++;
                Debug.Log(numOfQuestFish);
            }
            if (numOfQuestFish >= 1)
            {
                player.Inventory.Remove(dataManager.FishDataByID(c));
                clearCon++;
                Debug.Log(clearCon);
            }
        }
      
        if (ClearCon.Length == clearCon - 1)
        {
            return true;
        }
        return false;
    }
    public void CompletedQuest()
    {
        events.isDone = true;
    }

}
