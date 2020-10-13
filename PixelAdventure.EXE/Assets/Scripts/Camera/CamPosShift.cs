using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CamPosShift : MonoBehaviour
{
    private CinemachineVirtualCamera vcam;
    private CinemachineFramingTransposer framingTransposer;

    private float count1 = 0;
    private float count2 = 0;

    [Tooltip("Shifts the camera on the vertical axis, use negative values ​​to raise the camera, and positive values ​​to descend")]
    [SerializeField] float CamVerticalShift = 0.25f; 

    void Start()
    {
        vcam = GameObject.Find("CM vcam1").GetComponent<CinemachineVirtualCamera>();
        framingTransposer = vcam.GetCinemachineComponent<CinemachineFramingTransposer>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            StartCoroutine(ShiftSmoothCam());
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            StartCoroutine(BackSmoothCam());
        }
    }

    // Shifts the camera smoothly
    IEnumerator ShiftSmoothCam()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.01f);

            framingTransposer.m_ScreenY -= 0.01f;
            count1 += 0.01f;

            if (count1 >= CamVerticalShift)
            {
                count1 = 0;
                yield break;
            }
        }
    }

    // Smoothly back to the starting position
    IEnumerator BackSmoothCam()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.01f);

            framingTransposer.m_ScreenY += 0.01f;
            count2 += 0.01f;

            if (count2 >= CamVerticalShift)
            {
                count2 = 0;
                yield break;
            }
        }
    }
}
