using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Events
{
    public string eventID { get; set; }
    public string eventName { get; set; }
    public string eventClearCondiditon { get; set; }
    public string eventRewards { get; set; }
    public string eventEffects { get; set; }
    public string occurence { get; set; }
    public bool isDone { get; set; }


    public Events( string eventID, string eventName, string eventClearCondition, string eventRewards, string eventEffects, string occurence, bool isDone )
    {
        this.eventID = eventID;
        this.eventName = eventName;
        this.eventClearCondiditon = eventClearCondition;
        this.eventRewards = eventRewards;
        this.eventEffects = eventEffects;
        this.occurence = occurence;
        this.isDone = isDone;

    }
}