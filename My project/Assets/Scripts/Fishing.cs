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

    bool isFishing;

    private void Start()
    {
        fishSpeed = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isFishing)
        {
            Debug.Log("hello");
            fishTimer = Random.value * timerMultiplicator;
            fishDestination = Random.value;
        }

        fishPos = Mathf.SmoothDamp(fishPos, fishDestination, ref fishSpeed, smoothMotion);
        fish.position = Vector3.Lerp(bottomPivot.position, topPivot.position, fishPos);
    }

    private void FixedUpdate()
    {
        fishTimer -= Time.deltaTime;
        if (fishTimer < 0f)
        {
            isFishing = false;
        }
    }
}
