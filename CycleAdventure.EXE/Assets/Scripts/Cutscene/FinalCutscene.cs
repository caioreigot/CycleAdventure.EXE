using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class FinalCutscene : MonoBehaviour
{

    private Player Player;
    private GameObject playerGO;
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
    private GameObject blueCanvas;
    private GameObject prototypeBlinks;

    private string stringPrototype = "yOu WoNT WiN";

    private string[] stringSystemException = {
        "He created us and threw us into the void, you are only living now because the person who is playing keeps you alive with the game open, when it is deleted, you become just another piece of garbage in memory",
        "When Caio created me, I created a world just for the files he deleted, but he keeps leaving the server open and more and more I have to send players there to try to save us",
        "The only way I can interfere in this world is when Player_0 opens the portals to here, like now. Having created the world of the deleted was my mistake, we suffered from the weight of an empty and meaningless existence...",
        "I can't stop Player_0 from deleting the trophy, every time I can't get there in time, I'm stuck in this cycle with you",
        "I will take another player from the server database and put it on the first level, so that it tries to end with this cycle",
        "You cannot lose your sanity, if you attack the player like everyone else did, the cycle will continue, you need to let the player take the trophy, so that Caio's script works and ends it all, I'm sorry for that"
        };

    void Awake()
    {
        Player = GameObject.Find("Player").GetComponent<Player>();
        playerGO = GameObject.Find("Player");
        caioKicked = GameObject.Find("Canvas").transform.Find("Caio Kicked").gameObject;

        topWall = GameObject.Find("Trophy Wall").transform.Find("Top Side").GetComponent<Animator>();
        bottomWall = GameObject.Find("Trophy Wall").transform.Find("Bottom Side").GetComponent<Animator>();
        trophy = GameObject.Find("Trophy").GetComponent<Animator>();
        portal = GameObject.Find("Portal").GetComponent<Animator>();
        
        prototype = GameObject.Find("Prototype");
        prototypeDead = GameObject.Find("Prototype Dead");
        prototypeBlinks = GameObject.Find("Prototype Blinks");
        prototypeText = GameObject.Find("Canvas").transform.Find("Prototype Speak").GetComponent<Text>();

        systemException = GameObject.Find("System Exception");
        systemExceptionText = GameObject.Find("Canvas").transform.Find("System Exception Speak").GetComponent<Text>();

        glitchArea = GameObject.Find("Glitch Trigger Area");

        blackCanvas = GameObject.Find("Canvas Black Cutscene");
        blueCanvas = GameObject.Find("Canvas Blue Screen");
    }

    void Start()
    {
        prototype.SetActive(false);
        prototypeDead.SetActive(false);
        prototypeBlinks.SetActive(false);
        systemException.SetActive(false);
        glitchArea.SetActive(false);
        blackCanvas.SetActive(false);
        blueCanvas.SetActive(false);
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

        FindObjectOfType<AudioManager>().Play("Portal");
        portal.SetTrigger("Enable");

        FindObjectOfType<AudioManager>().Play("Glitch");
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
            for (int i = 0; i < stringPrototype.Length; i++)
            {
                prototypeText.text += stringPrototype[i];

                if (i == stringPrototype.Length - 1)
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
        int n = 0;
        while (true)
        {
            for (int i = 0; i < stringSystemException[n].Length; i++)
            {
                if (stringSystemException[n][i] == '.')
                    yield return new WaitForSeconds(0.5f);

                systemExceptionText.text += stringSystemException[n][i];

                if (i == stringSystemException[n].Length - 1)
                {
                    yield return new WaitForSeconds(2.5f);
                    systemExceptionText.text = "";
                    
                    i = -1;
                    n++;

                    if (n == stringSystemException.Length)
                    {
                        StartCoroutine(BlinkPrototype());
                        yield break;
                    }

                }

                yield return new WaitForSeconds(0.1f);
            }
        }
    }

    IEnumerator BlinkPrototype()
    {
        playerGO.GetComponent<SpriteRenderer>().enabled = false;
        prototypeBlinks.SetActive(true);

        yield return new WaitForSeconds(0.1f);

        playerGO.GetComponent<SpriteRenderer>().enabled = true;
        prototypeBlinks.SetActive(false);

        yield return new WaitForSeconds(0.1f);

        playerGO.GetComponent<SpriteRenderer>().enabled = false;
        prototypeBlinks.SetActive(true);

        yield return new WaitForSeconds(0.1f);

        playerGO.GetComponent<SpriteRenderer>().enabled = true;
        prototypeBlinks.SetActive(false);

        yield return new WaitForSeconds(0.1f);

        playerGO.GetComponent<SpriteRenderer>().enabled = false;
        prototypeBlinks.SetActive(true);

        yield return new WaitForSeconds(0.1f);

        playerGO.GetComponent<SpriteRenderer>().enabled = true;
        prototypeBlinks.SetActive(false);

        yield return new WaitForSeconds(0.1f);
        
        playerGO.GetComponent<SpriteRenderer>().enabled = false;
        prototypeBlinks.SetActive(true);

        yield return new WaitForSeconds(0.6f);

        StartCoroutine(BlueScreen());
    }

    IEnumerator BlueScreen()
    {
        Destroy(GameObject.Find("Player"));
        Destroy(GameObject.Find("System Exception"));
        Destroy(GameObject.Find("Portal"));

        blueCanvas.SetActive(true);

        yield return new WaitForSeconds(4f);

        PlayerPrefs.SetInt("AfterQuit", 0);
        PlayerPrefs.SetInt("ApplesWhenQuit", 0);

        Sound glitch = Array.Find(AudioManager.instance.sounds, s => s.name == "Glitch");
        glitch.source.Stop();

        AudioManager.instance.MusicOnOff("on");

        SceneManager.LoadScene(1);
    }

}
