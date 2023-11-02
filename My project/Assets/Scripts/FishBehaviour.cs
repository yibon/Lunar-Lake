using UnityEditor;
using UnityEngine;

public class FishBehaviour : MonoBehaviour
{
    Vector3 startPoint;
    Vector3 endPoint;
    Vector3 travelDist;

    float travelAmt;

    [SerializeField]
    public float travelVelocity;
    public string currFishId;
    public DataManager _dm;

    bool movingLeft;
    bool movingRight;

    SpriteRenderer fishSR;

    public FishStatus _fish;

    void Start()
    {
        travelDist = new Vector3(2f, 0f, 0f);

        startPoint = this.gameObject.transform.position + travelDist;
        endPoint = this.gameObject.transform.position - travelDist;


        fishSR = this.gameObject.GetComponent<SpriteRenderer>();
        _dm = FindObjectOfType<DataManager>();

        this.transform.position = startPoint;

        _fish = _dm.FishDataByID(currFishId);
        travelVelocity = _fish.fishSpeed;

        Debug.Log("Speed" + _fish.fishSpeed);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        FishMovement();

    }

    private void Update()
    {
        SetSprite();

    }

    private void FishMovement()
    {
        if (GameStateManager.currGameState == States.GameStates.Ready ||
            GameStateManager.currGameState == States.GameStates.Casting ||
            GameStateManager.currGameState == States.GameStates.Reeling
            )
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
                //fishSR.flipX = false;
                gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);

                this.transform.position = Vector3.Lerp(startPoint, endPoint, travelAmt);
            }

            if (movingRight)
            {
                //fishSR.flipX = true;
                gameObject.transform.rotation = new Quaternion(0, 1, 0, 0);
                this.transform.position = Vector3.Lerp(endPoint, startPoint, travelAmt);
            }
        }
    }

    public void SetSprite()
    {
        switch (currFishId)
        {
            case "F01":
                this.GetComponent<Animator>().SetFloat("SpriteArrayIndex", 0);
                Debug.Log(currFishId);
                break;
            case "F02":
                this.GetComponent<Animator>().SetFloat("SpriteArrayIndex", 1);
                Debug.Log(currFishId);
                break;
            case "F03":
                this.GetComponent<Animator>().SetFloat("SpriteArrayIndex", 2);
                Debug.Log(currFishId);
                break;
            case "F04":
                this.GetComponent<Animator>().SetFloat("SpriteArrayIndex", 3);
                Debug.Log(currFishId);
                break;
            case "F05":
                this.GetComponent<Animator>().SetFloat("SpriteArrayIndex", 4);
                Debug.Log(currFishId);
                break;
            case "F06":
                this.GetComponent<Animator>().SetFloat("SpriteArrayIndex", 5);
                Debug.Log(currFishId);
                break;
            case "F07":
                this.GetComponent<Animator>().SetFloat("SpriteArrayIndex", 6);
                Debug.Log(currFishId);
                break;
            case "F08":
                this.GetComponent<Animator>().SetFloat("SpriteArrayIndex", 7);
                Debug.Log(currFishId);
                break;
            case "F09":
                this.GetComponent<Animator>().SetFloat("SpriteArrayIndex", 8);
                Debug.Log(currFishId);
                break;
            case "F10":
                this.GetComponent<Animator>().SetFloat("SpriteArrayIndex", 9);
                Debug.Log(currFishId);
                break;
        }
    }

}
