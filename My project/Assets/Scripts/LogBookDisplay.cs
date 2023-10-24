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

    public TMP_Text fishName;
    public TMP_Text fishPhases;
    public TMP_Text fishCaught;

    float F01caught;
    float F02caught;
    float F03caught;

    FishStatus _fish;

    // Update is called once per frame
    void Update()
    {

        Debug.Log(F01caught);

        if (F01caught > 0)
        {
            _topSR.color = Color.white;
        }

        else
        {
            _topSR.color = Color.black;
        }


        if (F02caught > 0)
        {
            _midSR.color = Color.white;
        }

        else
        {
            _midSR.color = Color.black;
        }


        if (F03caught > 0)
        {
            _btmSR.color = Color.white;
        }


        else
        {
            _btmSR.color = Color.black;
        }



        switch (FramesHandler.currFrame)
        {
            case "Top":
                if (F01caught > 0)
                {
                    fishName.text = "Silver Scales";
                    fishPhases.text = "New, Half";
                    fishCaught.text = "Number of Fish Caught: " + F01caught;
                }

                else
                {
                    fishName.text = "Unknown";
                    fishPhases.text = "Unknown";
                    fishCaught.text = "Number of Fish Caught: " + F01caught;
                }

                break;

            case "Mid":
                if (F02caught > 0)
                {
                    fishName.text = "Moonbeam Betta";
                    fishPhases.text = "New, Half";
                    fishCaught.text = "Number of Fish Caught: " + F02caught;
                }

                else
                {
                    fishName.text = "Unknown";
                    fishPhases.text = "Unknown";
                    fishCaught.text = "Number of Fish Caught: " + F02caught;
                }

                break;

            case "Bot":
                if (F03caught > 0)
                {
                    fishName.text = "Common Koi";
                    fishPhases.text = "New";
                    fishCaught.text = "Number of Fish Caught: " + F03caught;
                }

                else
                {
                    fishName.text = "Unknown";
                    fishPhases.text = "Unknown";
                    fishCaught.text = "Number of Fish Caught: " + F03caught;
                }

                break;

            case "None":
                fishName.text = "Name of Fish";
                fishPhases.text = "Moon Phase";
                fishCaught.text = "Number of Fish Caught: ";

                break;
            }
        }

    public void UpdateLogBook(FishStatus _fish)
    {
        if (Player.Instance.addedFishToInventory == true)
        {
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
