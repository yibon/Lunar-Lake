using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MantaEvent : MonoBehaviour
{
    Events kappaEvents = new Events("E01", "Land of the Kappa", "F01,F02,F03", "Player learns of Manta's nature (Reccomended Depth and Hook range)", "", "P01", false);

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
        if (!firstinteraction) //after first level
        {
            trigger.StartDialogue(3);
            StartCoroutine(WaitingAfterFirstInteraction());
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
}