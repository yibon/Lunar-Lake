using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Reeling : MonoBehaviour
{
    bool fishCaught;


    private void Update()
    {
        if (fishCaught)
        {
            GameStateManager.currGameState = States.GameStates.Catching;
            fishCaught = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fish"))
        {
            fishCaught = true;
        }
    }

}
