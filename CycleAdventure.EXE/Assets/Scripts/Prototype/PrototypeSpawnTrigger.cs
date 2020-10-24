using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PrototypeSpawnTrigger : MonoBehaviour
{

    private GameObject prototype;
    private GameObject appleUI;
    private GameObject scoreUI;

    void Start()
    {
        prototype = GameObject.Find("Prototype");
        prototype.SetActive(false);

        appleUI = GameObject.Find("Canvas/Apple UI");
        scoreUI = GameObject.Find("Canvas/Score");
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            AudioManager.instance.MusicOnOff("off");

            FindObjectOfType<AudioManager>().Play("Glitch");
            prototype.SetActive(true);

            appleUI.SetActive(false);
            scoreUI.SetActive(false);
        }
    }

}
