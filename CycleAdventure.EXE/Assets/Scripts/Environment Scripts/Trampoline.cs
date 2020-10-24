using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    
    [SerializeField] private float trampolineJumpForce = 30f;

    private Animator anim;

    void Start()
    {
        anim = GetComponentInParent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            FindObjectOfType<AudioManager>().Play("Trampoline");
            anim.SetTrigger("Jump");
            
            //collider.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            collider.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.up * trampolineJumpForce;
        }
    }

}
