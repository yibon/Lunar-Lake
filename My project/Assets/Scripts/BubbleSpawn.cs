using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BubbleSpawn : MonoBehaviour
{
    public static bool aCleared;
    public static bool bCleared;
    public static bool cCleared;

    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(SceneManager.GetActiveScene().name);


        if (SceneManager.GetActiveScene().name == "Level 1")
        {

            if (gameObject.name == "A Bubble")
            {
                this.transform.position = new Vector3(PointsManager.spawnPtA.x, -1.9f, 0);
            }

            if (gameObject.name == "B Bubble")
            {
                this.transform.position = new Vector3(PointsManager.spawnPtB.x, -1.9f, 0);

            }

            if (gameObject.name == "C Bubble")
            {
                this.transform.position = new Vector3(-100, -100, 0);
            }
        }

        if (SceneManager.GetActiveScene().name == "Level 2")
        {

            if (gameObject.name == "A Bubble")
            {
                this.transform.position = new Vector3(PointsManager.spawnPtA.x, -1.9f, 0);
            }

            if (gameObject.name == "B Bubble")
            {
                this.transform.position = new Vector3(PointsManager.spawnPtB.x, -1.9f, 0);

            }

            if (gameObject.name == "C Bubble")
            {
                this.transform.position = new Vector3(PointsManager.spawnPtC.x, -1.9f, 0);
            }
        }

        if (SceneManager.GetActiveScene().name == "Level 3")
        {

            if (gameObject.name == "A Bubble")
            {
                this.transform.position = new Vector3(-100, -100, 0);
            }

            if (gameObject.name == "B Bubble")
            {
                this.transform.position = new Vector3(PointsManager.spawnPtB.x, -1.9f, 0);

            }

            if (gameObject.name == "C Bubble")
            {
                this.transform.position = new Vector3(PointsManager.spawnPtC.x, -1.9f, 0);
            }
        }

    }
}
