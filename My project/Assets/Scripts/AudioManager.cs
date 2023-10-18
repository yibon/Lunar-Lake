using UnityEditor.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    //an array of sounds will be stored here
    public Sounds[] sounds;
    // Start is called before the first frame update

    public static AudioManager instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
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
        Play("Ambience");
    }

    // Update is called once per frame
    public void Play(string name)
    {
        Sounds s = Array.Find(sounds, sound => sound.name == name);
        if (s == null) { return;}

        s.source.Play();
    }
}