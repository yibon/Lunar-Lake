using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//how to use:
//this script to be attached to anything that needs to have their dialougue triggered
//once it is in, populate the speaker


public class DialogueTrigger : MonoBehaviour
{
    public Canvas canvas;
    public List<Message> messages = new List<Message>();
    public List<Speaker> speakers = new List<Speaker>();

    #region SINGLETON SCRIPT AHAHAHHAHAHAHAHAH
    public static DialogueTrigger instance { get; private set; }

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

    public void StartDialogue(int messageIndex)
    {
        canvas.gameObject.SetActive(true);
        int messageIndexToDisplay = messageIndex;
        DialogueManager.instance.OpenDialogue(messages, speakers, messageIndexToDisplay);
        
    }
}


[System.Serializable]
public class Message
{
    public string messageID;
    public string nextMessageID;
    public int speakerID;
    public string message;
    public bool goToNextLevel;
}

[System.Serializable]
public class Speaker
{
    public string name;
    public Sprite sprite;
}