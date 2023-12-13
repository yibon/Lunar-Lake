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

    [SerializeField] Minigame _minigame;

    AudioManager _am;
    public Line _line;

    private bool reeling_PlayOnce;

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        currGameState = States.GameStates.Ready;

        _am = FindObjectOfType<AudioManager>();
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
        reeling_PlayOnce = false;
        fishingMinigame.SetActive(false);
        textObj.SetActive(true);
        Time.timeScale = 0f;
        yield return new WaitForSecondsRealtime(0.5f);

        Time.timeScale = 1;
        ResetPos();

        if (targetDir.position == PointsManager.initPt)
        {
            textObj.SetActive(false);
            currGameState = States.GameStates.Ready;
        }

    }

    IEnumerator FishCaught()
    {
        reeling_PlayOnce = false;
        fishingMinigame.SetActive(false);
        textObj.SetActive(true);
        Time.timeScale = 0f;
        yield return new WaitForSecondsRealtime(1f);
        Destroy(caughtFish);
        ResetPos();

        Time.timeScale = 1;
        
        if (targetDir.position == PointsManager.initPt)
        {
            textObj.SetActive(false);
            currGameState = States.GameStates.Ready;
            _minigame.Resize();
        }

    }

    public void GetCollidedFishObj(Collider2D fishcollider)
    {
        caughtFish = fishcollider.gameObject;
    }

    public void ResetPos()
    {
        targetDir.position = Vector3.MoveTowards(targetDir.position, PointsManager.initPt, 0.1f);
        if (!reeling_PlayOnce)
        {
            _am.Play("Retracting");
            reeling_PlayOnce = true;
        }
    }
}
