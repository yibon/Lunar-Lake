using System.Net.Http.Headers;
using TMPro;
using UnityEngine;

public class Fishing : MonoBehaviour
{
    [SerializeField] Transform topPivot;
    [SerializeField] Transform bottomPivot;

    [SerializeField] Transform fish;

    float fishPos;
    float fishDestination;

    float fishTimer;
    [SerializeField] float timerMultiplicator = 3f;

    float pointTimer;

    float fishSpeed;
    [SerializeField] float smoothMotion = 1f;

    [SerializeField] Transform hook;
    float hookPos;
    [SerializeField] public static float hookSize = 0.1f;
    [SerializeField] float hookPower = 0.5f;
    float hookProgress;
    float hookPullVelocity;
    [SerializeField] float hookPullPower = 0.01f;
    [SerializeField] float hookGravityPower = 0.005f;
    [SerializeField] float hookProgressDegradPower = 0.1f;

    [SerializeField] SpriteRenderer hookSR;
    [SerializeField] Transform progressBarContainer;
    SpriteRenderer progressBarSR;

    public static int fishesCaught;

    //float failTimer = 10f;

    bool isFishing;
    bool isHooking;
    bool isReeling;
    bool fishCaught;

    FishStates currFishState;
    public static FishStatus caughtFish;
    [SerializeField] LogBookDisplay _bookDisp;
    [SerializeField] FishBuffs _buffs;
    [SerializeField] GameObject exclaimationMark;

    Camera cam;

    Vector3 spawnLoc;

    [SerializeField ]Line _line;

    private void Start()
    {
        Resize();
        fishSpeed = 2f;
        pointTimer = caughtFish.fishStateTime_1;
        fishDestination = caughtFish.fishStatePos_1;

        this.transform.position = Camera.main.transform.position + new Vector3(2f, 0, 10f);

        progressBarSR = progressBarContainer.gameObject.GetComponentInChildren<SpriteRenderer>();

        //_line = FindObjectOfType<Line>();
    }

    // Update is called once per frame
    void Update()
    {
        //spawnLoc = Spawner.GetSpawnPoint(caughtFish.fishSpawnLoc);
        //this.transform.position = _line.targetDir.position + new Vector3 (2f, 2.5f, 0);
        this.transform.position = Camera.main.transform.position + new Vector3(2f, 0, 10f);
        //Debug.Log("Hookerzxc" + hookSize);

        if (!isFishing)
        {
            fishTimer = 5;
            //fishDestination = Random.value;
        }

        fishPos = Mathf.SmoothDamp(fishPos, fishDestination, ref fishSpeed, smoothMotion);
        fish.position = Vector3.Lerp(bottomPivot.position, topPivot.position, fishPos);

        if (Input.GetKey(KeyCode.Space))
        {
            isHooking = true;
        }

        else
        {
            isHooking = false;
        }

        ProgressCheck();
    }

    private void FixedUpdate()
    {
        fishTimer -= Time.deltaTime;
        pointTimer -= Time.deltaTime;

        if (fishTimer < 0f)
        {
            isFishing = false;
        }

        if (isReeling)
        {
            hookProgress += hookPower * Time.deltaTime;
        }

        else
        {
            hookProgress -= hookProgressDegradPower * Time.deltaTime;
            //failTimer -= Time.deltaTime;
        }


        if (pointTimer < 0f)
        { 
            switch (currFishState)
            {
                case FishStates.state1:
                    currFishState = FishStates.state2;
                    pointTimer = caughtFish.fishStateTime_1;
                    fishDestination = caughtFish.fishStatePos_1;

                    Debug.Log("State Changed");
                    break;
                case FishStates.state2:
                    currFishState = FishStates.state3;
                    pointTimer = caughtFish.fishStateTime_2;
                    fishDestination = caughtFish.fishStatePos_2;

                    Debug.Log("State Changed");
                    break;
                case FishStates.state3:
                    currFishState = FishStates.state1;
                    pointTimer = caughtFish.fishStateTime_3;
                    fishDestination = caughtFish.fishStatePos_3;

                    Debug.Log("State Changed");
                    break;
            }
        }

        Hooking(isHooking);
    }

    private void Hooking (bool Hooked)
    {

        if (Hooked)
        {
            if (hook.position.y + hookSize * 1.5 <= topPivot.position.y)
            {
                hookPullVelocity += hookPullPower * Time.deltaTime;
            }

            else
            {
                hookPullVelocity = 0;
            }
        }

        else
        {
            if (hook.position.y - hookSize * 1.5 >= bottomPivot.position.y)
            {
                hookPullVelocity -= hookGravityPower * Time.deltaTime;
            }

            else
            {
                hookPullVelocity = 0;
            }
        }

        hookPos += hookPullVelocity;
        hookPos = Mathf.Clamp(hookPos, hookSize/2f , 1f - hookSize / 2f);
        hook.position = Vector3.Lerp(bottomPivot.position, topPivot.position, hookPos);
    }

    private void ProgressCheck()
    {
        Vector3 ls = progressBarContainer.localScale;
        ls.y = hookProgress;
        progressBarContainer.localScale = ls;

        float min = hookPos - hookSize / 2;
        float max = hookPos + hookSize / 2;

        if (min < fishPos && fishPos < max)
        {
            isReeling = true;
        }

        else
        {
            isReeling = false;
        }

        hookProgress = Mathf.Clamp(hookProgress, 0f, 1f);

        #region Colour Change
        if (hookProgress > 0.3f && hookProgress <= 0.7f)
        {
            progressBarSR.color = Color.yellow;
        }

        else if (hookProgress > 0.7f)
        {
            progressBarSR.color = Color.green;
        }

        else
        {
            progressBarSR.color = Color.red;
        }

        #endregion

        if (hookProgress >= 1f)
        {
            fishesCaught++;
            GameStateManager.currGameState = States.GameStates.Caught;
            Player.Instance.FishCaughtAndAddIntoInventory(caughtFish.fishID);
            _bookDisp.UpdateLogBook(caughtFish.fishID);
            _buffs.UpdateBuffs(caughtFish);

            // Reset Stats Here
            //pointTimer = 0;
            hookProgress = 0.45f;
            hookPos = 0f;
            exclaimationMark.SetActive(true);
        }

        if (hookProgress == 0 )
        {
           Lose();
        }

    }

    private void Lose()
    {
        Debug.Log("Lost!");
        GameStateManager.currGameState = States.GameStates.FailedToCatch;
        hookProgress = 0.45f;
        hookPos = 0f;
    }


    enum FishStates
    { 
        state1,
        state2,
        state3
    }

    public void Resize()
    {
        Bounds b = hookSR.bounds;
        float ySize = b.size.y;
        Vector3 ls = hook.localScale;
        float distance = Vector3.Distance(topPivot.position, bottomPivot.position);
        ls.y = distance / ySize  * (hookSize/ 2);
        hook.localScale = ls;

        hookProgress = 0.45f;
        hookPos = 0f;
    }



}
