using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{

    private GameObject pressSpace;

    void Start()
    {
        pressSpace = GameObject.Find("Canvas")
        .transform.Find("Game Over Panel")
        .transform.Find("Button Restart")
        .transform.Find("Text").gameObject;
        
        StartCoroutine(BlinkRestartOn());
    }

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            GameController.instance.Restart();
        }
    }

    IEnumerator BlinkRestartOn()
    {
        pressSpace.SetActive(true);

        yield return new WaitForSeconds(0.7f);

        StartCoroutine(BlinkRestartOff());
    }

    IEnumerator BlinkRestartOff()
    {
        pressSpace.SetActive(false);

        yield return new WaitForSeconds(0.7f);

        StartCoroutine(BlinkRestartOn());
    }

}
