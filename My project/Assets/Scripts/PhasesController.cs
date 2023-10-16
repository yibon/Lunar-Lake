using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Unity.PlasticSCM.Editor.WebApi;
using Unity.VisualScripting;
using UnityEngine;

public class PhasesController : MonoBehaviour
{
    public static MoonPhases.Phases currMoonPhase;

    [SerializeField] GameObject newMoonAssets;
    [SerializeField] GameObject halfMoonAssets;
    [SerializeField] GameObject fullMoonAssets;

    //this list is to store the information on which fish ID can be spawned and then spawn it from here
    List<string> fishSpawnInCurrentPhase = new List<string>();

    //referencing to fishstatus.cs
    FishStatus fishStatus;

    private void Start()
    {
        currMoonPhase = MoonPhases.Phases.NewMoon;
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.L))
        {
            switch (currMoonPhase)
            {
                case MoonPhases.Phases.NewMoon:
                    newMoonAssets.SetActive(false);
                    halfMoonAssets.SetActive(true);
                    fullMoonAssets.SetActive(false);
                    FishBehaviour.travelVelocity = 0.5f;


                    currMoonPhase = MoonPhases.Phases.HalfMoon;
                    break;

                case MoonPhases.Phases.HalfMoon:
                    newMoonAssets.SetActive(false);
                    halfMoonAssets.SetActive(false);
                    fullMoonAssets.SetActive(true);
                    FishBehaviour.travelVelocity = 0.7f;

                    currMoonPhase = MoonPhases.Phases.FullMoon;
                    break;

                case MoonPhases.Phases.FullMoon:
                    newMoonAssets.SetActive(true);
                    halfMoonAssets.SetActive(false);
                    fullMoonAssets.SetActive(false);
                    FishBehaviour.travelVelocity = 0.3f;

                    currMoonPhase = MoonPhases.Phases.NewMoon;
                    break;
            }
        }

        //leting code know what each moonphase does
        switch (currMoonPhase)
        {
            case MoonPhases.Phases.NewMoon:
                if (fishSpawnInCurrentPhase != null)
                {
                    fishSpawnInCurrentPhase.Clear();
                }
                fishSpawnInCurrentPhase.Add("F01");
                fishSpawnInCurrentPhase.Add("F02");
                fishSpawnInCurrentPhase.Add("F03");
                fishSpawnInCurrentPhase.Add("F04");
                break;
            case MoonPhases.Phases.HalfMoon:
                if (fishSpawnInCurrentPhase != null)
                {
                    fishSpawnInCurrentPhase.Clear();
                }
                fishSpawnInCurrentPhase.Add("F03");
                fishSpawnInCurrentPhase.Add("F04");
                fishSpawnInCurrentPhase.Add("F05");
                fishSpawnInCurrentPhase.Add("F06");
                fishSpawnInCurrentPhase.Add("F07");
                break;
            case MoonPhases.Phases.FullMoon:
                if (fishSpawnInCurrentPhase != null)
                {
                    fishSpawnInCurrentPhase.Clear();
                }
                fishSpawnInCurrentPhase.Add("F04");
                fishSpawnInCurrentPhase.Add("F06");
                fishSpawnInCurrentPhase.Add("F08");
                fishSpawnInCurrentPhase.Add("F09");
                fishSpawnInCurrentPhase.Add("F10");
                break;

        }
    }

}
