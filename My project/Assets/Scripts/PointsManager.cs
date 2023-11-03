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

    public static Vector3 rodStartPt;
    public static Vector3 rodEndPt;
    public static Vector3 rodIntPt;

    public static Vector3 spawnPtA  = new Vector3(3f, -6f, 0f);
    public static Vector3 spawnPtB = new Vector3(-4f, -5f, 0f);
    public static Vector3 spawnPtC = new Vector3(0f, -9f, 0f);
    public static Vector3 spawnPtD;
    public static Vector3 spawnPtE;

    public static float castedPtExtend;

    // Update is called once per frame

    private void Start()
    {
        castedPtExtend = 8.2f;

    }
    void Update()
    { 
        initPt = this.transform.position + new Vector3(2.5f, -0.6f, 0);

        halfwayPt = this.transform.position + new Vector3(-1.4f, 1.5f, 0);
        castedPt = this.transform.position + new Vector3(castedPtExtend, -1.8f, 0);

        initInterPt = this.transform.position + new Vector3(-0.2f, 2.7f, 0);
        fishingInterPt = this.transform.position + new Vector3(8.8f, 8.4f, 0);

        fishermanHands = this.transform.position + new Vector3(0.85f, 0f, 0f);

        rodStartPt = fishermanHands + new Vector3(1.5f, 0.75f, 0f);
        rodEndPt = fishermanHands + new Vector3(-1.5f, 0.75f, 0f);
        rodIntPt = fishermanHands + new Vector3(0f, 1.5f, 0f);

        //Debug.Log(castedPt);
    }
}
