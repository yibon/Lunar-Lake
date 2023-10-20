using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private FishSpawner _spawner;
    public DataManager _dm;
    
    private string currSpawn;

    Vector3 fishSpawnPt;

    public GameObject fishPF;

    string[] splitFishIds;
    string[] splitFishSpawnPts;
    Vector3[] splitVectors;

    // Start is called before the first frame update
    void Start()
    {
        currSpawn = "S01";
        SpawnFish();
    }

    private void SpawnFish()
    {
        //Debug.Log(fishSpawnPts[0]);
        _spawner = _dm.SpawnerDataByID(currSpawn);
        StringSplitter();

        for (int i = 0; i < splitFishIds.Length; i++)
        {
            //Debug.Log(splitFishIds[i]);
            GameObject fishObj = Instantiate(fishPF, fishSpawnPt, Quaternion.identity) as GameObject;
            fishObj.GetComponent<FishBehaviour>().currFishId = splitFishIds[i];
        }
    }

    private void StringSplitter()
    {
        splitFishSpawnPts = _spawner.fishPoint.Split("@");

        for (int i = 0; i < splitFishSpawnPts.Length; i++)
        {
            string[] fishSpawnPts = splitFishSpawnPts[i].Split(",");
            fishSpawnPt.x = float.Parse(fishSpawnPts[0]);
            fishSpawnPt.y = float.Parse(fishSpawnPts[1]);
        }

        splitFishIds = _spawner.fishId.Split("@");
    }
}
