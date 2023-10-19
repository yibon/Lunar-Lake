using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawner
{
    public string waveId { get; }
    //public string spawnDelay{ get; }
    public string fishId { get; }
    public float fishCount { get; }
    public string fishPoint { get; }
    public string nextWaveId { get; }

    public FishSpawner(string waveId , string fishId, float fishCount, string fishPoint, string nextWaveId)
    {
        this.waveId = waveId;
        //this.spawnDelay = spawnDelay;   
        this.fishId = fishId;
        this.fishCount = fishCount;
        this.fishPoint = fishPoint;
        this.nextWaveId = nextWaveId;
    }
}
