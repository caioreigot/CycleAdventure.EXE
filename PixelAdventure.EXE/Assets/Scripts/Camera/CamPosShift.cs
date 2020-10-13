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
    private float count3 = 0;
    private float count4 = 0;

    private bool positiveVertical;
    private bool positiveHorizontal;

    [Tooltip("Shifts the camera on the vertical axis, use negative values ​​to raise the camera, and positive values ​​to descend")]
    [SerializeField] float CamVerticalShift = 0;
    
    [Tooltip("Shifts the camera on the horizontal axis, use negative values to make the camera go to the left, and positive to the right")]
    [SerializeField] float CamHorizontalShift = 0;

    void Start()
    {
        vcam = GameObject.Find("CM vcam1").GetComponent<CinemachineVirtualCamera>();
        framingTransposer = vcam.GetCinemachineComponent<CinemachineFramingTransposer>();

        if (CamVerticalShift > 0) positiveVertical = true;
        if (CamHorizontalShift > 0) positiveHorizontal = true;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            if (CamVerticalShift != 0)
                StartCoroutine(VerticalSmoothCam());

            if (CamHorizontalShift != 0)
                StartCoroutine(HorizontalSmoothCam());
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            if (CamVerticalShift != 0)
                StartCoroutine(BackVerticalSmoothCam());

            if (CamHorizontalShift != 0)
                StartCoroutine(BackHorizontalSmoothCam());
        }
    }

    // Shifts the camera along the vertical axis smoothly
    IEnumerator VerticalSmoothCam()
    {
        if (positiveVertical)
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
        else
        {
            while (true)
            {
                yield return new WaitForSeconds(0.01f);

                framingTransposer.m_ScreenY += 0.01f;
                count1 += 0.01f;

                if (count1 >= -CamVerticalShift)
                {
                    count1 = 0;
                    yield break;
                }
            } 
        }
    }

    // Smoothly back to the starting position
    IEnumerator BackVerticalSmoothCam()
    {
        if (positiveVertical)
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
        else
        {
            while (true)
            {
                yield return new WaitForSeconds(0.01f);

                framingTransposer.m_ScreenY -= 0.01f;
                count2 += 0.01f;

                if (count2 >= -CamVerticalShift)
                {
                    count2 = 0;
                    yield break;
                }
            } 
        }
    }

    // Shifts the camera along the horizontal axis smoothly
    IEnumerator HorizontalSmoothCam()
    {
        if (positiveHorizontal)
        {
            while (true)
            {
                yield return new WaitForSeconds(0.01f);

                framingTransposer.m_ScreenX -= 0.01f;
                count3 += 0.01f;

                if (count3 >= CamHorizontalShift)
                {
                    count3 = 0;
                    yield break;
                }
            }
        }
        else
        {
            while (true)
            {
                yield return new WaitForSeconds(0.01f);

                framingTransposer.m_ScreenX += 0.01f;
                count3 += 0.01f;

                if (count3 >= -CamHorizontalShift)
                {
                    count3 = 0;
                    yield break;
                }
            } 
        }
    }

    // Smoothly back to the starting position
    IEnumerator BackHorizontalSmoothCam()
    {
        if (positiveHorizontal)
        {
            while (true)
            {
                yield return new WaitForSeconds(0.01f);

                framingTransposer.m_ScreenX += 0.01f;
                count4 += 0.01f;

                if (count4 >= CamHorizontalShift)
                {
                    count4 = 0;
                    yield break;
                }
            }
        }
        else
        {
            while (true)
            {
                yield return new WaitForSeconds(0.01f);

                framingTransposer.m_ScreenX -= 0.01f;
                count4 += 0.01f;

                if (count4 >= -CamHorizontalShift)
                {
                    count4 = 0;
                    yield break;
                }
            } 
        }
    }
}
