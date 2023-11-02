using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMovement : MonoBehaviour
{
    private float horizontalIP;
    private Vector2 direction;

    public float boatSpeed;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame  
    void Update()
    {
        if (GameStateManager.currGameState == States.GameStates.Ready)
        {
            horizontalIP = Input.GetAxisRaw("Horizontal");
            direction = new Vector2(horizontalIP, 0);
        }

        else
        {
            direction = Vector2.zero;
        }
    }

    private void FixedUpdate()
    {
        rb.AddForce(direction * boatSpeed);
    }
}
