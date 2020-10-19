using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeHeadLeftRight : MonoBehaviour
{

    private Player Player;

    private Rigidbody2D rig;
    private Animator anim;

    [SerializeField] float invertTime = 3f;
    [SerializeField] float speed = 3f;
    [SerializeField] float speedOverTime = 3f;
    [SerializeField] bool leftDir = true;
    [SerializeField] int increaseSpeedOverTime = 30;
    private bool moving = true;

    void Start()
    {
        Player = GameObject.Find("Player").GetComponent<Player>();
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        InitializeVariables();
    }

    void InitializeVariables()
    {
        if (leftDir)
            speed = -speed;
        else
            return;
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
            moving = false;
            StartCoroutine(InvertDirection());
            StartCoroutine(HitAnimation());
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
