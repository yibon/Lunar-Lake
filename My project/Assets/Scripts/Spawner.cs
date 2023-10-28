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
        _spawner = _dm.SpawnerDataByID(currSpawn);
        StringSplitter();

        for (int i = 0; i < splitFishIds.Length; i++)
        {
            //Debug.Log(splitFishSpawnPts[i]);
            GameObject fishObj = Instantiate(fishPF, GetSpawnPoint(splitFishSpawnPts[i]), Quaternion.identity) as GameObject;
            fishObj.GetComponent<FishBehaviour>().currFishId = splitFishIds[i];
        }
    }

    public void StringSplitter()
    {
        splitFishSpawnPts = _spawner.fishPoint.Split("@");
        splitFishIds = _spawner.fishId.Split("@");
    }

    public static Vector3 GetSpawnPoint(string currSpawnPoint)
    {
        //Vector3 spawnPt = Vector3.zero;

        switch(currSpawnPoint)
        {
            case "A":
                return PointsManager.spawnPtA;
            case "B":
                return PointsManager.spawnPtB;
            case "C":
                return PointsManager.spawnPtC;
            case "D":
                return PointsManager.spawnPtD;
            default:
                return Vector3.zero;
        }

         
    }
}
