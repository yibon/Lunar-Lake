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

    public DataManager dataManager;
    public Player player;

    public DialogueTrigger trigger;
    //gameobject to show player what to interact with in case stoopid
    public GameObject questionMark; //slightly greyed out (Yellow)
    public GameObject exclaimationMark; //Sky Blue
    public GameObject pressF; 

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
        if (canInteract && Input.GetKeyDown(KeyCode.F) )
        {
            ClickedKappa();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Sprites_0")
        {
            canInteract = true;
            pressF.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Sprites_0")
        {
            canInteract = false;
            pressF.SetActive(false);
        }
    }

    //interacting with Kappa code
    public void ClickedKappa()
    {
        List<string> clearCon = kappaEvents.eventClearCondiditon.Split(",").ToList();

        pressF.SetActive(false);
        #region First Interaction
        if (exclaimationMark.activeInHierarchy == true) //first interaction
        {
            exclaimationMark.SetActive(false);
            canInteract = false;
            //open dialougue box
            trigger.StartDialogue(0);
            //pause all other interaction
            StartCoroutine(WaitingAfterFirstInteraction());

        }
        #endregion

        #region Second Interaction
        else if (questionMark.activeInHierarchy == true) 
        { 
            //checkign inventopry 
            if (!CheckInvetory(clearCon)) //inventory check fail
            {
                //open dialougue box for incompleted quest
                questionMark.SetActive(false);
                canInteract = false;
                //open dialogue
                trigger.StartDialogue(2);

                //play corroutine to set the stuff
                StartCoroutine(WaitingAfterSecondInteractionandCheckFail());
                //after dialougue ends and Canvas is set to inactive
                
            }

            //inventory pass
            else
            {
                //open dialougue box for completed Quest
                questionMark.SetActive(false);
                canInteract = false;
                //open dialogue
                trigger.StartDialogue(4);

                //play corroutine to set the stuff
                StartCoroutine(WaitingAfterSecondInteractionandCheckPass());
                //after dialougue ends and Canvas is set to inactive


                #region plays dialougue of quest if completed and see if player want to submit
                //if () //player still want to play
                //{

                //}
                //else //player want to submit quest
                //{
                //}
                #endregion
            }
        }
        #endregion

        #region Completed Event
        else if (kappaEvents.isDone == true)
        {
            trigger.StartDialogue(6);
            StartCoroutine(WaitingAfterSecondInteractionandCheckPass());
        }
        #endregion
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

  
    IEnumerator WaitingAfterFirstInteraction()
    {
        Debug.Log("Waiting");
        Time.timeScale = 0f;
        yield return new WaitUntil(() => DialogueManager.instance.isActive == false);
        Time.timeScale = 1f;

        Debug.Log("WAited");
        questionMark.SetActive(true);
        canInteract = true;
        
    }
    IEnumerator WaitingAfterSecondInteractionandCheckFail()
    {
        Debug.Log("Waiting");
        Time.timeScale = 0f;
        yield return new WaitUntil(() => DialogueManager.instance.isActive == false);
        Time.timeScale = 1f;

        Debug.Log("WAited");
        questionMark.SetActive(true);
        canInteract = true;
        Debug.Log("Check Fail");
    }
    IEnumerator WaitingAfterSecondInteractionandCheckPass()
    {
        Debug.Log("Waiting");
        Time.timeScale = 0f;
        yield return new WaitUntil(() => DialogueManager.instance.isActive == false);
        Time.timeScale = 1f;

        Debug.Log("WAited");
        questionMark.SetActive(false);
        canInteract = true;

        CompletedQuest();
        Debug.Log("Quest Done!"); 
        //SceneManager.LoadScene(2);
    }

}

