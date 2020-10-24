using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SHLeftRightStick : MonoBehaviour
{

    private GameObject playerGO;
    private Player Player;

    private Rigidbody2D playerRig;
    private Rigidbody2D rig;

    private Animator anim;

    private float speed;
    [SerializeField] float invertTime = 3f;
    [SerializeField] float speedOverTime = 3f;
    [SerializeField] bool leftDir = true;
    [SerializeField] int increaseSpeedOverTime = 30;
    private bool moving = true;
    private bool playerOverStick = false;

    void Awake()
    {
        playerGO = GameObject.Find("Player");
        playerRig = playerGO.GetComponent<Rigidbody2D>();
        Player = playerGO.GetComponent<Player>();

        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Start()
    {        
        InitializeVariable();
    }

    void InitializeVariable()
    {
        if (leftDir)
            speedOverTime = -speedOverTime;

        speed = speedOverTime;
    }

    void FixedUpdate()
    {
        if (speedOverTime > 0 && moving)
            speedOverTime += Time.deltaTime * increaseSpeedOverTime;
        else if (moving)
            speedOverTime -= Time.deltaTime * increaseSpeedOverTime;

        rig.velocity = new Vector2(speedOverTime, rig.velocity.y);

        // Exercise the same speed as the spike head on the player if it is above the stick
        if (playerOverStick)
            playerRig.velocity = new Vector2(speedOverTime + Input.GetAxis("Horizontal") * Player.speed, playerRig.velocity.y);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && collision.otherCollider.tag != "Stick")
        {
            Player.Desappear();
            GameController.instance.ShowGameOver();
        }
        else if (collision.otherCollider.tag != "Stick")
        {
            // Hit SFX
            if (GetComponent<AudioSource>() != null)
                GetComponent<AudioSource>().Play();

            moving = false;
            speedOverTime = 0;

            StartCoroutine(InvertDirection());
            StartCoroutine(HitAnimation());
        }

        if (collision.gameObject.tag == "Player" && collision.otherCollider.tag == "Stick")
        {
            playerOverStick = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && collision.otherCollider.tag == "Stick")
        {
            playerOverStick = false;
        }
    }

    IEnumerator InvertDirection()
    {
        yield return new WaitForSeconds(invertTime);

        moving = true;
        
        speed = -speed;
        speedOverTime = speed;
    }

    IEnumerator HitAnimation()
    {
        anim.SetBool("Hit", true);

        yield return new WaitForSeconds(0.18f);

        anim.SetBool("Hit", false);
    }

}
