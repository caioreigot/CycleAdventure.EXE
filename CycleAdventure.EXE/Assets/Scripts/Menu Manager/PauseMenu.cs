using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PauseMenu : MonoBehaviour
{

    private GameObject pauseCanvas;
    private GameObject chat;
    private Slider volume;
    private bool isOnPause = false;

    void Start()
    {
        pauseCanvas = GameObject.Find("Canvas Pause").transform.Find("Pause Menu").gameObject;
        volume = pauseCanvas.transform.Find("Audio").Find("Slider Audio").GetComponent<Slider>();
        chat = GameObject.Find("Canvas").transform.Find("Chat").gameObject;

        OnStartSetValue();
    }

    void OnStartSetValue()
    {
        Sound music = Array.Find(AudioManager.instance.sounds, s => s.name == "Music");
        volume.value = music.source.volume;  
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isOnPause && !GameController.instance.gameOverCalledThisFrame && !chat.activeSelf)
        {
            ShowPause();
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            Resume();
        }

        if (pauseCanvas.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                Resume();
            }
        }
    }

    void ShowPause()
    {
        pauseCanvas.SetActive(true);
        isOnPause = true;

        Time.timeScale = 0;
    }

    public void Resume()
    {
        pauseCanvas.SetActive(false);
        isOnPause = false;

        Time.timeScale = 1;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void ChangeVolume()
    {
        Sound music = Array.Find(AudioManager.instance.sounds, s => s.name == "Music");
        music.source.volume = volume.value;

        AudioManager.instance.musicVolume = volume.value;
    }

    public void PointerClickSound()
    {
        FindObjectOfType<AudioManager>().Play("Mouse Click");
    }

}
