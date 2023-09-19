using UnityEngine;

public class FishBehaviour : MonoBehaviour
{
    Vector3 startPoint;
    Vector3 endPoint;
    Vector3 travelDist;

    float travelAmt;
    float travelVelocity;

    bool movingLeft;
    bool movingRight;

    SpriteRenderer fishSR;

    void Start()
    {
        travelDist = new Vector3(1.5f, 0f, 0f);

        startPoint = this.gameObject.transform.position + travelDist;
        endPoint = this.gameObject.transform.position - travelDist;

        travelVelocity = 0.5f;

        fishSR = this.gameObject.GetComponent<SpriteRenderer>();

        this.transform.position = startPoint;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GameStateManager.currGameState == States.GameStates.Ready || GameStateManager.currGameState == States.GameStates.Casting)
        {
            travelAmt = (travelAmt + Time.deltaTime * travelVelocity);
            
            if (transform.position.x == startPoint.x)
            {
                movingRight = false;
                movingLeft = true;
                travelAmt = 0.01f;
            }

            if (transform.position.x == endPoint.x)
            {
                movingRight = true;
                movingLeft = false;
                travelAmt = 0.01f;
            }

            if (movingLeft)
            {
                fishSR.flipX = false;
                this.transform.position = Vector3.Lerp(startPoint, endPoint, travelAmt);
            }

            if (movingRight)
            {
                fishSR.flipX = true ;
                this.transform.position = Vector3.Lerp(endPoint, startPoint, travelAmt);
            }
        }
    }
}
