using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LogBookDisplay : MonoBehaviour
{
    [Header("IMAGES")] 
    public Image _topSR;
    public Image _midSR;
    public Image _btmSR;

    [Header("NAMES")]
    public TMP_Text topName;
    public TMP_Text midName;
    public TMP_Text btmName;

    [Header("PHASE")]
    public TMP_Text topPhase;
    public TMP_Text midPhase;
    public TMP_Text btmPhase;


    [Header("NUM CAUGHT")]
    public TMP_Text topNum;
    public TMP_Text midNum;
    public TMP_Text btmNum;

    float F01caught;
    float F02caught;
    float F03caught;

    // Update is called once per frame
    void Update()
    {
        #region F01
        if (F01caught == 0)
        {
            _topSR.color = Color.black;
            topName.text = "Fish Name: Unknown";
            topPhase.text = "Phase Appearance: Unknown";
        }

        else
        {
            _topSR.color = Color.white;
            topName.text = "Fish Name: Silver Scales";
            topPhase.text = "Phase Appearance: New, Half";
        }

        topNum.text = "Number Caught: " + F01caught;
        #endregion F01        
        
        #region F02
        if (F02caught == 0)
        {
            _midSR.color = Color.black;
            midName.text = "Fish Name: Unknown";
            midPhase.text = "Phase Appearance: Unknown";
        }

        else
        {
            _midSR.color = Color.white;
            midName.text = "Fish Name: MoonBeam Betta";
            midPhase.text = "Phase Appearance: New, Half";
        }

        midNum.text = "Number Caught: " + F02caught;
        #endregion F02        

        #region F03
        if (F03caught == 0)
        {
            _btmSR.color = Color.black;
        }

        else
        {
            _btmSR.color = Color.white;
        }
        #endregion F03
    }

    public void UpdateLogBook(FishStatus _fish)
    {
        if (Player.Instance.addedFishToInventory == true)
        {
            Debug.Log("Caught Fish");
            switch (_fish.fishID)
            {
                case "F01":
                    F01caught++;
                    break;
                case "F02":
                    F02caught++;
                    break;
                case "F03":
                    F03caught++;
                    break;
            }
            Player.Instance.addedFishToInventory = false;
        }
        
    }
}
