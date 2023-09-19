using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rod : MonoBehaviour
{
    LineRenderer LR;

    [SerializeField] Transform fisherman;
    [SerializeField] LineRenderer fishingLine;

    public Transform targetDir;

    Vector3 rodVector;


    private void Start()
    {
        LR = GetComponent<LineRenderer>();
        LR.positionCount = 2;
    }

    void Update()
    {
        rodVector.x = Mathf.Clamp(fishingLine.GetPosition(0).x, fisherman.position.x + 1f, fisherman.position.x + 2f);
        rodVector.y = Mathf.Clamp(fishingLine.GetPosition(0).y, fisherman.position.y + 1f, fisherman.position.y + 2f);

        //Debug.Log(rodVector);

        //rodVector = fishingLine.GetPosition(0);

        LR.SetPosition(0, (fisherman.position + new Vector3 (1f, 0, 0f)));
        LR.SetPosition(1, rodVector);
    }
}
