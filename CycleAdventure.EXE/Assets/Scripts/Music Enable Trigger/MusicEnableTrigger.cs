using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class MusicEnableTrigger : MonoBehaviour
{

    void Start()
    {
        GameObject.Find("Canvas Pause").transform.Find("Pause Menu").Find("Audio").gameObject.SetActive(true);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Sound music = Array.Find(AudioManager.instance.sounds, s => s.name == "Music");

            if (music.source.volume == 0)
            {
                GameObject.Find("Canvas Pause").transform.Find("Pause Menu").Find("Audio")
                .Find("Slider Audio").gameObject.GetComponent<Slider>().value = 0.1f;

                music.source.volume = 0.1f;
            }
        }
    }

}
