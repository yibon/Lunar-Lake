using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
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

    float failTimer = 10f;

    bool isFishing;
    bool isHooking;
    bool isReeling;

    private void Start()
    {
        fishSpeed = 2f;
        //Resize();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(isHooking);

        if (!isFishing)
        {
            fishTimer = Random.value * timerMultiplicator;
            fishDestination = Random.value;
        }

        fishPos = Mathf.SmoothDamp(fishPos, fishDestination, ref fishSpeed, smoothMotion);
        fish.position = Vector3.Lerp(bottomPivot.position, topPivot.position, fishPos);

        if (Input.GetMouseButton(0))
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

    //private void Resize()
    //{
    //    Bounds b = hookSR.bounds;
    //    float ySize = b.size.y;
    //    Vector3 ls = hook.localScale;
    //    float distance = Vector3.Distance(topPivot.position, bottomPivot.position);
    //    ls.y = (distance / ySize * hookSize);
    //    hook.localScale = ls;
    //}

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
            Win();
        }

    }

    private void Win()
    {
        Debug.Log("You Won");
    }

    private void Lose()
    {
        Debug.Log("You Lost");
    }

}
