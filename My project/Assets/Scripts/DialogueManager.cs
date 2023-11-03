using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Image speakerIMG;
    public TextMeshProUGUI speakerName;
    public TextMeshProUGUI messageText;
    public RectTransform bgImage;
    public Button MoveOn;
    public Button Stay;

    

    List<Message> currMessages;
    List<Speaker> currSpeaker;
    [HideInInspector]
    public int activeMessage = 0;

    public bool isActive = false;

    #region SINGLETON SCRIPT AHAHAHHAHAHAHAHAH
    public static DialogueManager instance { get; private set; }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }

    }
    #endregion

    public void OpenDialogue(List<Message> messages, List<Speaker> speakers, int messageIndexToDisplay)
    {
        currMessages = messages;
        currSpeaker = speakers;
        activeMessage = messageIndexToDisplay;
        Debug.Log(activeMessage);


        DisplayMessage(messageIndexToDisplay);
    }

    void DisplayMessage(int messageIndexToDisplay)
    {
        //setting current messages to display
        Message messageToDisplay = currMessages[messageIndexToDisplay];
        //displaying them
        messageText.text = messageToDisplay.message;    
        //setting it so game knows there is a message going on now
        isActive = true;
        
        Speaker speakerToDisplay = currSpeaker[messageToDisplay.speakerID];
        speakerName.text = speakerToDisplay.name;
        speakerIMG.sprite = speakerToDisplay.sprite;
    }

    public void NextMessage()
    {
        activeMessage++;
        Debug.Log(activeMessage + "is the active mes");
        if (activeMessage < currMessages.Count && currMessages[activeMessage - 1].nextMessageID != "0" && currMessages[activeMessage - 1].nextMessageID != "1" && currMessages[activeMessage - 1].goToNextLevel != true) //no choice present, moving to next dialougue
        {
            DisplayMessage(activeMessage);
        }
        else if (currMessages[activeMessage-1].nextMessageID == "1") //a choice is present
        {
            MoveOn.gameObject.SetActive(true);
            Stay.gameObject.SetActive(true);
            isActive = false; //setting to false to disable clicking
            activeMessage = activeMessage - 1;
            DisplayMessage(activeMessage);
        }
        else if (currMessages[activeMessage - 1].goToNextLevel == true)
        {
            isActive = false;
            LevelLoader.instance.LoadNextLevel();
            DialogueTrigger.instance.canvas.gameObject.SetActive(isActive);
        }
        else //turning off canvas
        {
            isActive = false;
            DialogueTrigger.instance.canvas.gameObject.SetActive(isActive);
        }
        
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && isActive == true)
        {
            NextMessage();
        }
    }

    public void StayinLevel()
    {
        MoveOn.gameObject.SetActive(false);
        Stay.gameObject.SetActive(false);
        isActive = true; //setting back to true to enable clicking
        activeMessage = activeMessage+1; //Must make sure in the dialougue, the choice to stay is 1 after the choice message
        NextMessage();
    }
    public void GoNextLevel()
    {
        
        MoveOn.gameObject.SetActive(false);
        Stay.gameObject.SetActive(false);
        isActive = true; //setting back to true to enable clicking
        activeMessage = activeMessage+2; //Must make sure in the dialougue, the choice to leave is 2 after the choice message
        NextMessage();
    }
}
