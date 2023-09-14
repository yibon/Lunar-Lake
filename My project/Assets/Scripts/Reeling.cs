using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reeling : MonoBehaviour
{
    bool fishCaught;

    private void Update()
    {
        //Debug.Log(fishCaught);

        if (fishCaught)
        {
            Debug.Log("Fish Caught!");
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
