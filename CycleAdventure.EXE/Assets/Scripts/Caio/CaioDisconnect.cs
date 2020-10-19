using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaioDisconnect : MonoBehaviour
{

    public static CaioDisconnect instance;
    [HideInInspector] public GameObject caioDisconnect;
    [HideInInspector] public GameObject caioObject;

    void Start()
    {
        instance = this;

        caioDisconnect = GameObject.Find("Canvas").transform.Find("Caio Disconnected").gameObject;
        caioObject = GameObject.Find("Caio");

        gameObject.SetActive(false);
    }

    public void Disconnect()
    {
        caioDisconnect.SetActive(true);
        caioObject.SetActive(false);

        Invoke("DeactivateDisconnect", 4f);
    }

    public void DeactivateDisconnect()
    {
        caioDisconnect.SetActive(false);
    }

}
