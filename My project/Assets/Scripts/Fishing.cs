using System.Net.Http.Headers;
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
    [SerializeField] float hookSize = 0.1f;
    [SerializeField] float hookPower  = 0.5f;
    float hookProgress;
    float hookPullVelocity;
    [SerializeField] float hookPullPower = 0.01f;
    [SerializeField] float hookGravityPower = 0.005f;
    [SerializeField] float hookProgressDegradPower = 0.1f;

    [SerializeField] SpriteRenderer hookSR;
    [SerializeField] Transform progressBarContainer;

    public static int fishesCaught;

    float failTimer = 10f;

    bool isFishing;
    bool isHooking;
    bool isReeling;
    bool fishCaught;

    // Replace these with dynamic data in the future
    float fishState1_Timer;
    float fishState2_Timer;
    float fishState3_Timer;

    FishStates currFishState;

    private void Start()
    {
        fishSpeed = 2f;
        fishState1_Timer = 2f;
        fishState2_Timer = 4f;
        fishState3_Timer = 3f;

        pointTimer = fishState1_Timer;
        fishDestination = 0.8f;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(pointTimer);
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

        if (failTimer < 0f)
        {
            Lose();
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
            failTimer -= Time.deltaTime;
        }
        
        if (pointTimer < 0f)
        { 
            switch (currFishState)
            {
                case FishStates.state1:
                    currFishState = FishStates.state2;
                    pointTimer = fishState1_Timer;

                    // replace these with dynamic data
                    fishDestination = 0.8f;

                    Debug.Log("State Changed");
                    break;
                case FishStates.state2:
                    currFishState = FishStates.state3;
                    pointTimer = fishState2_Timer;

                    // replace these with dynamic data
                    fishDestination = 0.7f;

                    Debug.Log("State Changed");
                    break;
                case FishStates.state3:
                    currFishState = FishStates.state1;
                    pointTimer = fishState3_Timer;

                    // replace these with dynamic data
                    fishDestination = 0.5f;

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
            hookPullVelocity += hookPullPower * Time.deltaTime;
            failTimer = 10f;
        }

        else
        {
            hookPullVelocity -= hookGravityPower * Time.deltaTime;
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

        if (hookProgress >= 1f)
        {
            fishesCaught++;
            GameStateManager.currGameState = States.GameStates.Caught;
            hookProgress = 0;
        }

    }

    private void Lose()
    {
        Debug.Log("You Lost");
    }


    enum FishStates
    { 
        state1,
        state2,
        state3
    }
}
