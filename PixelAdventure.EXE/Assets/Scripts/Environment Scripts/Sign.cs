using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sign : MonoBehaviour
{
    private GameObject keyE;
    private GameObject signCanvas;
    private GameObject objectRelatedText;
    private Animator anim;
    private bool nearTheSign;

    [Tooltip("If there are multiple signs in the scene, enter the name of the child text to be displayed")]
    [SerializeField] string relatedText = "Text1";

    void Start()
    {
        keyE = transform.Find("Key E").gameObject;
        signCanvas = GameObject.Find("Canvas").transform.Find("Sign Canvas").gameObject;
        objectRelatedText = signCanvas.transform.Find(relatedText).gameObject;

        anim = GameObject.Find("Canvas").transform.Find("Sign Canvas").GetComponent<Animator>();
    }

    void Update()
    {
        if (nearTheSign && Input.GetKeyDown("e"))
        {
            if (signCanvas.activeSelf == false)
            {
                signCanvas.SetActive(true);
                objectRelatedText.SetActive(true);
            }
            else
            {
                anim.SetTrigger("Exit");

                StartCoroutine(DisableSign());
            }
        }

        // Close the sign when the player walk away
        if (signCanvas.transform.childCount == 1 && !nearTheSign && signCanvas.activeSelf)
        {
            anim.SetTrigger("Exit");

            StartCoroutine(DisableSign());
        }
    }

    IEnumerator DisableSign()
    {
        yield return new WaitForSeconds(1f);
        signCanvas.SetActive(false);
        objectRelatedText.SetActive(false);
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
