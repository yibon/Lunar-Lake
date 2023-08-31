using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMovement : MonoBehaviour
{
    private float horizontalIP;
    private Vector2 direction;

    public float boatSpeed;

    // Update is called once per frame
    void Update()
    {
        horizontalIP = Input.GetAxisRaw("Horizontal");
        direction = new Vector2(horizontalIP, 0);

    }

    private void FixedUpdate()
    {

        transform.position += (Vector3)direction * Time.deltaTime * boatSpeed;
    }
}
