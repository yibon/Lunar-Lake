using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
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

    private void Start()
    {
        lineRend.positionCount = length;
        segmentPoses = new Vector3[length];
        segmentV = new Vector3[length];
        targetDir.position = new Vector3(-4.00f, 1.6f, 0);

        StartCoroutine(Casting());

    }

    private void Update()
    {
        //segmentPoses[0] = targetDir.position;

        for (int i = 1; i < segmentPoses.Length; i++)
        {
            segmentPoses[i] = Vector3.SmoothDamp(segmentPoses[i], segmentPoses[i - 1] + targetDir.right * targetDist, ref segmentV[i], smoothSpeed);
        }

        lineRend.SetPositions(segmentPoses);
    }

    private IEnumerator Casting()
    {
        Debug.Log(targetDir.position);

        // Start Casting
        Debug.Log("Start Casting");
        segmentPoses[0] = targetDir.position;
        yield return new WaitForSeconds(0.5f);

        // Pull back the rod
        Debug.Log("Pull Back Rod");

        Vector3 interval;
        Vector3 halfwayPos = new Vector3(-6f, 2.4f, 0);
        Vector3 targetPos = new Vector3(-8.00f, 1.60f, 0);

        while (targetDir.position != targetPos)
        {
            while (targetDir.position != halfwayPos)
            {
                interval = new Vector3(-0.05f, 0.02f, 0);
            }

            interval = new Vector3(-0.05f, -0.02f, 0);
            

            targetDir.position += interval;
            Debug.Log(targetDir.position);
            yield return null;
            segmentPoses[0] = targetDir.position;
        }

        //interval = new Vector3(-0.05f, -0.02f, 0);

        //while (targetDir.position != targetPos)
        //{
        //    targetDir.position += interval;
        //    Debug.Log(targetDir.position + "||" + targetPos);
        //    yield return null;
        //    segmentPoses[0] = targetDir.position;
        //}

        yield return new WaitForSeconds(1f);


        // Launch the rod
        Debug.Log("Launch");
        segmentPoses[0] = targetDir.position;
        yield return new WaitForSeconds(1f);

    }

}
