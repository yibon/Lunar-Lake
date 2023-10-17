using System;
using System.Runtime.Versioning;
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

    private float interpolateAmt;
    private float lureSpeed;
    [SerializeField] Transform flowPoint;

    public static Vector3 reelingMag;

    public static bool isReeling;
    bool isHalfway = false;

    [SerializeField]
    Transform fishPt;

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
        fishPt.position = PointsManager.castedPt;

        if (Input.GetMouseButtonDown(0) && GameStateManager.currGameState == States.GameStates.Ready)
        {
            GameStateManager.currGameState = States.GameStates.Casting;
        }

        if (Input.GetMouseButton(0) && GameStateManager.currGameState == States.GameStates.Reeling)
        {
            isReeling = true;
        }

        else
        {
            isReeling = false;
        }

        if (GameStateManager.currGameState == States.GameStates.Ready)
        {
            ResetPos();
        }

        else
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

        lineRend.SetPositions(segmentPoses);
    }

    private void FixedUpdate()
    {
        // Casting State
        if (GameStateManager.currGameState == States.GameStates.Casting)
        {
            // Set the speed of the lure
            lureSpeed = 0.65f;
            
            // Set the Amount
            interpolateAmt = (interpolateAmt + Time.deltaTime * lureSpeed);

            // Actual Casting 
            CastingAnimation();

            // Chaning state to Reeling
            if (targetDir.position == PointsManager.castedPt)
            {
                GameStateManager.currGameState = States.GameStates.Reeling;
            }
        }

        // Reeling State
        if (GameStateManager.currGameState == States.GameStates.Reeling)
        {
            Vector3 endPt = new Vector3(targetDir.position.x, -15f, 0);

            if (isReeling)
            {
                targetDir.position = Vector3.MoveTowards(targetDir.position, PointsManager.initPt, 0.1f);

                if (targetDir.position == PointsManager.initPt)
                {
                    GameStateManager.currGameState = States.GameStates.Ready;
                }
            }

            else
            {
                targetDir.position = Vector3.MoveTowards(targetDir.position, endPt, Time.deltaTime);
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

        isHalfway = false;
        isReeling = false;
        LureControl.waterEntered = false;
        lureSpeed = 0.65f;
        lineRend.SetPositions(segmentPoses);
    }

    private void CastingAnimation()
    {
        Vector3 pointAB;
        Vector3 pointBC;

        if (targetDir.position == PointsManager.halfwayPt)
        {
            isHalfway = true;

            // This value CANNOT be equals to zero
            interpolateAmt = 0.01f;
        }

        //casting animation code
        if (isHalfway)
        {
            pointAB = Vector3.Lerp(PointsManager.halfwayPt, PointsManager.fishingInterPt, interpolateAmt);
            pointBC = Vector3.Lerp(PointsManager.fishingInterPt, PointsManager.castedPt, interpolateAmt);

            targetDir.position = Vector3.Lerp(pointAB, pointBC, interpolateAmt);
        }

        else
        {
            pointAB = Vector3.Lerp(PointsManager.initPt, PointsManager.initInterPt, interpolateAmt);
            pointBC = Vector3.Lerp(PointsManager.initInterPt, PointsManager.halfwayPt, interpolateAmt);

            targetDir.position = Vector3.Lerp(pointAB, pointBC, interpolateAmt);
        }
    }
}
