using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Reeling : MonoBehaviour
{
    bool fishCaught;
    [SerializeField] GameObject fishCaught_text;

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
            // this is only called once 
            Debug.Log("HAAAAH");
            fishCaught = true;
            StartCoroutine(FishDestroyer(collision));
        }
    }

    IEnumerator FishDestroyer(Collider2D fishCollider)
    {
        while (!fishCaught_text.activeInHierarchy)
        {
            yield return null;
        }    
        Destroy(fishCollider.gameObject);

    }
}
