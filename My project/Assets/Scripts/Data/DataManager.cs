using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    

    #region All Data
    public List<FishStatus> fList = new List<FishStatus>();

    FishStatus F01 = new FishStatus("F01", "Common Koi", "lineLength@0.2", "", 0.1f, "B", 0.1f, 2f, 0.3f, 4f, 0.15f, 2f, "Bronze");
    FishStatus F02 = new FishStatus("F02", "Silver Scales", "lineLength@0.3", "", 0.15f, "A", 0.2f, 2f, 0.4f, 4f, 0.3f, 2f, "Bronze");
    FishStatus F03 = new FishStatus("F03", "Crystal Betta", "lineLength@0.2", "", 0.15f, "B", 0.3f, 2f, 0.6f, 4f, 0.35f, 2f, "Bronze");
    FishStatus F04 = new FishStatus("F04", "Namazu", "hookRange@0.03", "", 0.2f, "A", 0.5f, 3f, 0.4f, 4f, 0.65f, 2f, "Silver");
    FishStatus F05 = new FishStatus("F05", "Pufferfish", "hookRange@0.02", "", 0.2f, "B", 0.6f, 3f, 0.8f, 4f, 0.9f, 1f, "Silver");
    FishStatus F06 = new FishStatus("F06", "Crocodile Gar", "hookRange@0.05", "end level", 0.25f, "A", 0.5f, 3f, 0.75f, 2f, 0.65f, 3f, "Silver");
    FishStatus F07 = new FishStatus("F07", "Angler Fish", "lineLength@0.5", "end level", 0.3f, "B", 0.6f, 3f, 0.75f, 2f, 0.9f, 3f, "Gold");
    FishStatus F08 = new FishStatus("F08", "Old Man", "lineLength@0.4", "", 0.7f, "A", 0.3f, 4f, 0.6f, 2f, 0.8f, 2f, "Gold");
    FishStatus F09 = new FishStatus("F09", "Moonlight Manta", "GameEnds@0", "", 1f, "B", 0.45f, 4f, 0.5f, 2f, 0.9f, 2f, "Platinum");

    public List<RodStatus> rList = new List<RodStatus>();

    RodStatus R01 = new RodStatus("R01", "Basic", "The most basic rod you can have", "", 1f, 1f);
    RodStatus R02 = new RodStatus("R02", "Length Rod", "fishes gives more line length", "1.3", 1.5f, 1f);
    RodStatus R03 = new RodStatus("R03", "Hook Rod", "fishes gives more hook range", "0.1", 1f, 1.5f);

    public List<Events> eList = new List<Events>();

    Events E01 = new Events("E01", "Land of the Kappa", "F01,F02,F03", "Player learns of Manta's nature (Reccomended Depth and Hook range)", "", "P01", false);
    Events E02 = new Events("E02", "Ghost in Control", "F05", "Player regains contorl", "Player cannot control boat", "P02", false);
    Events E03 = new Events("E03", "The Prosperity", "F10", "Win", "Lose", "P01", false);

    //              (-10)  (18)
    // Tier Number, Min X, Max X, Min Y, Max Y 
    FishSpawner T4 = new FishSpawner(4, 11, 14, -4, -12, "Bronze");
    FishSpawner T3 = new FishSpawner(3, 9, 10, -9, -15, "Silver");
    FishSpawner T2 = new FishSpawner(2, 5, 6, -13, -17, "Gold");
    FishSpawner T1 = new FishSpawner(1, 3, 4, -16, -18, "Platinum");
    #endregion

    public Events events;
    public FishStatus fishStatus;
    public RodStatus rodStatus;

    public List<FishSpawner> sList = new List<FishSpawner>();
    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        fList.Add(F01); fList.Add(F02); fList.Add(F03); fList.Add(F04); fList.Add(F05); fList.Add(F06); fList.Add(F07); fList.Add(F08); fList.Add(F09);

        rList.Add(R01); rList.Add(R02); rList.Add(R03);

        eList.Add(E01); eList.Add(E02); eList.Add(E03);

        sList.Add(T1); sList.Add(T2);  sList.Add(T3); sList.Add(T4);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public FishStatus FishDataByID(string fishID)
    {
        foreach (var f in fList) 
        {
            if (f.fishID == fishID) return f;
        }
        return null;
    }
    public RodStatus RodDataByID(string rID)
    {
        foreach (var r in rList) { if (r.rodID == rID) return r; } return null;
    }
    public Events EventDataByID(string eID)
    {
       foreach(var e in eList) { if (e.eventID == eID) return e; } return null; 
    }

    public FishSpawner SpawnerDataByRarity(string sID)
    {
        foreach (var s in sList) { if (s.rarity == sID) return s; } return null;
    }
}
