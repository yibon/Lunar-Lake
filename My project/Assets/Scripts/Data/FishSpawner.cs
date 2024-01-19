using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawner
{
    public int tier;
    public string rarity;

    public float minXvalue;
    public float maxXvalue;

    public float minYvalue;
    public float maxYvalue;

    public FishSpawner(int tier, float minXvalue, float maxXvalue, float minYvalue, float maxYvalue, string rarity)
    {
        this.tier = tier;
        this.minXvalue = minXvalue;
        this.maxXvalue = maxXvalue;
        this.minYvalue = minYvalue;
        this.maxYvalue = maxYvalue;
        this.rarity = rarity;
    }
}
