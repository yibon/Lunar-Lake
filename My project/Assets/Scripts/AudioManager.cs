using UnityEngine.Audio;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    //an array of sounds will be stored here
    public Sounds[] sounds;
    // Start is called before the first frame update

    public static AudioManager instance;

    //bool isPlaying;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(this);
        foreach (Sounds s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.loop = s.loop;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
    }

    private void Start()
    {
        Play("BGM");

        SceneManager.activeSceneChanged += ChangedActiveScene;
    }

    // Update is called once per frame
    public void Play(string name)
    {
        Sounds s = Array.Find(sounds, sound => sound.name == name);
        if (s == null) { return;}

        s.source.Play();
    }    
    
    public void Stop(string name)
    {
        Sounds s = Array.Find(sounds, sound => sound.name == name);
        if (s == null) { return;}
        
        s.source.Stop();
    }

    

    private void ChangedActiveScene(Scene current, Scene next)
    {
        string currentName = current.name;

        if (currentName == null)
        {
            // Scene1 has been removed
            currentName = "Replaced";
        }

        if (SceneManager.GetActiveScene().name == "Level 1" || SceneManager.GetActiveScene().name == "Level 2" || SceneManager.GetActiveScene().name == "Level 3")
        {
            Stop("BGM");
            Play("Ambience");
        }
    }
}