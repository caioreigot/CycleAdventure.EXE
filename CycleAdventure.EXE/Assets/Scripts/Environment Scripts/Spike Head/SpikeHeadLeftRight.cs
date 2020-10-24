using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeHeadLeftRight : MonoBehaviour
{

    private Player Player;

    private Rigidbody2D rig;
    private Animator anim;

    [HideInInspector] public bool moving = true;

    [SerializeField] float speed;
    [SerializeField] float invertTime = 3f;
    [SerializeField] bool leftDir = true;
    
    [SerializeField] int increaseSpeedOverTime = 30;
    [SerializeField] float speedOverTime = 3f;
    
    void Awake()
    {
        Player = GameObject.Find("Player").GetComponent<Player>();
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Start()
    {        
        if (leftDir)
            speedOverTime = -speedOverTime;

        speed = speedOverTime;
    }

    void Update()
    {
        if (speedOverTime > 0 && moving)
            speedOverTime += Time.deltaTime * increaseSpeedOverTime;
        else if (moving)
            speedOverTime -= Time.deltaTime * increaseSpeedOverTime;

        rig.velocity = new Vector2(speedOverTime, rig.velocity.y);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Player.Desappear();
            GameController.instance.ShowGameOver();
        }
        else
        {
            // Hit SFX
            if (GetComponent<AudioSource>() != null)
                GetComponent<AudioSource>().Play();

            moving = false;
            speedOverTime = 0;

            StartCoroutine(InvertDirection());
            StartCoroutine(HitAnimation());
        }
    }

    IEnumerator InvertDirection()
    {
        yield return new WaitForSeconds(invertTime);

        speed = -speed;
        speedOverTime = speed;

        moving = true;
    }

    IEnumerator HitAnimation()
    {
        anim.SetBool("Hit", true);

        yield return new WaitForSeconds(0.18f);

        anim.SetBool("Hit", false);
    }

}
