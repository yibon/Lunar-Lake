using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Image speakerIMG;
    public TextMeshProUGUI speakerName;
    public TextMeshProUGUI messageText;
    public RectTransform bgImage;
    

    List<Message> currMessages;
    List<Speaker> currSpeaker;
    int activeMessage = 0;

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
        if (activeMessage < currMessages.Count && currMessages[activeMessage-1].nextMessageID != "0")
        {
            Debug.Log(activeMessage);
            DisplayMessage(activeMessage);
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
}
