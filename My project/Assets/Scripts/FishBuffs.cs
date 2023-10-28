using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishBuffs : MonoBehaviour
{
    [SerializeField] GameObject hr;
    [SerializeField] GameObject ll;

    private void Start()
    {
        hr.SetActive(false);
        ll.SetActive(false);
    }

    public void UpdateBuffs(FishStatus _fish)
    {
        string buffEffect;
        float buffAmount;

        string[] temp = _fish.fishEffect.Split("@");
        buffEffect = temp[0];
        buffAmount = float.Parse(temp[1]);

        switch (buffEffect)
        {
            case "lineLength":
                ll.SetActive(true);
                PointsManager.castedPtExtend += buffAmount;
                Line.lineDepth += buffAmount;
                break;            

            case "hookRange":
                hr.SetActive(true);
                Fishing.hookSize += buffAmount;
                break;

            case "GameEnds":
                break;
        }
    }
}
