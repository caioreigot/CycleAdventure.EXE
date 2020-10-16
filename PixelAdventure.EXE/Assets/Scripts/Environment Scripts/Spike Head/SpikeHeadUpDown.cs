using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeHeadUpDown: MonoBehaviour
{

    private Rigidbody2D rig;
    private Animator anim;

    [SerializeField] float gravityScale = 4f;
    [SerializeField] float invertTime = 3f;
    [SerializeField] bool downDir = true;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        InitializeVariables();
    }

    void InitializeVariables()
    {
        if (downDir)
            rig.gravityScale = gravityScale;
        else
            rig.gravityScale = -gravityScale;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Player.instance.Desappear();
            GameController.instance.ShowGameOver();
        }
        else
        {
            StartCoroutine(InvertGravity());
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
