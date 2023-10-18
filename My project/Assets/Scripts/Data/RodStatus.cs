using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RodStatus
{
    
    public string rodID { get; set; }
    public string rodName { get; set; }
    public string rodDescription { get; set; }
    public string rodEffect { get; set; }
    public float rodLineLength { get; set; }
    public float rodHookRange { get; set; }


    public RodStatus(string rodID, string rodName, string rodDescription, string rodEffect, float rodLineLength, float rodHookRange)
    {
        this.rodID = rodID;
        this.rodName = rodName;
        this.rodDescription = rodDescription;
        this.rodEffect = rodEffect;
        this.rodLineLength = rodLineLength;
        this.rodHookRange = rodHookRange;
    }
}

