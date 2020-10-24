using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class MenuManager : MonoBehaviour
{

    private Resolution maxScreenSize;
    
    public Text dropdownMaxResText;
    public Dropdown dropdownOptions;
    public GameObject mainMenu; 
    public GameObject settingsMenu; 
    public Toggle fullscreen; 
    public Slider volume;

    public void Awake()
    {
        maxScreenSize = Screen.resolutions[Screen.resolutions.Length - 1];        
    }

    public void Start()
    {
        dropdownMaxResText.text = maxScreenSize.width + "x" + maxScreenSize.height;
        dropdownOptions.options[0].text = maxScreenSize.width + "x" + maxScreenSize.height;
    }

    public void Play()
    {
        LevelLoader.instance.LoadNextLevel();
    }

    public void ShowSettings()
    {
        mainMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }

    public void ShowMainMenu()
    {
        settingsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void Fullscreen()
    {
        Screen.SetResolution(Screen.width, Screen.height, fullscreen.isOn ? true : false);
        
    }

    public void DropdownOnValueChanged()
    {
        switch (dropdownOptions.value)
        {
            case 0:
                MaxScreenSize();
                break;
            case 1:
                Res1024x768();
                break;
            case 2:
                Res800x600();
                break;
            default:
                break;
        }
    }

    public void MaxScreenSize()
    {
        Screen.SetResolution(maxScreenSize.width, maxScreenSize.height, Screen.fullScreen);
    }

    public void Res1024x768()
    {
        Screen.SetResolution(1024, 768, Screen.fullScreen);
    }

    public void Res800x600()
    {
        Screen.SetResolution(800, 600, Screen.fullScreen);
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

    public void Quit()
    {
        Application.Quit();
    }

}
