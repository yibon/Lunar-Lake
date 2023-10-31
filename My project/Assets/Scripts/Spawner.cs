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
    public Sprite[] spriteList;

    Vector3 fishSpawnPt;

    public GameObject fishPF;

    string[] splitFishIds;
    string[] splitFishSpawnPts;
    Vector3[] splitVectors;

    GameObject fishObj;

    // Start is called before the first frame update
    void Start()
    {
        currSpawn = "S01";
        SceneManager.activeSceneChanged += ChangedActiveScene;
        SpawnFish();
    }

    private void SpawnFish()
    {
        _spawner = _dm.SpawnerDataByID(currSpawn);
        StringSplitter();

        for (int i = 0; i < splitFishIds.Length; i++)
        {
            //Debug.Log(splitFishSpawnPts[i]);
            
            Debug.Log(splitFishIds[i]);

            switch (splitFishIds[i])
            {
                case "F01":
                    fishPF.GetComponent<SpriteRenderer>().sprite = spriteList[0];
                    break;
                case "F02":
                    fishPF.GetComponent<SpriteRenderer>().sprite = spriteList[1];
                    break;
                case "F03":
                    fishPF.GetComponent<SpriteRenderer>().sprite = spriteList[2];
                    break;
                case "F04":
                    fishPF.GetComponent<SpriteRenderer>().sprite = spriteList[3];
                    break;
                case "F05":
                    fishPF.GetComponent<SpriteRenderer>().sprite = spriteList[4];
                    break;
                case "F06":
                    fishPF.GetComponent<SpriteRenderer>().sprite = spriteList[5];
                    break;
                case "F07":
                    fishPF.GetComponent<SpriteRenderer>().sprite = spriteList[6];
                    break;
                case "F08":
                    fishPF.GetComponent<SpriteRenderer>().sprite = spriteList[7];
                    break;
                case "F09":
                    fishPF.GetComponent<SpriteRenderer>().sprite = spriteList[8];
                    break;
                case "F10":
                    fishPF.GetComponent<SpriteRenderer>().sprite = spriteList[9];
                    break;
            }
            CurrentV3 = GetSpawnPoint(splitFishSpawnPts[i]) + new Vector3(0, Random.Range(-2, 3));
            if (CurrentV3 != PreviousV3)
            {
                PreviousV3 = CurrentV3;
                fishObj = Instantiate(fishPF, PreviousV3, Quaternion.identity) as GameObject;
                fishObj.GetComponent<FishBehaviour>().currFishId = splitFishIds[i];
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

        if (SceneManager.GetActiveScene().buildIndex == 1) //level 1
        {
            currSpawn = "S01";
        }
        else if (SceneManager.GetActiveScene().buildIndex == 2) // level 2
        {
            currSpawn = "S02";
        }
        else if (SceneManager.GetActiveScene().buildIndex == 3) // level 3
        {
            currSpawn = "S03";
        }
        else
        {
            return;
        }
    }
}
