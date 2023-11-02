using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FishBuffs : MonoBehaviour
{
    [SerializeField] GameObject hr;
    [SerializeField] GameObject ll;

    [SerializeField] TMP_Text hrText;
    [SerializeField] TMP_Text llText;

    string buffEffect;
    float buffAmount;

    float totBuff_hr;
    float totBuff_ll;

    private void Start()
    {

        hr.SetActive(false);
        ll.SetActive(false);
    }

    private void Update()
    {
        hrText.text = "Hook Range + " + totBuff_hr; 
        llText.text = "Line Length + " + totBuff_ll; 
    }

    public void UpdateBuffs(FishStatus _fish)
    {
        string[] temp = _fish.fishEffect.Split("@");
        buffEffect = temp[0];
        buffAmount += float.Parse(temp[1]);

        switch (buffEffect)
        {
            case "lineLength":
                ll.SetActive(true);
                PointsManager.castedPtExtend += buffAmount;
                Line.lineDepth += buffAmount;
                totBuff_ll += buffAmount;
                break;            

            case "hookRange":
                hr.SetActive(true);
                Fishing.hookSize += buffAmount;
                totBuff_hr += buffAmount;
                break;

            case "GameEnds":
                break;
        }
    }
}
