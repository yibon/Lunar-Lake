using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsManager : MonoBehaviour
{

    public static Vector3 initPt;
    public static Vector3 halfwayPt;
    public static Vector3 initInterPt;
    public static Vector3 fishingInterPt;
    public static Vector3 castedPt;
    //public static Vector3 endPt;

    public static Vector3 fishermanHands;

    // Update is called once per frame
    void Update()
    {
        initPt = this.transform.position + new Vector3(2.5f, -0.6f, 0);

        halfwayPt = this.transform.position + new Vector3(-1.4f, 1.5f, 0);
        castedPt = this.transform.position + new Vector3(8f, -1.8f, 0);

        initInterPt = this.transform.position + new Vector3(-0.2f, 2.7f, 0);
        fishingInterPt = this.transform.position + new Vector3(8.8f, 8.4f, 0);

        //endPt = this.transform.position + new Vector3(8f, -10f, 0);

        fishermanHands = this.transform.position + new Vector3(0.85f, 0f, 0f);
    }
}
