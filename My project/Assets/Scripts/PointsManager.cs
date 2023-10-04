using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsManager : MonoBehaviour
{
    public static Vector3 initPt;
    public static Vector3 halfwayPt;
    public static Vector3 initInterPt;
    public static Vector3 fishingInterPt;
    public static Vector3 fishingPt;


    public static Vector3 fishermanHands;

    // Update is called once per frame
    void Update()
    {
        initPt = this.transform.position + new Vector3(2.5f, -0.6f, 0);
        halfwayPt = this.transform.position + new Vector3(-5.3f, 1.8f, 0);
        initInterPt = this.transform.position + new Vector3(-2.2f, 4.2f, 0);
        fishingInterPt = this.transform.position + new Vector3(8.8f, 8.4f, 0);

        if (!Line.isReeling)
        {
            fishingPt = this.transform.position + new Vector3(8f, -10f, 0);
        }

        fishermanHands = this.transform.position + new Vector3(0.85f, 0f, 0f);
    }
}
