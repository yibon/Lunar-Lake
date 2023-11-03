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
    public TMP_Text fishInvent;

    public Image HRBuff;
    public Image LLBuff;

    float F01caught;
    float F02caught;
    float F03caught;

    AudioManager _am;

    private void Awake()
    {
        _topSR.color = Color.black;
        _midSR.color = Color.black;
        _btmSR.color = Color.black;

        _am = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            this.gameObject.SetActive(false);
        }

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
                    fishName.text = "Common Koi";
                    fishPhases.text = "New";
                    fishCaught.text = "Number of Fish Caught: " + F01caught;
                    fishInvent.text = "In Your Inventory: " + F01caught;
                    LLBuff.gameObject.SetActive(true);
                    HRBuff.gameObject.SetActive(false);
                }

                else
                {
                    fishName.text = "Unknown";
                    fishPhases.text = "Unknown";
                    fishCaught.text = "Number of Fish Caught: " + F01caught;
                    fishInvent.text = "In Your Inventory: " + F01caught;
                    LLBuff.gameObject.SetActive(false);
                    HRBuff.gameObject.SetActive(false);
                }

                break;

            case "Mid":
                if (F02caught > 0)
                {
                    fishName.text = "Silver Scales";
                    fishPhases.text = "New";
                    fishCaught.text = "Number of Fish Caught: " + F02caught;
                    fishInvent.text = "In Your Inventory: " + F02caught;
                    LLBuff.gameObject.SetActive(false);
                    HRBuff.gameObject.SetActive(true);
                }

                else
                {
                    fishName.text = "Unknown";
                    fishPhases.text = "Unknown";
                    fishCaught.text = "Number of Fish Caught: " + F02caught;
                    fishInvent.text = "In Your Inventory: " + F02caught;
                    LLBuff.gameObject.SetActive(false);
                    HRBuff.gameObject.SetActive(false);
                }

                break;

            case "Bot":
                if (F03caught > 0)
                {
                    fishName.text = "Crystal Betta";
                    fishPhases.text = "New, Half";
                    fishCaught.text = "Number of Fish Caught: " + F03caught;
                    fishInvent.text = "In Your Inventory: " + F03caught;
                    LLBuff.gameObject.SetActive(true);
                    HRBuff.gameObject.SetActive(false);
                }

                else
                {
                    fishName.text = "Unknown";
                    fishPhases.text = "Unknown";
                    fishCaught.text = "Number of Fish Caught: " + F03caught;
                    fishInvent.text = "In Your Inventory: " + F03caught;
                    LLBuff.gameObject.SetActive(false);
                    HRBuff.gameObject.SetActive(false);
                }

                break;

            case "None":
                fishName.text = "Name of Fish";
                fishPhases.text = "Moon Phase";
                fishCaught.text = "Number of Fish Caught: ";
                LLBuff.gameObject.SetActive(false);
                HRBuff.gameObject.SetActive(false);

                break;
            }
        }

    public void UpdateLogBook(string _fish)
    {
        if (Player.Instance.addedFishToInventory == true)
        {
            Debug.Log("Caught Fish");
            switch (_fish)
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

        if (Player.Instance.removedFishFromInventory == true)
        {
            switch (_fish)
            {
                case "F01":
                    F01caught--;
                    break;

                case "F02":
                    F02caught--;
                    break;

                case "F03":
                    F03caught--;
                    break;
            }
            Player.Instance.removedFishFromInventory = false;
        }
        
    }
}
