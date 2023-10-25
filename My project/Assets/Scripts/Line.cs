using System;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.EventSystems;

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
    public float trailSpeed;

    private float interpolateAmt;
    private float lureSpeed;
    [SerializeField] Transform flowPoint;

    public static Vector3 reelingMag;

    public static bool isReeling;
    public static bool isHalfway = false;

    AudioManager _am;

    public static float lineDepth;

    //[SerializeField]
    //Transform fishPt;

    private void Start()
    {
        lineRend.positionCount = length;
        segmentPoses = new Vector3[length];
        segmentV = new Vector3[length];

        _am = FindObjectOfType<AudioManager>();
        lineDepth = -15f;

        ResetPos();
    }

    private void Update()
    {
        flowPoint.position = targetDir.position;
        //fishPt.position = PointsManager.castedPt;

        if (Input.GetMouseButtonDown(0) && GameStateManager.currGameState == States.GameStates.Ready)
        {
            if (EventSystem.current.IsPointerOverGameObject()) { return; }
            
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
            segmentPoses[0] = Rod.rodVector;

            for (int i = segmentPoses.Length - 2; i > 0; i--)
            //or (int i = 0; i < length - 1; i++)
            {
                // Maintaining a constant length
                Vector3 endingPos = segmentPoses[i + 1] + (segmentPoses[i] - segmentPoses[i + 1]).normalized * targetDist;
                //segmentPoses[i]  = Vector3.SmoothDamp(segmentPoses[i], segmentPoses[i - 1] + targetDir.right * targetDist, ref segmentV[i], smoothSpeed);

                // Simulating
                segmentPoses[i] = Vector3.SmoothDamp(segmentPoses[i], endingPos, ref segmentV[i], smoothSpeed);
            }

            //segmentPoses[0] = targetDir.position;

            //for (int i = 1; i < length - 1; i++)
            //{
            //    // Maintaining a constant length
            //    Vector3 endingPos = segmentPoses[i - 1] + (segmentPoses[i] - segmentPoses[i - 1]).normalized * targetDist;

            //    // Simulating
            //    segmentPoses[i] = Vector3.SmoothDamp(segmentPoses[i], endingPos, ref segmentV[i], smoothSpeed);
            //}
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
            // Setting the maximum depth 
            Vector3 endPt = new Vector3(targetDir.position.x, lineDepth, 0);

            if (isReeling)
            {
                targetDir.position = Vector3.MoveTowards(targetDir.position, PointsManager.initPt, 0.09f);

                if (targetDir.position == PointsManager.initPt)
                {
                    GameStateManager.currGameState = States.GameStates.Ready;
                }
            }

            else
            {
                _am.Play("Retracting");
                targetDir.position = Vector3.MoveTowards(targetDir.position, endPt, Time.deltaTime);
            }
        }
    }

    public void ResetPos()
    {
        //Debug.Log("Ehet");
        interpolateAmt = 0.01f;

        segmentPoses[0] = targetDir.position;
        targetDir.position = PointsManager.initPt;


        for (int i = 1; i < length - 1; i++)
        {
            segmentPoses[i] = segmentPoses[i - 1] + targetDir.right  * targetDist;
        }

        segmentPoses[length -1] = Rod.rodVector;
        isHalfway = false;
        isReeling = false;
        LureControl.waterEntered = false;
        lureSpeed = 0.65f;
        lineRend.SetPositions(segmentPoses);
        Rod.rodInterpolateAmt = 0.01f;

        _am.Stop("Retracting");
    }

    private void CastingAnimation()
    {
        Vector3 pointAB;
        Vector3 pointBC;

        if (targetDir.position == PointsManager.halfwayPt)
        {
            isHalfway = true;

            // These value CANNOT be equals to zero
            interpolateAmt = 0.01f;
            Rod.rodInterpolateAmt = 0.01f;
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
            _am.Play("Rod Cast");
            pointAB = Vector3.Lerp(PointsManager.initPt, PointsManager.initInterPt, interpolateAmt);
            pointBC = Vector3.Lerp(PointsManager.initInterPt, PointsManager.halfwayPt, interpolateAmt);

            targetDir.position = Vector3.Lerp(pointAB, pointBC, interpolateAmt);
        }
    }
}
