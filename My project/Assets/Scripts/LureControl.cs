using System.Collections;
using UnityEngine;

public class LureControl : MonoBehaviour
{
    bool fishCaught;
    [SerializeField] GameObject fishCaught_text;
    public static bool waterEntered;
    AudioManager _audioManager;
    [SerializeField] GameStateManager _gsm;

    private void Start()
    {
        _audioManager = FindObjectOfType<AudioManager>();
        _gsm = FindObjectOfType<GameStateManager>();
        waterEntered = false;
    }

    private void Update()
    {
        Debug.Log(waterEntered);
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
            Fishing.caughtFish = collision.gameObject.GetComponent<FishBehaviour>()._fish;
            _gsm.GetCollidedFishObj(collision);
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
}
