using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    

    #region All Data
    public List<FishStatus> fList = new List<FishStatus>();

    FishStatus F01 = new FishStatus("F01", "Common Koi", "lineLength@0.1", "", 1.0f, "B", 0.1f, 2f, 0.3f, 4f, 0.15f, 2f);
    FishStatus F02 = new FishStatus("F02", "Silver Scales", "hookRange@0.01", "", 1.0f, "A", 0.2f, 2f, 0.4f, 4f, 0.3f, 2f);
    FishStatus F03 = new FishStatus("F03", "Crystal Betta", "lineLength@0.1", "", 1.0f, "B", 0.3f, 2f, 0.6f, 4f, 0.35f, 2f);
    FishStatus F04 = new FishStatus("F04", "Namazu", "hookRange@0.03", "", 1.5f, "A", 0.5f, 3f, 0.4f, 4f, 0.65f, 2f);
    FishStatus F05 = new FishStatus("F05", "Pufferfish", "lineLength@0.2", "", 1.5f, "B", 0.6f, 3f, 0.8f, 4f, 0.9f, 1f);
    FishStatus F06 = new FishStatus("F06", "Crocodile Gar", "hookRange@0.05", "end level", 1.75f, "A", 0.5f, 3f, 0.75f, 2f, 0.65f, 3f);
    FishStatus F07 = new FishStatus("F07", "Angler Fish", "lineLength@0.5", "end level", 1.75f, "B", 0.6f, 3f, 0.75f, 2f, 0.9f, 3f);
    FishStatus F08 = new FishStatus("F08", "Old Man", "lineLength@0.4", "", 2f, "A", 0.9f, 4f, 0.6f, 2f, 0.8f, 2f);
    FishStatus F09 = new FishStatus("F09", "Medium Squid", "hookRange@0.1", "", 2f, "B", 0.75f, 4f, 0.5f, 2f, 0.9f, 2f);
    FishStatus F10 = new FishStatus("F10", "Moonlight Manta", "GameEnds@0", "", 2.25f, "B", 0.9f, 2f, 0.6f, 3f, 0.3f, 3f);

    public List<RodStatus> rList = new List<RodStatus>();

    RodStatus R01 = new RodStatus("R01", "Basic", "The most basic rod you can have", "", 1f, 1f);
    RodStatus R02 = new RodStatus("R02", "Length Rod", "fishes gives more line length", "1.3", 1.5f, 1f);
    RodStatus R03 = new RodStatus("R03", "Hook Rod", "fishes gives more hook range", "0.1", 1f, 1.5f);

    public List<Events> eList = new List<Events>();

    Events E01 = new Events("E01", "Land of the Kappa", "F01,F02,F03", "Player learns of Manta's nature (Reccomended Depth and Hook range)", "", "P01", false);
    Events E02 = new Events("E02", "Ghost in Control", "F05", "Player regains contorl", "Player cannot control boat", "P02", false);
    Events E03 = new Events("E03", "The Prosperity", "F10", "Win", "Lose", "P01", false);

    FishSpawner S01 = new FishSpawner("S01", "F01@F02@F03@F04", 4, "A@B@A@B", "S02");
    FishSpawner S02 = new FishSpawner("S02", "F03@F04@F05@F06@F07", 5, "A@B@B@B@C", "S03");
    FishSpawner S03 = new FishSpawner("S03", "F05@F06@F07@F08@F09@F10", 5, "B@B@C@C@B@C", "");
    #endregion

    public Events events;
    public FishStatus fishStatus;
    public RodStatus rodStatus;

    public List<FishSpawner> sList = new List<FishSpawner>();
    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        fList.Add(F01); fList.Add(F02); fList.Add(F03); fList.Add(F04); fList.Add(F05); fList.Add(F06); fList.Add(F07); fList.Add(F08); fList.Add(F09); fList.Add(F10);

        rList.Add(R01); rList.Add(R02); rList.Add(R03);

        eList.Add(E01); eList.Add(E02); eList.Add(E03);

        sList.Add(S01); sList.Add(S02);  sList.Add(S03);
        
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

    public FishSpawner SpawnerDataByID(string sID)
    {
        foreach (var s in sList) { if (s.waveId == sID) return s; } return null;
    }

}
