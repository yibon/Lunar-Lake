using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public static States.GameStates currGameState;

    [SerializeField] GameObject fishingMinigame;
    [SerializeField] GameObject caughtText;

    [SerializeField] Transform targetDir;
    [SerializeField] Transform fish;

    [SerializeField] TMP_Text noOfFish_Text;

    public Line _line;

    private void Start()
    {
        currGameState = States.GameStates.Ready;
    }

    // Update is called once per frame
    void Update()
    {
         //Debug.Log("Current Game State: " + currGameState);

         switch (currGameState)
         {
            case States.GameStates.Ready:
                _line.ResetPos();
                break;

            case States.GameStates.Catching:
                targetDir.position = targetDir.position;
                fishingMinigame.SetActive(true);
                break;
               
            case States.GameStates.Caught:
                StartCoroutine(FishCaught());
                break;
         }
    }


    IEnumerator FishCaught()
    {
        fishingMinigame.SetActive(false);
        caughtText.SetActive(true);
        Time.timeScale = 0f;
        yield return new WaitForSecondsRealtime(0.5f);

        Time.timeScale = 1;
        targetDir.position = Vector3.MoveTowards(targetDir.position, PointsManager.initPt, 0.1f);
        
        if (targetDir.position == PointsManager.initPt)
        {
            caughtText.SetActive(false);
            currGameState = States.GameStates.Ready;
        }

    }
}
