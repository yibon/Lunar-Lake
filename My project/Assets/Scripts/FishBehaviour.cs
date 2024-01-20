using UnityEditor;
using UnityEngine;
using UnityEngine.XR;

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
    public FishSpawner _spawner;

    void Start()
    {
        fishSR = this.gameObject.GetComponent<SpriteRenderer>();
        _dm = FindObjectOfType<DataManager>();


        _fish = _dm.FishDataByID(currFishId);
        
        travelVelocity = _fish.fishSpeed;
        
        travelDist = new Vector3(GetDistance(currFishId), 0f, 0f);

        startPoint = this.gameObject.transform.position + travelDist;
        endPoint = this.gameObject.transform.position - travelDist;
        
        this.transform.position = startPoint;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        FishMovement();

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

    private float GetDistance(string fishID)
    {
        switch (fishID)
        {
            case "F01":
            case "F02":
            case "F03":
                return GetDistByRarity("Bronze");

            case "F04":
            case "F05":
            case "F06":
                return GetDistByRarity("Silver");

            case "F07":
            case "F08":
                return GetDistByRarity("Gold");

            case "F09":
                return GetDistByRarity("Platinum");

            default:
                return 0;
        }

    }

    private float GetDistByRarity(string rarity)
    {
        float distMinX = _dm.SpawnerDataByRarity(rarity).minXvalue;
        float distMaxX = _dm.SpawnerDataByRarity(rarity).maxXvalue;

        return Random.Range(distMinX, distMaxX);
    }
}
