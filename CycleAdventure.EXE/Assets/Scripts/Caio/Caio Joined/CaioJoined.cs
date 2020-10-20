using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaioJoined : MonoBehaviour
{

    private GameObject caioJoined;
    private GameObject prototypeJoined;

    void Start()
    {
        caioJoined = GameObject.Find("Canvas").transform.Find("Caio Joined").gameObject;
        prototypeJoined = GameObject.Find("Canvas").transform.Find("Prototype Joined").gameObject;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            StartCoroutine(ShowCaioJoined());
        }
    }

    IEnumerator ShowCaioJoined()
    {
        prototypeJoined.SetActive(false);
        caioJoined.SetActive(true);

        yield return new WaitForSeconds(4f);

        caioJoined.SetActive(false);
        Destroy(gameObject);
    }

}
