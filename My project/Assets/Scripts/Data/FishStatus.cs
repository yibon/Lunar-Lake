using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class FishStatus : MonoBehaviour
{
    //this .cs will go onto each fish to store their information and can be acessed from anywhere.
    #region declaring information
    [SerializeField]
    public string fishID;
    [HideInInspector]
    public string fishName;
    [HideInInspector]
    public string fishEffect;
    [HideInInspector]
    public string fishEffect_2;
    [HideInInspector]
    public float fishSpeed;
    [HideInInspector]
    public string fishSpawnLoc;
    [HideInInspector]
    public string fishState_1;
    [HideInInspector]
    public string fishState_2;
    [HideInInspector]
    public string fishState_3;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        //this is to automate the process of naming all the fishes by using the name of the sprite renderer/gameobject
        //can uncomment later
        //fishID= this.gameObject.name;
        switch (fishID) 
        {
            case "F01":
                fishName = "Common Koi";
                fishEffect = "lineLength += 0.1";
                fishEffect_2 = "";
                fishSpeed = 1.0f;
                fishSpawnLoc = "A";
                fishState_1 = "0.8,2";
                fishState_2 = "0.7,4";
                fishState_3 = "0.5,2";
                break;
            case "F02":
                fishName = "Silver Scales";
                fishEffect = "hookRange += 0.1";
                fishEffect_2 = "";
                fishSpeed = 1.0f;
                fishSpawnLoc = "B";
                fishState_1 = "0.8,2";
                fishState_2 = "0.7,4";
                fishState_3 = "0.5,2";
                break;
            case "F03":
                fishName = "Moonbeam Betta";
                fishEffect = "lineLength += 0.1";
                fishEffect_2 = "";
                fishSpeed = 1.0f;
                fishSpawnLoc = "B";
                fishState_1 = "0.8,2";
                fishState_2 = "0.7,4";
                fishState_3 = "0.5,2";
                break;
            case "F04":
                fishName = "Tidal Tetra";
                fishEffect = "hookRange += 0.2";
                fishEffect_2 = "";
                fishSpeed = 1.5f;
                fishSpawnLoc = "A";
                fishState_1 = "0.9,3";
                fishState_2 = "0.3,4";
                fishState_3 = "0.6,1";
                break;
            case "F05":
                fishName = "Pufferfish";
                fishEffect = "lineLength += 0.2";
                fishEffect_2 = "";
                fishSpeed = 1.5f;
                fishSpawnLoc = "B";
                fishState_1 = "0.9,3";
                fishState_2 = "0.3,4";
                fishState_3 = "0.6,1";
                break;
            case "F06":
                fishName = "Lunar Eel";
                fishEffect = "hookRange += 0.5";
                fishEffect_2 = "playerLoc = original, timer = 0";
                fishSpeed = 1.75f;
                fishSpawnLoc = "A";
                fishState_1 = "0.1,3";
                fishState_2 = "0.7,2";
                fishState_3 = "0.5,3";
                break;
            case "F07":
                fishName = "Angler Fish";
                fishEffect = "lineLength += 0.5";
                fishEffect_2 = "playerLoc = original, timer = 0";
                fishSpeed = 1.75f;
                fishSpawnLoc = "B";
                fishState_1 = "0.1,3";
                fishState_2 = "0.7,2";
                fishState_3 = "0.5,3";
                break;
            case "F08":
                fishName = "Shark";
                fishEffect = "lineLength += 0.4";
                fishEffect_2 = "";
                fishSpeed = 2f;
                fishSpawnLoc = "A";
                fishState_1 = "0.1,4";
                fishState_2 = "0.5,2";
                fishState_3 = "0.9,2";
                break;
            case "F09":
                fishName = "Narwhal";
                fishEffect = "hookRange += 0.4";
                fishEffect_2 = "";
                fishSpeed = 2f;
                fishSpawnLoc = "B";
                fishState_1 = "0.1,4";
                fishState_2 = "0.5,2";
                fishState_3 = "0.9,2";
                break;
            case "F10":
                fishName = "Moonlight Manta";
                fishEffect = "GameEnds";
                fishEffect_2 = "";
                fishSpeed = 2.25f;
                fishSpawnLoc = "A,B";
                fishState_1 = "0.9,2";
                fishState_2 = "0.1,3";
                fishState_3 = "0.6,3";
                break;
            default:
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
