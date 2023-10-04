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
        //Debug.Log(currGameState);

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
        caughtText.SetActive(true);
        Time.timeScale = 0f;
        yield return new WaitForSecondsRealtime(2f);

        Time.timeScale = 1;
        caughtText.SetActive(false);
        fishingMinigame.SetActive(false);
    
        noOfFish_Text.text = "Number of Fishes Caught: " + Fishing.fishesCaught;
        currGameState = States.GameStates.Ready;

    }

    
}
