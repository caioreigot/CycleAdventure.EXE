﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrashCutscene : MonoBehaviour
{

    [SerializeField] string text = "he tHrew Me hEre";
    [SerializeField] GameObject prototype;
    [SerializeField] GameObject prototypeSpeak;
    [SerializeField] Text prototypeText;
    [SerializeField] PortalChangePos portalChangePos;
    [SerializeField] float typeSpeed = 0.3f;
    
    void Start()
    {
        portalChangePos = GameObject.Find("Portal In").GetComponent<PortalChangePos>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            StartCoroutine(StartCutscene());
            PrototypeSpeak();
        }
    }

    IEnumerator StartCutscene()
    {
        Player Player = GameObject.Find("Player").GetComponent<Player>();
        Player.transform.eulerAngles = new Vector3(0f, 180f, 0f);
        Player.canMove = false;

        yield return new WaitForSeconds(8f);

        Player.canMove = true;

        portalChangePos.ChangePosition(new Vector3(-182.22f, -37.53f, 0));

        Destroy(gameObject);
    }

    void PrototypeSpeak()
    {
        prototypeSpeak.SetActive(true);
        StartCoroutine(LetterByLetter());
    }

    public IEnumerator LetterByLetter()
    {
        yield return new WaitForSeconds(1f);

        while (true)
        {
            for (int i = 0; i < text.Length; i++)
            {
                prototypeText.text += text[i];

                if (i == text.Length - 1)
                {
                    yield return new WaitForSeconds(2f);
                    
                    prototype.SetActive(false);
                    prototypeSpeak.SetActive(false);
                }

                yield return new WaitForSeconds(typeSpeed);
            }
        }
    }

}
