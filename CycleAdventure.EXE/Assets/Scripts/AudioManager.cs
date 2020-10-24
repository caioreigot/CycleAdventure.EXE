using UnityEngine.Audio;
using System.Collections;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public Sound[] sounds;

    public static AudioManager instance;

    public float musicVolume;

    void Awake() 
    {

        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
        
        DontDestroyOnLoad(gameObject);

        foreach (Sound sound in sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            
            sound.source.clip = sound.clip;
            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;
            sound.source.loop = sound.loop;
            sound.source.playOnAwake = sound.playOnAwake;
        }
    }

    void Start()
    {
        Play("Music");
    }

    public void MusicOnOff(string state)
    {
        Sound music = Array.Find(AudioManager.instance.sounds, s => s.name == "Music");
        
        if (state == "off")
        {
            if (GameObject.Find("Canvas Pause") != null)
                GameObject.Find("Canvas Pause").transform.Find("Pause Menu").Find("Audio").gameObject.SetActive(false);
            
            music.source.volume = 0;
        }

        if (state == "on")
        {
            if (GameObject.Find("Canvas Pause") != null)
                GameObject.Find("Canvas Pause").transform.Find("Pause Menu").Find("Audio").gameObject.SetActive(true);
            
            music.source.volume = musicVolume;
        }   
    }

    public void Play(string name)
    {
        Sound sound = Array.Find(sounds, s => s.name == name);

        if (sound == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }

        sound.source.Play();
    }

}
