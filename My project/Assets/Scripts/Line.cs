using System;
using UnityEngine;

public class Line : MonoBehaviour
{
    //public int initlength;
    public int length;
    public LineRenderer lineRend;
    public Vector3[] segmentPoses;
    private Vector3[] segmentV;

    public Transform targetDir;
    public float targetDist;
    public float smoothSpeed;

    [SerializeField] private Transform fisherman;

    private float interpolateAmt;
    private float lureSpeed;
    [SerializeField] Transform flowPoint;

    public static Vector3 reelingMag;

    public static bool isReeling;
    bool isHalfway = false;


    private void Start()
    {
        lineRend.positionCount = length;
        segmentPoses = new Vector3[length];
        segmentV = new Vector3[length];
        ResetPos();
    }

    private void Update()
    {
        flowPoint.position = targetDir.position;

        if (Input.GetMouseButton(0) && GameStateManager.currGameState == States.GameStates.Ready)
        {
            GameStateManager.currGameState = States.GameStates.Casting;
        }

        if (Input.GetMouseButton(0) && GameStateManager.currGameState == States.GameStates.Casting && LureControl.waterEntered)
        {
            isReeling = true;
        }

        else
        {
            isReeling = false;
        }

        if (GameStateManager.currGameState == States.GameStates.Casting || GameStateManager.currGameState == States.GameStates.Catching)
        {
            segmentPoses[length - 1] = targetDir.position;

            for (int i = segmentPoses.Length - 2; i >= 0; i--)
            {
                // Maintaining a constant length
                Vector3 endingPos = segmentPoses[i + 1] + (segmentPoses[i] - segmentPoses[i + 1]).normalized * targetDist;

                // Simulating
                segmentPoses[i] = Vector3.SmoothDamp(segmentPoses[i], endingPos, ref segmentV[i], smoothSpeed);
            }
        }

        else
        {
            ResetPos();
        }

        lineRend.SetPositions(segmentPoses);
    }

    private void FixedUpdate()
    {
        if (GameStateManager.currGameState == States.GameStates.Casting || GameStateManager.currGameState == States.GameStates.Reeling)
        {
            interpolateAmt = (interpolateAmt + Time.deltaTime * lureSpeed);
            Vector3 pointAB;
            Vector3 pointBC;

            if (targetDir.position == PointsManager.halfwayPt)
            {
                isHalfway = true;
                // This value CANNOT be equals to zero
                interpolateAmt = 0.01f;
            }

            if (isHalfway)
            {
                pointAB = Vector3.Lerp(PointsManager.halfwayPt, PointsManager.fishingInterPt, interpolateAmt);
                pointBC = Vector3.Lerp(PointsManager.fishingInterPt, PointsManager.fishingPt, interpolateAmt);

                targetDir.position = Vector3.Lerp(pointAB, pointBC, interpolateAmt);
            }

            else
            {
                pointAB = Vector3.Lerp(PointsManager.initPt, PointsManager.initInterPt, interpolateAmt);
                pointBC = Vector3.Lerp(PointsManager.initInterPt, PointsManager.halfwayPt, interpolateAmt);

                targetDir.position = Vector3.Lerp(pointAB, pointBC, interpolateAmt);
            }

            if (LureControl.waterEntered)
            {
                lureSpeed = 0.1f;
            }

            else
            {
                lureSpeed = 0.65f;
            }

            if (isReeling)
            {
                PointsManager.fishingPt = Vector3.MoveTowards(PointsManager.fishingPt, PointsManager.initPt, 0.1f);


            }
        }
    }

    public void ResetPos()
    {
        interpolateAmt = 0.01f;
        targetDir.position = PointsManager.initPt;
        segmentPoses[0] = targetDir.position;

        for (int i = 1; i < length; i++)
        {
            segmentPoses[i] = segmentPoses[i - 1] + targetDir.right  * targetDist;
        }

        isReeling = false;
        LureControl.waterEntered = false;
        lureSpeed = 0.65f;
        lineRend.SetPositions(segmentPoses);
    }
}
