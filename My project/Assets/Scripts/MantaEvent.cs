using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MantaEvent : MonoBehaviour
{
    Events MantaEvents = new Events("E03", "The Prosperity", "F10", "Win", "Lose", "P01", false);

    public DataManager dataManager;
    public Player player;

    public DialogueTrigger trigger;

    public GameObject questionMark;
    public GameObject exclaimationMark;
    public GameObject pressF;

    [HideInInspector]
    public List<string> clearCon;

    bool canInteract = false;
    bool firstinteraction = true;
    bool questsubmitted = false;
    public LogBookDisplay lbDisplay;
    // Start is called before the first frame update
    void Start()
    {
        canInteract = true;
    }

    private void Update()
    {
        if (lbDisplay == null) {lbDisplay = FindObjectOfType<LogBookDisplay>(); }
        if (dataManager == null) { dataManager = FindObjectOfType<DataManager>();}
        if (player == null) { player = FindObjectOfType<Player>(); }

        if (canInteract && Input.GetKeyDown(KeyCode.F))
        {
            ClickedKappa();
        }

        //checking if quest is cleared
        if (questsubmitted == false && CheckInvetory("F10") && SceneManager.GetActiveScene().name == "Level 3") //if true
        {
            Debug.Log("Manta Caught");
            MantaEvents.isDone = true;
            questionMark.SetActive(true);
            
        }
    }
    public bool CheckInvetory(string questItem)
    {   
        if (player.Inventory.Contains(questItem))//player's inventory has this item
        {
            return true;
        }
        return false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            canInteract = true;
            pressF.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            canInteract = false;
            pressF.SetActive(false);
        }
    }
    private void ClickedKappa()
    { 
        if (firstinteraction) //start of level
        {
            exclaimationMark.SetActive(false);
            canInteract = false;
            //open dialougue box
            trigger.StartDialogue(0);
            //pause all other interaction
            StartCoroutine(WaitingAfterFirstInteraction());
        }
        if (!firstinteraction && SceneManager.GetActiveScene().name == "Level 2") //after first talk
        {
            trigger.StartDialogue(3);
            StartCoroutine(WaitingAfterFirstInteraction());
        }
        if (!firstinteraction&&MantaEvents.isDone == false && SceneManager.GetActiveScene().name == "Level 3")
        { 
            trigger.StartDialogue(2);
            StartCoroutine(WaitingAfterFirstInteraction());
        }
        if (MantaEvents.isDone == true && SceneManager.GetActiveScene().name == "Level 3")
        {
            questionMark.SetActive(false);
            trigger.StartDialogue(3);
            StartCoroutine(WaitingAfterSecondInteractionandCheckPass());
        }
    }

    IEnumerator WaitingAfterFirstInteraction()
    {
        Debug.Log("Waiting");
        Time.timeScale = 0f;
        yield return new WaitUntil(() => DialogueManager.instance.isActive == false);
        Time.timeScale = 1f;

        Debug.Log("WAited");
        //questionMark.SetActive(true);
        canInteract = true;
        firstinteraction = false;

    }
    IEnumerator WaitingAfterSecondInteractionandCheckPass()
    {
        Debug.Log("Waiting");
        Time.timeScale = 0f;
        yield return new WaitUntil(() => DialogueManager.instance.isActive == false);
        Time.timeScale = 1f;

        Debug.Log("WAited");
        canInteract = true;
        questsubmitted = true;
    }
}