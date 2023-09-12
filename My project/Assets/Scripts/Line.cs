using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;

public class Line : MonoBehaviour
{
    public int length;
    public LineRenderer lineRend;
    public Vector3[] segmentPoses;
    private Vector3[] segmentV;

    public Transform targetDir;
    public float targetDist;
    public float smoothSpeed;

    [SerializeField] private Transform initPos;
    [SerializeField] private Transform targetPos;
    [SerializeField] private Transform interpolatePt;

    private float interpolateAmt;
    [SerializeField] Transform flowPoint;

    bool isCasting;
    bool temp = false;

    int flag = 0;

    private void Start()
    {
        lineRend.positionCount = length;
        segmentPoses = new Vector3[length];
        segmentV = new Vector3[length];

        //initPos = new Vector3(0f, 1.6f, 0);
        //interpolatePt = new Vector3(-8f, 4f, 0); 
        //targetPos = new Vector3 (-6f, 4.5f, 0);

        targetDir.position = initPos.position;

        //StartCoroutine(Casting());

    }

    private void Update()
    {
        segmentPoses[0] = targetDir.position;

        if (Input.GetMouseButton(0))
        {
            isCasting = true;
        }

        for (int i = 1; i < segmentPoses.Length; i++)
        {
            segmentPoses[i] = Vector3.SmoothDamp(segmentPoses[i], segmentPoses[i - 1] + targetDir.right * targetDist, ref segmentV[i], smoothSpeed);
        }

        lineRend.SetPositions(segmentPoses);
    }

    private void FixedUpdate()
    {
        if (isCasting)
        {
            //Debug.Log(interpolateAmt);
            interpolateAmt = (interpolateAmt + Time.deltaTime);
            Vector3 pointAB;
            Vector3 pointBC;

            if (targetDir.position == targetPos.position)
            {
                temp = true;
                // This value CANNOT be equals to zero
                interpolateAmt = 0.01f;
            }


            if (temp)
            {
                //interpolateAmt = 0;
                pointAB = Vector3.Lerp(targetPos.position, interpolatePt.position, interpolateAmt);
                pointBC = Vector3.Lerp(interpolatePt.position, initPos.position, interpolateAmt);

                targetDir.position = Vector3.Lerp(pointAB, pointBC, interpolateAmt);
                flowPoint.position = Vector3.Lerp(pointAB, pointBC, interpolateAmt);
                //isCasting = false;
            }

            else
            {
                pointAB = Vector3.Lerp(initPos.position, interpolatePt.position, interpolateAmt);
                pointBC = Vector3.Lerp(interpolatePt.position, targetPos.position, interpolateAmt);

                targetDir.position = Vector3.Lerp(pointAB, pointBC, interpolateAmt);
                flowPoint.position = Vector3.Lerp(pointAB, pointBC, interpolateAmt);
            }
        }
    }

        //private IEnumerator Casting()
        //{
        //    //Debug.Log(targetDir.position);
        //    isCasting = false;

        //    // Start Casting
        //    Debug.Log("Start Casting");
        //    segmentPoses[0] = targetDir.position;
        //    yield return new WaitForSeconds(1f);

        //    // Pull back the rod
        //    Debug.Log("Pull Back Rod");
        //    yield return new WaitForSeconds(3f);


        //    // Launch the rod
        //    //Debug.Log("Launch");
        //    //targetDir.position = QuadraticLerp(targetPos, interpolatePt, initPos, interpolateAmt);
        //    //Debug.Log(targetDir.position);

        //}

        //private Vector3 QuadraticLerp(Vector3 a, Vector3 b, Vector3  c, float t)
        //{
        //    Vector3 ab = Vector3.Lerp(a, b, t);
        //    Vector3 bc = Vector3.Lerp(b, c, t);

        //    return Vector3.Lerp(ab, bc, interpolateAmt);
        //}

    }
