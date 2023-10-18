using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class FishStatus  
{ 
    //this .cs will go onto each fish to store their information and can be acessed from anywhere.
    #region declaring information

    public string fishID { get; set; }    
    public string fishName { get; set; }
    public string fishEffect { get; set; }
    public string fishEffect_2 { get; set; }
    public float fishSpeed { get; set; }
    public string fishSpawnLoc { get; set; }
    public string fishState_1 { get; set; }
    public string fishState_2 { get; set; }
    public string fishState_3 { get; set; }
    #endregion

    public FishStatus(string fishID, string fishName, string fishEffect, string fishEffect_2, float fishSpeed, string fishSpawnLoc, string fishState_1, string fishState_2, string fishState_3)
    {
        this.fishID = fishID;
        this.fishName = fishName;
        this.fishEffect = fishEffect;
        this.fishEffect_2 = fishEffect_2;
        this.fishSpeed = fishSpeed;
        this.fishSpawnLoc = fishSpawnLoc;
        this.fishState_1 = fishState_1;
        this.fishState_2 = fishState_2;
        this.fishState_3 = fishState_3;

    }
}
