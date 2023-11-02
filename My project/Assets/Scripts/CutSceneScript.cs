using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class CutSceneScript : MonoBehaviour
{
    // Start is called before the first frame 
    public VideoPlayer player;
    double duration;
    double currDuration;
    void Start()
    {
        Debug.Log(player.length);
        duration = 0;
    }

    // Update is called once per frame
    void Update()
    {
        duration += Time.deltaTime;
        //Debug.Log(duration);
        if (player.length > duration)
        {
            return;
        }
        if (player.length < duration) {
            LevelLoader.instance.LoadNextLevel();
            return;
        }
    }

}

