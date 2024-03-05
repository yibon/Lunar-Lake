//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class FishData
//{
//    DataManager _dataManager;

//    private string currFish;

//    private string currFishID;
//    private string currFishName;
//    private string currFishEffect;
//    private string currFishEffect_2;
//    private float currFishSpeed;
//    private string currFishSpawnLoc;
//    private float currFishStatePos_1;
//    private float currFishStatePos_2;
//    private float currFishStatePos_3;

//    private float currFishStateTime_1;
//    private float currFishStateTime_2;
//    private float currFishStateTime_3;

//    private bool isDirty;

//    public FishData(string _currFish)
//    {
//        this.currFish = _currFish;
//        isDirty = true;
//    }

//    public string GetCurrentFish()
//    {
//        return currFish;
//    }    
    
//    public float GetFishSpeed()
//    {
//        return currFishSpeed;
//    }

//    public void SetCurrentFish(string _fish)
//    {
//        currFish = _fish;
//        isDirty = true;
//    }

//    public bool UpdateFishStats()
//    {
//        if (!isDirty)
//            return false;

//        //                    vv cannot reference properly.....
//        FishStatus fishes = _dataManager.FishDataByID(currFish);

//        currFishID = fishes.fishID;
//        currFishName = fishes.fishName;
//        currFishEffect = fishes.fishEffect;
//        currFishEffect_2 = fishes.fishEffect_2;

//        currFishSpeed = fishes.fishSpeed;
//        currFishSpawnLoc = fishes.fishSpawnLoc;

//        currFishStatePos_1 = fishes.fishStatePos_1;
//        currFishStatePos_2 = fishes.fishStatePos_2;
//        currFishStatePos_3 = fishes.fishStatePos_3;

//        currFishStateTime_1 = fishes.fishStateTime_1;
//        currFishStateTime_2 = fishes.fishStateTime_2;
//        currFishStateTime_3 = fishes.fishStateTime_3;

//        isDirty = false;
//        return true;
//    }

//    public float GetFishStatePos1()
//    {
//        UpdateFishStats();
//        return currFishStatePos_1;
//    }    
    
//    public float GetFishStatePos2()
//    {
//        UpdateFishStats();
//        return currFishStatePos_2;
//    }
    
//    public float GetFishStatePos3()
//    {
//        UpdateFishStats();
//        return currFishStatePos_3;
//    }

//    public float GetFishStateTime1()
//    {
//        UpdateFishStats();
//        return currFishStateTime_1;
//    }

//    public float GetFishStateTime2()
//    {
//        UpdateFishStats();
//        return currFishStateTime_2;
//    }

//    public float GetFishStateTime3()
//    {
//        UpdateFishStats();
//        return currFishStateTime_3;
//    }
//}
