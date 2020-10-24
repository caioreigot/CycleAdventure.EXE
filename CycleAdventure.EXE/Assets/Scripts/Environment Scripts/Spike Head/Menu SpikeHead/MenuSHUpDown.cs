using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSHUpDown : MonoBehaviour
{
    private Animator anim;
 
    [HideInInspector] public Rigidbody2D rig;
    
    [SerializeField] float gravityScale = 4f;
    [SerializeField] float invertTime = 3f;
    [SerializeField] bool downDir = true;
    [SerializeField] bool animate = true;

    void Awake()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        if (downDir)
            rig.gravityScale = gravityScale;
        else
            rig.gravityScale = -gravityScale;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(InvertGravity());

        if (animate)
            StartCoroutine(HitAnimation());
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
