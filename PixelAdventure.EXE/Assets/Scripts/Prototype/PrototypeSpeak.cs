using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrototypeSpeak : MonoBehaviour
{

    private GameObject prototypeSpeak;

    void Start()
    {
        prototypeSpeak = GameObject.Find("Canvas")
        .transform.Find("Prototype Speak").gameObject;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
            prototypeSpeak.SetActive(true);
    }

}
