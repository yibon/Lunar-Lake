using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public static States.GameStates currGameState;

    [SerializeField] GameObject fishingMinigame;
    [SerializeField] GameObject textObj;
    TMP_Text caughtText;

    public static GameObject caughtFish;

    [SerializeField] Transform targetDir;
    [SerializeField] Transform fish;

    [SerializeField] Fishing _fishing;

    public Line _line;

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        currGameState = States.GameStates.Ready;

        caughtText = textObj.GetComponent<TMP_Text>(); 
    }

    // Update is called once per frame
    void Update()
    {
         Debug.Log("Current Game State: " + currGameState);

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
                caughtText.text = "cAughT!";
                StartCoroutine(FishCaught());
                break;

            case States.GameStates.FailedToCatch:
                caughtText.text = "FaiLed!";
                StartCoroutine(FishFailed());
                break;
         }
    }

    IEnumerator FishFailed()
    {
        fishingMinigame.SetActive(false);
        textObj.SetActive(true);
        Time.timeScale = 0f;
        yield return new WaitForSecondsRealtime(0.5f);

        Time.timeScale = 1;
        targetDir.position = Vector3.MoveTowards(targetDir.position, PointsManager.initPt, 0.1f);

        if (targetDir.position == PointsManager.initPt)
        {
            textObj.SetActive(false);
            currGameState = States.GameStates.Ready;
        }

    }

    IEnumerator FishCaught()
    {
        fishingMinigame.SetActive(false);
        textObj.SetActive(true);
        Time.timeScale = 0f;
        yield return new WaitForSecondsRealtime(0.5f);

        Time.timeScale = 1;
        targetDir.position = Vector3.MoveTowards(targetDir.position, PointsManager.initPt, 0.1f);
        
        if (targetDir.position == PointsManager.initPt)
        {
            StartCoroutine(FishDestroyer(caughtFish));
            textObj.SetActive(false);
            currGameState = States.GameStates.Ready;
            _fishing.Resize();
        }

    }

    IEnumerator FishDestroyer(GameObject _caughtFish)
    {
        while (!textObj.activeInHierarchy)
        {
            yield return null;
        }

        Destroy(_caughtFish);
    }

    public void GetCollidedFishObj(Collider2D fishcollider)
    {
        caughtFish = fishcollider.gameObject;
    }

}
