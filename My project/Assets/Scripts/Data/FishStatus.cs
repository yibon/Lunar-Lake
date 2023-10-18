using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class FishStatus  
{ 
    public string fishID { get; set; }    
    public string fishName { get; set; }
    public string fishEffect { get; set; }
    public string fishEffect_2 { get; set; }
    public float fishSpeed { get; set; }
    public string fishSpawnLoc { get; set; }
    public float fishStatePos_1 { get; set; }
    public float fishStateTime_1 { get; set; }
    public float fishStatePos_2 { get; set; }
    public float fishStateTime_2 { get; set; }
    public float fishStatePos_3 { get; set; }
    public float fishStateTime_3 { get; set; }

    public FishStatus(string fishID, string fishName, string fishEffect, string fishEffect_2, float fishSpeed, string fishSpawnLoc, float fishStatePos_1, float fishStateTime_1, float fishStatePos_2, float fishStateTime_2, float fishStatePos_3, float fishStateTime_3)
    {
        this.fishID = fishID;
        this.fishName = fishName;
        this.fishEffect = fishEffect;
        this.fishEffect_2 = fishEffect_2;
        this.fishSpeed = fishSpeed;
        this.fishSpawnLoc = fishSpawnLoc;
        this.fishStatePos_1 = fishStatePos_1;
        this.fishStateTime_1 = fishStateTime_1;
        this.fishStatePos_2 = fishStatePos_2;
        this.fishStateTime_2 = fishStateTime_2;
        this.fishStatePos_3 = fishStatePos_3;
        this.fishStateTime_3 = fishStateTime_3;
    }
}
