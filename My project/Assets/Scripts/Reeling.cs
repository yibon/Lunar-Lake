using System.Collections;
using UnityEngine;

public class Reeling : MonoBehaviour
{
    bool fishCaught;
    [SerializeField] GameObject fishCaught_text;

    private void Update()
    {
        //Debug.Log("hhhhhhh");
        if (fishCaught)
        {
            GameStateManager.currGameState = States.GameStates.Catching;
            fishCaught = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
            Debug.Log("HAAAAH");
        if (collision.gameObject.CompareTag("Fish"))
        {
            // this is only called once 
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
