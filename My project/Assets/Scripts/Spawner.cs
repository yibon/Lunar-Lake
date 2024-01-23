using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public DataManager _dm;

    public GameObject[] fishPF;

    GameObject fishObj;

    private void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            SpawnFish("Bronze");
        }
    }

    private void Update()
    {
        if (MoonTravelling.isSpawning)
        {
            Debug.Log("Bronze Minigamez: " + Minigame.fishesCaught);
            for (int i = 0; i < 5; i++)
            {
                int spawnRate = Random.Range(0, 100);
                Debug.Log("123 doubt!" + spawnRate);

                if (Minigame.fishesCaught >= 0 && Minigame.fishesCaught <= 5)
                {
                    Debug.Log("100% Bronze");
                    SpawnFish("Bronze");
                }

                if (Minigame.fishesCaught > 5 && Minigame.fishesCaught <= 10)
                {
                    Debug.Log("75 Bronze, 25 silver");
                    if (spawnRate >= 0 && spawnRate <= 75)
                    {
                        SpawnFish("Bronze");
                    }

                    else if (spawnRate > 76)
                    {
                        SpawnFish("Silver");
                    }
                }

                if (Minigame.fishesCaught > 10 && Minigame.fishesCaught <= 15)
                {
                    Debug.Log("35% Bronze, 55 silver, 20 gold");
                    if (spawnRate >= 0 && spawnRate <= 35)
                    {
                        SpawnFish("Bronze");
                    }

                    else if (spawnRate > 35 && spawnRate <= 80)
                    {
                        SpawnFish("Silver");
                    }

                    else 
                    {
                        SpawnFish("Gold");
                    }
                }

                if (Minigame.fishesCaught > 15 && Minigame.fishesCaught <= 20)
                {
                    Debug.Log("14% Bronze, 40 silver, 40 gold, 1 platinum");
                    if (spawnRate >= 0 && spawnRate <= 14)
                    {
                        SpawnFish("Bronze");
                    }

                    else if (spawnRate > 14 && spawnRate <= 54)
                    {
                        SpawnFish("Silver");
                    }

                    else if (spawnRate > 54 && spawnRate <= 99)
                    {
                        SpawnFish("Gold");
                    }

                    else
                    {
                        SpawnFish("Platinum");
                    }
                }


                if (Minigame.fishesCaught > 20 && Minigame.fishesCaught <= 25)
                {
                    Debug.Log("12 bronze, 40 silver, 40 gold, 3 plat");
                    if (spawnRate >= 0 && spawnRate <= 12)
                    {
                        SpawnFish("Bronze");
                    }

                    else if (spawnRate > 12 && spawnRate <= 52)
                    {
                        SpawnFish("Silver");
                    }

                    else if (spawnRate > 52 && spawnRate <= 97)
                    {
                        SpawnFish("Gold");
                    }

                    else
                    {
                        SpawnFish("Platinum");
                    }
                }

                if (Minigame.fishesCaught > 25 && Minigame.fishesCaught <= 30)
                {
                    Debug.Log("5 bronze, 30 silver, 60 gold, 5 plat");
                    if (spawnRate >= 0 && spawnRate <= 5)
                    {
                        SpawnFish("Bronze");
                    }

                    else if (spawnRate > 5 && spawnRate <= 35)
                    {
                        SpawnFish("Silver");
                    }

                    else if (spawnRate > 35 && spawnRate <= 95)
                    {
                        SpawnFish("Gold");
                    }

                    else
                    {
                        SpawnFish("Platinum");
                    }
                }
            }

            // Testing
            //SpawnFish("F01");
            //SpawnFish("F01");
            //SpawnFish("F02");
            //SpawnFish("F02");
            //SpawnFish("F03");
            //SpawnFish("F03");
            //SpawnFish("F04");
            //SpawnFish("F04"); 
            //SpawnFish("F05");
            //SpawnFish("F05");
            //SpawnFish("F06");
            //SpawnFish("F06");
            //SpawnFish("F07");
            //SpawnFish("F07");
            //SpawnFish("F08");
            //SpawnFish("F08");
            //SpawnFish("F09");
            //SpawnFish("F09");


        }
    }

    private void SpawnFish(string rarity)
    {
        string fishID = string.Empty;

        switch (rarity)
        {
            case "Bronze":
                int bronzeChances = Random.Range(1, 4);
                Debug.Log("fml" + bronzeChances);
                switch (bronzeChances)
                {
                    case 1:
                        fishID = "F01";
                        break;
                    case 2:
                        fishID = "F02";
                        break;
                    case 3:
                        fishID = "F03";
                        break;
                    default: 
                        Debug.Log("Bronze not found!");
                        break;
                }
                break;

            case "Silver":
                int silverChances = Random.Range(1, 4);
                switch (silverChances)
                {
                    case 1:
                        fishID = "F04";
                        break;
                    case 2:
                        fishID = "F05";
                        break;
                    case 3:
                        fishID = "F06";
                        break;
                    default:
                        Debug.Log("Silver not found!");
                        break;
                }
                break;

            case "Gold":
                int goldChances = Random.Range(1, 3);
                switch (goldChances)
                {
                    case 1:
                        fishID = "F07";
                        break;
                    case 2:
                        fishID = "F08";
                        break;
                    default:
                        Debug.Log("Gold not found!");
                        break;
                }
                break;

            case "Platinum":
                fishID = "F09";
                break;
            default:
                Debug.Log("Fish not found!");
                break;
        }

        Debug.Log("Bronze feeeeshid" + fishID);
        fishObj = Instantiate(PrefabGetter(fishID), GetSpawnLocationByID(fishID), Quaternion.identity) as GameObject;
        fishObj.GetComponent<FishBehaviour>().currFishId = fishID;

        // Despawn Fish
        Destroy(fishObj, MoonTravelling.spawnIntervals);
    }

   
    private GameObject PrefabGetter(string fishID)
    {
        switch (fishID)
        {
            case "F01":
                return fishPF[0];
            case "F02":
                return fishPF[1];
            case "F03":
                return fishPF[2];
            case "F04":
                return fishPF[3];
            case "F05":
                return fishPF[4];
            case "F06":
                return fishPF[5];
            case "F07":
                return fishPF[6];
            case "F08":
                return fishPF[7];            
            case "F09":
                return fishPF[8];    
            default:
                return null;
        }
    }

    private Vector2 GetSpawnLocationByID(string fishID)
    {
        switch (fishID)
        {
            case "F01":
            case "F02":
            case "F03":
                return GetSpawnLocationByRarity("Bronze");

            case "F04":
            case "F05":
            case "F06":
                return GetSpawnLocationByRarity("Silver");

            case "F07":
            case "F08":
                return GetSpawnLocationByRarity("Gold");

            case "F09":
                return GetSpawnLocationByRarity("Platinum");

            default:
                return Vector2.zero;
        }
    }

    private Vector2 GetSpawnLocationByRarity(string rarity)
    {
        float spawnLocationMinY = _dm.SpawnerDataByRarity(rarity).minYvalue;
        float spawnLocationMaxY = _dm.SpawnerDataByRarity(rarity).maxYvalue;
        Vector2 spawnLocation = Vector2.zero;
        // Replace this with fishID min and max pos
        spawnLocation.y = Random.Range(spawnLocationMinY, spawnLocationMaxY);
        spawnLocation.x = Random.Range(-1, 1);

        return spawnLocation;
    }


    #region Old Stuff
    //private void SpawnFish()
    //{
    //    _spawner = _dm.SpawnerDataByID(currSpawn);
    //    StringSplitter();

    //    for (int i = 0; i < splitFishIds.Length; i++)
    //    {
    //        CurrentV3 = GetSpawnPoint(splitFishSpawnPts[i]) + new Vector3(0, Random.Range(-3, 0.5f));
    //        if (CurrentV3 != PreviousV3)
    //        {
    //            switch (splitFishIds[i])
    //            {
    //                case "F01":
    //                    PreviousV3 = new Vector2(1.3f, -4);
    //                    fishObj = Instantiate(fishPF[0], PreviousV3, Quaternion.identity) as GameObject;
    //                    fishObj.GetComponent<FishBehaviour>().currFishId = splitFishIds[i];

    //                    break;
    //                case "F02":
    //                    PreviousV3 = new Vector2(2f, -6);
    //                    fishObj = Instantiate(fishPF[1], PreviousV3, Quaternion.identity) as GameObject;
    //                    fishObj.GetComponent<FishBehaviour>().currFishId = splitFishIds[i];
    //                    break;
    //                case "F03":
    //                    PreviousV3 = CurrentV3;
    //                    fishObj = Instantiate(fishPF[2], PreviousV3, Quaternion.identity) as GameObject;
    //                    fishObj.GetComponent<FishBehaviour>().currFishId = splitFishIds[i];
    //                    break;
    //                case "F04":
    //                    PreviousV3 = CurrentV3;
    //                    fishObj = Instantiate(fishPF[3], PreviousV3, Quaternion.identity) as GameObject;
    //                    fishObj.GetComponent<FishBehaviour>().currFishId = splitFishIds[i];
    //                    break;
    //                case "F05":
    //                    PreviousV3 = CurrentV3;
    //                    fishObj = Instantiate(fishPF[4], PreviousV3, Quaternion.identity) as GameObject;
    //                    fishObj.GetComponent<FishBehaviour>().currFishId = splitFishIds[i];
    //                    break;
    //                case "F06":
    //                    PreviousV3 = CurrentV3;
    //                    fishObj = Instantiate(fishPF[5], PreviousV3, Quaternion.identity) as GameObject;
    //                    fishObj.GetComponent<FishBehaviour>().currFishId = splitFishIds[i];
    //                    break;
    //                case "F07":
    //                    PreviousV3 = CurrentV3;
    //                    fishObj = Instantiate(fishPF[6], PreviousV3, Quaternion.identity) as GameObject;
    //                    fishObj.GetComponent<FishBehaviour>().currFishId = splitFishIds[i];
    //                    break;
    //                case "F08":
    //                    PreviousV3 = CurrentV3;
    //                    fishObj = Instantiate(fishPF[7], PreviousV3, Quaternion.identity) as GameObject;
    //                    fishObj.GetComponent<FishBehaviour>().currFishId = splitFishIds[i];
    //                    break;
    //                case "F09":
    //                    PreviousV3 = CurrentV3;
    //                    fishObj = Instantiate(fishPF[8], PreviousV3, Quaternion.identity) as GameObject;
    //                    fishObj.GetComponent<FishBehaviour>().currFishId = splitFishIds[i];
    //                    break;
    //                case "F10":
    //                    PreviousV3 = CurrentV3;
    //                    fishObj = Instantiate(fishPF[9], PreviousV3, Quaternion.identity) as GameObject;
    //                    fishObj.GetComponent<FishBehaviour>().currFishId = splitFishIds[i];
    //                    break;
    //            }
    //        }

    //    }
    //}

    //public void StringSplitter()
    //{
    //    splitFishSpawnPts = _spawner.fishPoint.Split("@");
    //    splitFishIds = _spawner.fishId.Split("@");
    //}

    //public static Vector3 GetSpawnPoint(string currSpawnPoint)
    //{
    //    //Vector3 spawnPt = Vector3.zero;

    //    switch (currSpawnPoint)
    //    {
    //        case "A":
    //            return PointsManager.spawnPtA;
    //        case "B":
    //            return PointsManager.spawnPtB;
    //        case "C":
    //            return PointsManager.spawnPtC;
    //        case "D":
    //            return PointsManager.spawnPtD;
    //        default:
    //            return Vector3.zero;
    //    }


    //}

    //private void ChangedActiveScene(Scene current, Scene next)
    //{
    //    string currentName = current.name;

    //    if (currentName == null)
    //    {
    //        // Scene1 has been removed
    //        currentName = "Replaced";
    //    }

    //    if (SceneManager.GetActiveScene().name == "Level 1") //level 1
    //    {
    //        currSpawn = "S01";
    //        Debug.Log(currSpawn);
    //    }
    //    else if (SceneManager.GetActiveScene().name == "Level 2") // level 2
    //    {
    //        currSpawn = "S02";
    //        Debug.Log(currSpawn);
    //        SpawnFish();
    //    }
    //    else if (SceneManager.GetActiveScene().name == "Level 3") // level 3
    //    {
    //        currSpawn = "S03";
    //        Debug.Log(currSpawn);
    //        SpawnFish();
    //    }
    //    else
    //    {
    //        return;
    //    }
    //}
    #endregion
}
