using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Image speaker;
    public TextMeshProUGUI speakerName;
    public TextMeshProUGUI messageText;
    public RectTransform bgImage;

    List<Message> currMessages;
    List<Speaker> currSpeaker;
    int activeMessage = 0;

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

    public void OpenDialogue(List<Message> messages, List<Speaker> speakers)
    {
        currMessages = messages;
        currSpeaker = speakers;
        activeMessage = 0;

        Debug.Log("Started" + messages.Count);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
