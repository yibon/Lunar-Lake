using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rod : MonoBehaviour
{
    LineRenderer LR;

    [SerializeField] Transform fisherman;
    [SerializeField] LineRenderer fishingLine;

    public static Vector3 rodVector;

    public static float rodInterpolateAmt;

    private void Start()
    {
        LR = GetComponent<LineRenderer>();
        LR.positionCount = 2;
    }

    void Update()
    {
        LR.SetPosition(0, PointsManager.fishermanHands);
    }

    private void FixedUpdate()
    {
        Vector3 pointAB;
        Vector3 pointBC;

        if (GameStateManager.currGameState == States.GameStates.Casting)
        {
            //Debug.Log(rodInterpolateAmt);
            rodInterpolateAmt += Time.deltaTime;

            if (!Line.isHalfway)
            {
                pointAB = Vector3.Lerp(PointsManager.rodStartPt, PointsManager.rodIntPt, rodInterpolateAmt);
                pointBC = Vector3.Lerp(PointsManager.rodIntPt, PointsManager.rodEndPt, rodInterpolateAmt);
            }

            else
            {
                pointAB = Vector3.Lerp(PointsManager.rodEndPt, PointsManager.rodIntPt, rodInterpolateAmt);
                pointBC = Vector3.Lerp(PointsManager.rodIntPt, PointsManager.rodStartPt, rodInterpolateAmt);

            }    

            rodVector = Vector3.Lerp(pointAB, pointBC, rodInterpolateAmt);
        }

        else
        {
            rodVector = PointsManager.rodStartPt;
        }


        LR.SetPosition(1, rodVector);
    }
}
