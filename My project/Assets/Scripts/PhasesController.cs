using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class PhasesController : MonoBehaviour
{
    public static MoonPhases.Phases currMoonPhase;

    [SerializeField] GameObject newMoonAssets;
    [SerializeField] GameObject halfMoonAssets;
    [SerializeField] GameObject fullMoonAssets;

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
    }

}
