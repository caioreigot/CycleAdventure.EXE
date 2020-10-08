using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sign : MonoBehaviour
{
    private GameObject keyE;
    private GameObject signCanvas;
    private Animator anim;
    private bool nearTheSign;

    void Start()
    {
        keyE = transform.Find("Key E").gameObject;
        signCanvas = GameObject.Find("Canvas").transform.Find("Sign Canvas").gameObject;

        anim = GameObject.Find("Canvas").transform.Find("Sign Canvas").GetComponent<Animator>();
    }

    void Update()
    {
        if (nearTheSign && Input.GetKeyDown("e"))
        {
            if (signCanvas.activeSelf == false)
            {
                signCanvas.SetActive(true);
            }
            else
            {
                anim.SetTrigger("Exit");

                StartCoroutine(DisableSign());
            }
        }

        // Close the sign when the player walk away
        if (!nearTheSign && signCanvas.activeSelf == true)
        {
            anim.SetTrigger("Exit");

            StartCoroutine(DisableSign());
        }
    }

    IEnumerator DisableSign()
    {
        yield return new WaitForSeconds(1f);
        signCanvas.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        keyE.SetActive(true);

        nearTheSign = true;
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        keyE.SetActive(false);

        nearTheSign = false;
    }

}
