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

    // Start is called before the first frame update
    void Start()
    {
        currSpawn = "S01";
        SpawnFish();
    }

    private void SpawnFish()
    {
        _spawner = _dm.SpawnerDataByID(currSpawn);
        Debug.Log(fishSpawnPt);

        GameObject fishObj = Instantiate(fishPF, fishSpawnPt , Quaternion.identity) as GameObject;
        fishObj.GetComponent<FishBehaviour>().currFishId = _spawner.fishId;
    }

    private void StringSplitter()
    {
        string[] fishSpawnPts = _spawner.fishPoint.Split(",");
        fishSpawnPt.x = float.Parse(fishSpawnPts[0]);
        fishSpawnPt.y = float.Parse(fishSpawnPts[1]);
    }
}
