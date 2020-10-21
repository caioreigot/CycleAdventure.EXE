using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeHeadUpDown : MonoBehaviour
{

    public static SpikeHeadUpDown instance;

    private Player Player;
    private Animator anim;
 
    [HideInInspector] public Rigidbody2D rig;
    
    [SerializeField] float gravityScale = 4f;
    [SerializeField] float invertTime = 3f;
    [SerializeField] bool downDir = true;
    [SerializeField] bool animate = true;

    void Awake()
    {
        Player = GameObject.Find("Player").GetComponent<Player>();
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        if (downDir)
            rig.gravityScale = gravityScale;
        else
            rig.gravityScale = -gravityScale;

        instance = this;
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
            StartCoroutine(InvertGravity());

            if (animate)
                StartCoroutine(HitAnimation());
        }
    }

    IEnumerator InvertGravity()
    {
        yield return new WaitForSeconds(invertTime);

        rig.gravityScale = -rig.gravityScale;
    }

    IEnumerator HitAnimation()
    {
        anim.SetBool("Hit", true);

        yield return new WaitForSeconds(0.18f);

        anim.SetBool("Hit", false);
    }

}
