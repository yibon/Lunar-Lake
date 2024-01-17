using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonTravelling : MonoBehaviour
{
    private Vector2 endPosition;
    private Vector2 startPosition;

    Vector2 displacement; 

    private float maxTime = 540; // 9 minutes in seconds
    private float timeIntervals;



    Rigidbody2D rb;

    float timer = 0;
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
    }

    // Update is called once per frame
    void Update()
    { 
        Debug.Log(timer);

        timer += Time.deltaTime;
        if (timer < maxTime) 
        {
            rb.velocity = displacement / maxTime;
            //Vector2 velocity = displacement / maxTime;
            //transform.position += new Vector3(velocity.x, 0f);
        }

        if (timer > timeIntervals && timer < timeIntervals * 2)
        {
            PhasesController.currMoonPhase = MoonPhases.Phases.HalfMoon;
            Debug.Log("Half Moon Phase");
        }

        if (timer > timeIntervals * 2 && timer < maxTime)
        {
            PhasesController.currMoonPhase = MoonPhases.Phases.FullMoon;
            Debug.Log("Full Moon Phase");
        }

        if (timer > maxTime)
        {
            Debug.Log("GAME ENDS");
        }


     }
}
