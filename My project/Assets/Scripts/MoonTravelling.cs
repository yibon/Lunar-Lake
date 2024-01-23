using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoonTravelling : MonoBehaviour
{
    private Vector2 endPosition;
    private Vector2 startPosition;

    Vector2 displacement; 

    private float maxTime = 540; // 9 minutes in seconds
    private float timeIntervals;

    public static float spawnIntervals = 60; // 10 seconds spawn time
    
    Rigidbody2D rb;

    private float gameTimer = 0;
    private float spawnTimer = 0;
    public static bool isSpawning;

    Spawner _spawner;

    private void Awake()
    {
       startPosition = transform.position;
       endPosition = new Vector2(18f, startPosition.y);

       displacement = endPosition - startPosition;
    }

    // Start is called before the first frame update
    void Start()
    {
        timeIntervals = maxTime / 3; 
        rb = GetComponent<Rigidbody2D>();
        _spawner = Spawner.Instance;
    }

    // Update is called once per frame
    void Update()
    { 
        Debug.Log(spawnTimer);

        gameTimer += Time.deltaTime;

        if (GameStateManager.currGameState != States.GameStates.Catching ||
            GameStateManager.currGameState != States.GameStates.Caught ||
            GameStateManager.currGameState != States.GameStates.FailedToCatch)
        {
            spawnTimer += Time.deltaTime;
        }

        if (gameTimer < maxTime) 
        {
            rb.velocity = displacement / maxTime;
            //Vector2 velocity = displacement / maxTime;
            //transform.position += new Vector3(velocity.x, 0f);
        }

        if (gameTimer > timeIntervals && gameTimer < timeIntervals * 2)
        {
            PhasesController.currMoonPhase = MoonPhases.Phases.HalfMoon;
            Debug.Log("Half Moon Phase");
        }

        if (gameTimer > timeIntervals * 2 && gameTimer < maxTime)
        {
            PhasesController.currMoonPhase = MoonPhases.Phases.FullMoon;
            Debug.Log("Full Moon Phase");
        }

        if (gameTimer > maxTime)
        {
            Debug.Log("GAME ENDS");
        }
        
        if (spawnTimer > spawnIntervals)
        {
            if (!isSpawning)
            {
                //Debug.Log("arlo" + spawnTimer);
                spawnTimer = 0;
                isSpawning = true; 
            }

        }

        else
        {
            isSpawning = false;
        }

    }
}
