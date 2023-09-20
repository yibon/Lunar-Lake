using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] Transform fisherMan;
    [SerializeField] Transform endPoint;

    private Vector3 fishermenOffset;
    private Vector3 zaxisAdjustment;

    private float xMinMax;
    private float yMinMax;


    // Start is called before the first frame update
    void Start()
    {
        fishermenOffset = new Vector3(3.6f, -0.7f, 0f);
        zaxisAdjustment = new Vector3(0, 0, -10);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        switch (GameStateManager.currGameState)
        {
            case States.GameStates.Ready:
                transform.position = fisherMan.position + fishermenOffset;
                    break;

            case States.GameStates.Casting:
            case States.GameStates.Catching: 
            case States.GameStates.Reeling:
                transform.position = endPoint.position;
                    break;
        }

        xMinMax = Mathf.Clamp(transform.position.x, -6.5f, -0.7f);
        yMinMax = Mathf.Clamp(transform.position.y, -0.1f, 1.75f);

        transform.position = new Vector3(xMinMax, yMinMax, -10f);
    }
}
