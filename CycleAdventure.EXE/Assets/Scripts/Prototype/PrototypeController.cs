using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrototypeController : MonoBehaviour
{

    public static PrototypeController instance;

    private GameObject prototypeSpeak;
    private Text prototypeText;
    
    private string text = "wHy yoU kEeP plaYing? go awAy";
    private bool typeFast = false;
    private int count;

    [SerializeField] float typeSpeed = 0;

    void Start()
    {
        instance = this;

        prototypeSpeak = GameObject.Find("Canvas").transform.Find("Prototype Speak").gameObject;
        prototypeText = prototypeSpeak.transform.Find("Text").gameObject.GetComponent<Text>();
    }

    public void PrototypeSpeak()
    {
        prototypeSpeak.SetActive(true);
        StartCoroutine(LetterByLetter());
    }

    public IEnumerator LetterByLetter()
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
                    typeSpeed = 0f;
                    typeFast = true;

                    count++;

                    // After writing 12x the text, close the game
                    if (count == 12)
                    {
                        PlayerPrefs.SetInt("AfterQuit", 1);
                        PlayerPrefs.SetInt("ApplesWhenQuit", StaticVariables.TotalScore);
                        Application.Quit();
                    }
                }

                yield return new WaitForSeconds(typeSpeed);
            }
        }
    }

}
