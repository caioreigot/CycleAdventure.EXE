using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SHLeftRightCommands : MonoBehaviour
{

    private Player Player;

    private Rigidbody2D rig;
    private Animator anim;

    [HideInInspector] public bool moving = true;

    [SerializeField] float speed = 10;
    [SerializeField] float invertTime = 0.1f;
    [SerializeField] bool leftDir = true;

    private float moveSpeed;
    
    void Awake()
    {
        Player = GameObject.Find("Player").GetComponent<Player>();
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Start()
    {   
        moveSpeed = speed;
        
        if (leftDir)
            moveSpeed = -moveSpeed;
    }

    void Update()
    {
        if (moving)
            rig.velocity = new Vector2(moveSpeed, rig.velocity.y);
        else
            rig.velocity = new Vector2(0, rig.velocity.y);
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

            StartCoroutine(InvertDirection());
            StartCoroutine(HitAnimation());
        }
    }

    IEnumerator InvertDirection()
    {
        yield return new WaitForSeconds(invertTime);

        moveSpeed = -moveSpeed;
        moving = true;
    }

    IEnumerator HitAnimation()
    {
        anim.SetBool("Hit", true);

        yield return new WaitForSeconds(0.18f);

        anim.SetBool("Hit", false);
    }

}
