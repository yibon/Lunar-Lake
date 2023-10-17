using System.Collections;
using UnityEngine;

public class LureControl : MonoBehaviour
{
    bool fishCaught;
    [SerializeField] GameObject fishCaught_text;
    public static bool waterEntered;
    AudioManager _audioManager;


    private void Start()
    {
        _audioManager = FindObjectOfType<AudioManager>();
        waterEntered = false;
    }

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
            fishCaught = true;
            StartCoroutine(FishDestroyer(collision));

        }

        if (collision.gameObject.CompareTag("WaterLine"))
        {
            if (!waterEntered)
            {
                _audioManager.Play("Bloop SFX");
                waterEntered = true;
            }

            else
            {
                waterEntered = false;
            }
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
