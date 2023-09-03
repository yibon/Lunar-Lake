using System.Collections;
using System.Collections.Generic;
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

    bool isFishing;
    bool isHooking;

    private void Start()
    {
        fishSpeed = 2f;
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
    }

    private void FixedUpdate()
    {
        fishTimer -= Time.deltaTime;
        if (fishTimer < 0f)
        {
            isFishing = false;
        }

        Hooking(isHooking);
    }

    private void Hooking (bool Hooked)
    {
        if (Hooked)
        {
            hookPullVelocity += hookPullPower * Time.deltaTime;
        }

        else
        {
            hookPullVelocity -= hookGravityPower * Time.deltaTime;
        }

        hookPos += hookPullVelocity;
        hookPos = Mathf.Clamp(hookPos, 0, 1);
        hook.position = Vector3.Lerp(bottomPivot.position, topPivot.position, hookPos);
    }

}
