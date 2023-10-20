using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//how to use:
//this script to be attached to anything that needs to have their dialougue triggered
//once it is in, populate the speaker


public class DialogueTrigger : MonoBehaviour
{
    public List<Message> messages = new List<Message>();
    public List<Speaker> speakers = new List<Speaker>();

    public void StartDialogue()
    {
        DialogueManager.instance.OpenDialogue(messages,speakers);
    }
}


[System.Serializable]
public class Message
{
    public string messageID;
    public string nextMessageID;
    public string speaker;
    public string message;
}

[System.Serializable]
public class Speaker
{
    public string name;
    public Sprite sprite;
}