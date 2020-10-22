using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalCutscene : MonoBehaviour
{

    private Player Player;
    private GameObject caioKicked;
    private Animator topWall;
    private Animator bottomWall;
    private Animator trophy;
    private Animator portal;
    private GameObject prototype;
    private GameObject prototypeDead;
    private Text prototypeText;
    private GameObject systemException;
    private Text systemExceptionText;
    private GameObject glitchArea;
    private GameObject blackCanvas;

    private string text = "yOu WoNT WiN";

    void Awake()
    {
        Player = GameObject.Find("Player").GetComponent<Player>();
        caioKicked = GameObject.Find("Canvas").transform.Find("Caio Kicked").gameObject;

        topWall = GameObject.Find("Trophy Wall").transform.Find("Top Side").GetComponent<Animator>();
        bottomWall = GameObject.Find("Trophy Wall").transform.Find("Bottom Side").GetComponent<Animator>();
        trophy = GameObject.Find("Trophy").GetComponent<Animator>();
        portal = GameObject.Find("Portal").GetComponent<Animator>();
        
        prototype = GameObject.Find("Prototype");
        prototypeDead = GameObject.Find("Prototype Dead");
        prototypeText = GameObject.Find("Canvas").transform.Find("Prototype Speak").GetComponent<Text>();

        systemException = GameObject.Find("System Exception");
        systemExceptionText = GameObject.Find("Canvas").transform.Find("System Exception Speak").GetComponent<Text>();

        glitchArea = GameObject.Find("Glitch Trigger Area");

        blackCanvas = GameObject.Find("Canvas Black Cutscene");
    }

    void Start()
    {
        prototype.SetActive(false);
        prototypeDead.SetActive(false);
        systemException.SetActive(false);
        glitchArea.SetActive(false);
        blackCanvas.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        ChatManager.instance.disableChat = true;

        Player.transform.eulerAngles = new Vector3(0f, 0f, 0f);
        Player.canMove = false;

        glitchArea.SetActive(true);

        topWall.SetTrigger("Enable");
        bottomWall.SetTrigger("Enable");
        trophy.SetTrigger("Enable");
        portal.SetTrigger("Enable");

        CaioKicked();
        Invoke("DestroyTrophy", 2f);
        Invoke("EnablePrototype", 2f);
        Invoke("PrototypeSpeak", 3f);
        Invoke("EnableDeadPrototype", 7.5f);
        Invoke("EnableSystemException", 8.8f);
        Invoke("SystemExceptionTalks", 9.5f);
    }

    void CaioKicked()
    {
        caioKicked.SetActive(true);
        Invoke("DisableCaioKicked", 4f);
    }

    void DisableCaioKicked()
    {
        caioKicked.SetActive(false);
    }

    void DestroyTrophy()
    {
        Destroy(GameObject.Find("Trophy"));
    }

    void EnablePrototype()
    {
        prototype.SetActive(true);
    }

    void PrototypeSpeak()
    {
        StartCoroutine(PrototypeLetterByLetter());
    }

    IEnumerator PrototypeLetterByLetter()
    {
        while (true)
        {
            for (int i = 0; i < text.Length; i++)
            {
                prototypeText.text += text[i];

                if (i == text.Length - 1)
                {
                    yield return new WaitForSeconds(0.5f);
                    prototypeText.text = "";
                    yield break;
                }

                yield return new WaitForSeconds(0.2f);
            }
        }
    }

    void EnableDeadPrototype()
    {
        prototypeDead.SetActive(true);
    }

    void EnableSystemException()
    {
        systemException.SetActive(true);
    }

    void SystemExceptionTalks()
    {
        GameObject.Find("Player").GetComponent<SpriteRenderer>().sortingOrder = 5;
        GameObject.Find("System Exception").GetComponent<SpriteRenderer>().sortingOrder = 5;
        
        blackCanvas.SetActive(true);
        GameObject.Find("Canvas").transform.Find("Score").gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.Find("Apple UI").gameObject.SetActive(false);
        GameObject.Find("Portal").transform.Find("Portal Half Left").GetComponent<SpriteRenderer>().sortingOrder = 4;

        StartCoroutine(SysExceptionLetterByLetter());
    }

    IEnumerator SysExceptionLetterByLetter()
    {
        systemExceptionText.text = "TODO";
        // fazer player piscar entre ele e o player_0
        yield return new WaitForSeconds(0.10f);
    }

}
