using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonTravelling : MonoBehaviour
{
    private Vector2 endPosition;
    private Vector2 startPosition;

    private float maxTime = 540; // 9 minutes in seconds
    private float timeIntervals;

    float timer = 0;
    private void Awake()
    {
       endPosition = new Vector2(16.63f, 0f);
       startPosition = transform.position;
    }

    // Start is called before the first frame update
    void Start()
    {
        timeIntervals = maxTime / 3; 
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 displacement = endPosition - startPosition;

        timer += Time.deltaTime;
        if (timer < maxTime) 
        {
            Vector2 velocity = displacement / maxTime;
            transform.position += new Vector3(velocity.x, 0f);
        }
        
    }
}
