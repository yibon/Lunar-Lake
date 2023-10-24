using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishBuffs : MonoBehaviour
{

    public static void UpdateBuffs(FishStatus _fish)
    {
        string buffEffect;
        float buffAmount;

        string[] temp = _fish.fishEffect.Split("@");
        buffEffect = temp[0];
        buffAmount = float.Parse(temp[1]);

        switch (buffEffect)
        {
            case "lineLength":
                PointsManager.castedPtExtend += buffAmount;
                Line.lineDepth += buffAmount;
                break;            

            case "hookRange":
                Fishing.hookSize += buffAmount;
                Debug.Log("lalaallaala" + Fishing.hookSize);
                break;

            case "GameEnds":

                break;
        }
    }
}
