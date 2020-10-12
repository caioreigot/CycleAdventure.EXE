using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class LookDownArea : MonoBehaviour
{
    public CinemachineVirtualCamera vcam;
    public CinemachineFramingTransposer framingTransposer;

    void Start()
    {
        vcam = GameObject.Find("CM vcam1").GetComponent<CinemachineVirtualCamera>();
        framingTransposer = vcam.GetCinemachineComponent<CinemachineFramingTransposer>();
    }

    // OnTriggerStay, fazer um for e acrescentar +1f até N vezes e parar.
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            framingTransposer.m_ScreenY -= 0.25f;
            Debug.Log("Câmera movida");
        }
    }
}
