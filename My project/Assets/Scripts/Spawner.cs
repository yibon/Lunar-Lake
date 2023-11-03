using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawner : MonoBehaviour
{
    private FishSpawner _spawner;
    public DataManager _dm;

    private string currSpawn;

    private Vector3 PreviousV3;
    private Vector3 CurrentV3;

    Vector3 fishSpawnPt;

    public GameObject[] fishPF;
    GameObject Location;

    string[] splitFishIds;
    string[] splitFishSpawnPts;
    Vector3[] splitVectors;

    GameObject fishObj;

    // Start is called before the first frame update
    void Start()
    {
        currSpawn = "S01";
        SpawnFish();
        SceneManager.activeSceneChanged += ChangedActiveScene;
        
    }

    private void SpawnFish()
    {
        _spawner = _dm.SpawnerDataByID(currSpawn);
        StringSplitter();

        for (int i = 0; i < splitFishIds.Length; i++)
        {
            //Debug.Log(splitFishSpawnPts[i]);
            
            Debug.Log(splitFishIds[i]);
            CurrentV3 = GetSpawnPoint(splitFishSpawnPts[i]) + new Vector3(0, Random.Range(-3, 0.5f));
            if (CurrentV3 != PreviousV3)
            {
                switch (splitFishIds[i])
                {
                    case "F01":
                        PreviousV3 = new Vector2(1.3f,-4);
                        fishObj = Instantiate(fishPF[0], PreviousV3, Quaternion.identity) as GameObject;
                        fishObj.GetComponent<FishBehaviour>().currFishId = splitFishIds[i];

                        break;
                    case "F02":
                        PreviousV3 = new Vector2(2f, -6);
                        fishObj = Instantiate(fishPF[1], PreviousV3, Quaternion.identity) as GameObject;
                        fishObj.GetComponent<FishBehaviour>().currFishId = splitFishIds[i];
                        break;
                    case "F03":
                        PreviousV3 = CurrentV3;
                        fishObj = Instantiate(fishPF[2], PreviousV3, Quaternion.identity) as GameObject;
                        fishObj.GetComponent<FishBehaviour>().currFishId = splitFishIds[i];
                        break;
                    case "F04":
                        PreviousV3 = CurrentV3;
                        fishObj = Instantiate(fishPF[3], PreviousV3, Quaternion.identity) as GameObject;
                        fishObj.GetComponent<FishBehaviour>().currFishId = splitFishIds[i];
                        break;
                    case "F05":
                        PreviousV3 = CurrentV3;
                        fishObj = Instantiate(fishPF[4], PreviousV3, Quaternion.identity) as GameObject;
                        fishObj.GetComponent<FishBehaviour>().currFishId = splitFishIds[i];
                        break;
                    case "F06":
                        PreviousV3 = CurrentV3;
                        fishObj = Instantiate(fishPF[5], PreviousV3, Quaternion.identity) as GameObject;
                        fishObj.GetComponent<FishBehaviour>().currFishId = splitFishIds[i];
                        break;
                    case "F07":
                        PreviousV3 = CurrentV3;
                        fishObj = Instantiate(fishPF[6], PreviousV3, Quaternion.identity) as GameObject;
                        fishObj.GetComponent<FishBehaviour>().currFishId = splitFishIds[i];
                        break;
                    case "F08":
                        PreviousV3 = CurrentV3;
                        fishObj = Instantiate(fishPF[7], PreviousV3, Quaternion.identity) as GameObject;
                        fishObj.GetComponent<FishBehaviour>().currFishId = splitFishIds[i];
                        break;
                    case "F09":
                        PreviousV3 = CurrentV3;
                        fishObj = Instantiate(fishPF[8], PreviousV3, Quaternion.identity) as GameObject;
                        fishObj.GetComponent<FishBehaviour>().currFishId = splitFishIds[i];
                        break;
                    case "F10":
                        PreviousV3 = CurrentV3;
                        fishObj = Instantiate(fishPF[9], PreviousV3, Quaternion.identity) as GameObject;
                        fishObj.GetComponent<FishBehaviour>().currFishId = splitFishIds[i];
                        break;
                }

            }

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

        switch (currSpawnPoint)
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

    private void ChangedActiveScene(Scene current, Scene next)
    {
        string currentName = current.name;

        if (currentName == null)
        {
            // Scene1 has been removed
            currentName = "Replaced";
        }

        if (SceneManager.GetActiveScene().name == "Level 1") //level 1
        {
            currSpawn = "S01";
            Debug.Log(currSpawn);
        }
        else if (SceneManager.GetActiveScene().name == "Level 2") // level 2
        {
            currSpawn = "S02";
            Debug.Log(currSpawn);
            SpawnFish();
        }
        else if (SceneManager.GetActiveScene().name == "Level 3") // level 3
        {
            currSpawn = "S03";
            Debug.Log(currSpawn);
            SpawnFish();
        }
        else
        {
            return;
        }
    }
}
