using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEditor.UIElements;
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


    [SerializeField] private Transform initPos;
    [SerializeField] private Transform targetPos;
    [SerializeField] private Transform fishingPos;
    [SerializeField] private Transform interpolatePt;
    [SerializeField] private Transform fishingInter;
    [SerializeField] private Transform rodPt;

    [SerializeField] private Transform fisherman;

    private float interpolateAmt;
    [SerializeField] Transform flowPoint;

    bool isCasting;
    bool isHalfway = false;

    private void Start()
    {
        lineRend.positionCount = length;
        segmentPoses = new Vector3[length];
        segmentV = new Vector3[length];
        //segmentPoses[0] = targetDir.position + Vector3.up * targetDist * length;
        ResetPos();


        rodPt.position = new Vector3(0.74f, 4.03f, 0f);
    }

    private void Update()
    {
        ////segmentPoses[1] = fisherman.position + new Vector3 (0.2f, 0.2f, 0);
        //segmentPoses[length - 1] = targetDir.position; // * targetDist * length;
        //Debug.Log(targetDir.position);

        if (Input.GetMouseButton(0))
        {
            isCasting = true;  
        }

        if (isCasting)
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
            segmentPoses[0] = targetDir.position;
            for (int i = 1; i < segmentPoses.Length; i++)
            {
                segmentPoses[i] = Vector3.SmoothDamp(segmentPoses[i], segmentPoses[i - 1] + targetDir.right * targetDist, ref segmentV[i], smoothSpeed);
            }
        }

        lineRend.SetPositions(segmentPoses);
    }

    private void FixedUpdate()
    {
        flowPoint.position = targetDir.position;

        if (isCasting)
        {
            //Debug.Log(interpolateAmt);
            float timer = 0;
            timer += Time.deltaTime;
            //Debug.Log(segmentPoses[1]);

            interpolateAmt = (interpolateAmt + Time.deltaTime * 0.75f);
            Vector3 pointAB;
            Vector3 pointBC;

            if (targetDir.position == targetPos.position)
            {
                isHalfway = true;

                // This value CANNOT be equals to zero
                interpolateAmt = 0.01f;
            }
            
            if (targetDir.position == rodPt.position)
            {
                segmentPoses[1] = rodPt.position;
            }


            if (isHalfway)
            {
                //interpolateAmt = 0;
                pointAB = Vector3.Lerp(targetPos.position, fishingInter.position, interpolateAmt);
                pointBC = Vector3.Lerp(fishingInter.position, fishingPos.position, interpolateAmt);

                targetDir.position = Vector3.Lerp(pointAB, pointBC, interpolateAmt);

            }

            else
            {
                pointAB = Vector3.Lerp(initPos.position, interpolatePt.position, interpolateAmt);
                pointBC = Vector3.Lerp(interpolatePt.position, targetPos.position, interpolateAmt);

                targetDir.position = Vector3.Lerp(pointAB, pointBC, interpolateAmt);
            }
        }
    }

    private void ResetPos()
    {
        segmentPoses[0] = targetDir.position;
        for (int i = 1; i < length; i++)
        {
            segmentPoses[i] = segmentPoses[i - 1] + targetDir.right * targetDist;
        }

        lineRend.SetPositions(segmentPoses);
    }
}
