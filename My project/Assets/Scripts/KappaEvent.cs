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
    Events kappaEvents = new Events("E01", "Land of the Kappa", "F01,F02,F03", "Player learns of Manta's nature (Reccomended Depth and Hook range)", "", "P01", false);

    public DataManager dataManager;
    public Player player;
    //gameobject to show player what to interact with in case stoopid
    public GameObject questionMark; //slightly greyed out (Yellow)
    public GameObject exclaimationMark; //Sky Blue

    bool canInteract = false;


    // Start is called before the first frame update
    void Start()
    {
        List<string> clearCon = kappaEvents.eventClearCondiditon.Split(",").ToList();
        Debug.Log(clearCon[0] + " " + clearCon[1] + " " + clearCon[2]);
        if (SceneManager.GetActiveScene().buildIndex == 1) //making sure it is Level 1
        {
            kappaEvents.isDone = false;
            exclaimationMark.SetActive(true); //quest has not been clicked
        }
        else
        {
            kappaEvents.isDone = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && canInteract)
        {
            ClickedKappa();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Sprites_0")
        {
            canInteract = true;
        }
    }

    //interacting with Kappa code
    public void ClickedKappa()
    {

        if (exclaimationMark.activeInHierarchy == true) //first interaction
        {
            //play Quest start dialouge
            //this will teach the player how to play the game and also show the player which fish to catch

            exclaimationMark.SetActive(false);
            questionMark.SetActive(true);
            Debug.Log("HI IM KAPPA");
        }
        else if (questionMark.activeInHierarchy == true)//2nd interaction onwards
        {
            if (1 == 0) //inventory check fail
            {
                //play dialougue of incompleted quest
            }
            else //yes
            {
                CompletedQuest();
                Debug.Log("Quest Done!");
                //plays dialougue of quest is completed and see if player want to submit

                //if () //player still want to play
                //{

                //}
                //else //player want to submit quest
                //{
                //}
            }
        }

    }



    public void CompletedQuest()
    {
        kappaEvents.isDone = true;
    }

}
