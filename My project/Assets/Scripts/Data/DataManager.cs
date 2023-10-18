using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public Events events;
    public FishStatus fishStatus;
    public RodStatus rodStatus;


    // Start is called before the first frame update
    void Start()
    {
        fList.Add(F01); fList.Add(F02); fList.Add(F03); fList.Add(F04); fList.Add(F05); fList.Add(F06); fList.Add(F07); fList.Add(F08); fList.Add(F09); fList.Add(F10);

        rList.Add(R01); rList.Add(R02); rList.Add(R03);

        eList.Add(E01); eList.Add(E02); eList.Add(E03);


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

    #region All Data
    public List<FishStatus> fList = new List<FishStatus>();
 
    FishStatus F01 = new FishStatus("F01", "Common Koi", "lineLength@0.1f" , "" , 1.0f,"A", 0.8f,2f, 0.7f,4f,0.5f,2f);
    FishStatus F02 = new FishStatus("F02", "Silver Scales", "hookRange@0.1f", "", 1.0f, "B", 0.8f,2f, 0.7f,4f, 0.5f,2f);
    FishStatus F03 = new FishStatus("F03", "Moonbeam Betta", "lineLength@0.1f", "", 1.0f, "B", 0.8f, 2f, 0.7f, 4f, 0.5f, 2f);
    FishStatus F04 = new FishStatus("F04", "Tidal Tetra", "hookRange@0.2f", "", 1.5f, "A", 0.9f,3f, 0.3f,4f, 0.5f, 2f);
    FishStatus F05 = new FishStatus("F05", "Pufferfish", "lineLength@0.2f", "", 1.5f, "B", 0.9f,3f, 0.3f,4f, 0.6f,1f);
    FishStatus F06 = new FishStatus("F06", "Lunar Eel", "hookRange@0.5f", "end level", 1.75f, "A", 0.1f,3f, 0.7f,2f, 0.5f,3f);
    FishStatus F07 = new FishStatus("F07", "Angler Fish", "lineLength@0.5f", "end level", 1.75f, "B", 0.1f,3f, 0.7f,2f, 0.5f,3f);
    FishStatus F08 = new FishStatus("F08", "Shark", "lineLength@0.4f", "", 2f, "A", 0.1f,4f, 0.5f,2f, 0.9f,2f);
    FishStatus F09 = new FishStatus("F09", "Narwhal", "hookRange@0.4f", "", 2f, "B", 0.1f,4f, 0.5f,2f, 0.9f,2f);
    FishStatus F10 = new FishStatus("F10", "Moonlight Manta", "GameEnds", "", 2.25f, "B", 0.9f,2f, 0.1f,3f, 0.6f,3f);

    public List<RodStatus> rList = new List<RodStatus>();

    RodStatus R01 = new RodStatus("R01", "Basic", "The most basic rod you can have", "", 1f,1f);
    RodStatus R02 = new RodStatus("R02", "Length Rod", "fishes gives more line length", "lineLength*1.3f", 1.5f, 1f);
    RodStatus R03 = new RodStatus("R02", "Length Rod", "fishes gives more hook range", "hookRange*1.3f", 1f, 1.5f);

    public List<Events> eList = new List<Events>();

    Events E01 = new Events("E01", "Land of the Kappa", "F01,F02,F03", "Player learns of Manta's nature (Reccomended Depth and Hook range)","","P01",false);
    Events E02 = new Events("E02", "Ghost in Control", "F05", "Player regains contorl","Player cannot control boat","P02",false);
    Events E03 = new Events("E03", "The Prosperity", "F10", "Win","Lose","P01",false);


    #endregion
}