using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using static UnityEditor.Progress;

public class KappaEvent : MonoBehaviour
{
    Events kappaEvents = new Events("E01", "Land of the Kappa", "F01,F02,F03", "Player learns of Manta's nature (Reccomended Depth and Hook range)", "", "P01", false);

    public Canvas canvas;
    public DataManager dataManager;
    public Player player;

    public DialogueTrigger trigger;
    //gameobject to show player what to interact with in case stoopid
    public GameObject questionMark; //slightly greyed out (Yellow)
    public GameObject exclaimationMark; //Sky Blue

    bool canInteract = false;


    // Start is called before the first frame update
    void Start()
    {

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
        List<string> clearCon = kappaEvents.eventClearCondiditon.Split(",").ToList();


        if (exclaimationMark.activeInHierarchy == true) //first interaction
        {
            exclaimationMark.SetActive(false);
            //open dialougue box
            trigger.StartDialogue();
            canvas.gameObject.SetActive(true);
            //pause all other interaction
            canInteract = false;
            //play corroutine to set the stuff


            
            canvas.gameObject.SetActive(false);
            //after dialougue ends and Canvas is set to inactive
            questionMark.SetActive(true);
            canInteract = true;

            Debug.Log("HI IM KAPPA");
        }
        else if (questionMark.activeInHierarchy == true)//2nd interaction onwards
        {
            if (!CheckInvetory(clearCon)) //inventory check fail
            {
                //open dialougue box for incompleted quest
                questionMark.SetActive(false);
                canvas.gameObject.SetActive(true);
                //pause all other interaction
                canInteract = false;
                //play corroutine to set the stuff



                canvas.gameObject.SetActive(false);
                //after dialougue ends and Canvas is set to inactive
                questionMark.SetActive(true);
                canInteract = true;
                Debug.Log("Check Fail");
            }
            else //yes
            {
                //open dialougue box for completed Quest
                questionMark.SetActive(false);
                canvas.gameObject.SetActive(true);
                //pause all other interaction
                canInteract = false;
                //play corroutine to set the stuff



                canvas.gameObject.SetActive(false);
                //after dialougue ends and Canvas is set to inactive
                questionMark.SetActive(true);
                canInteract = true;

                CompletedQuest();
                Debug.Log("Quest Done!");
                //plays dialougue of quest if completed and see if player want to submit

                //if () //player still want to play
                //{

                //}
                //else //player want to submit quest
                //{
                //}
            }
        }
        else // interaction after submiting quest
        {
            Debug.Log("I have nothing else for you! Shoo");
        }

    }

    public bool CheckInvetory(List<string> questItem)
    {
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

    public void CompletedQuest()
    {
        kappaEvents.isDone = true;
        questionMark.SetActive(false);
    }

    IEnumerator KappaDialougue()
    {

        yield return null;
    }
}
