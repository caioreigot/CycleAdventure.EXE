using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrototypeSpeak : MonoBehaviour
{

    private GameObject prototypeSpeak;
    private Text prototypeText;
    private CapsuleCollider2D capsuleCollider2D;
    
    private string text = "wHy yoU kEeP plaYing? go awAy";
    private bool typeFast = false;
    private int count;

    [SerializeField] float typeSpeed = 0;

    void Start()
    {
        prototypeSpeak = GameObject.Find("Canvas").transform.Find("Prototype Speak").gameObject;
        prototypeText = prototypeSpeak.transform.Find("Text").gameObject.GetComponent<Text>();
        capsuleCollider2D = GetComponent<CapsuleCollider2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        { 
            capsuleCollider2D.enabled = false;

            prototypeSpeak.SetActive(true);
            StartCoroutine(LetterByLetter());
        }
    }

    IEnumerator LetterByLetter()
    {
        while (true)
        {
            for (int i = 0; i < text.Length; i++)
            {
                prototypeText.text += text[i];

                // Stop at the last word and start to type fast
                if (i == text.Length - 1)
                {
                    if (!typeFast)
                        yield return new WaitForSeconds(2f);
                    
                    prototypeText.text += " ";
                    typeSpeed = 0.002f;
                    typeFast = true;

                    count++;

                    // After writing 12x the text, quit the game
                    if (count == 12)
                    {
                        PlayerPrefs.SetInt("AfterQuit", 1);
                        Application.Quit();
                    }
                }

                yield return new WaitForSeconds(typeSpeed);
            }
        }
    }

}
