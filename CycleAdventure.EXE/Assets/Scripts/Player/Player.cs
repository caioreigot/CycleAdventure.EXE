using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public Animator anim;
    private ParticleSystem walkDust, jumpDust;
    private SpriteRenderer sr;
    private GameObject desappearing;

    [HideInInspector] public Rigidbody2D rig;
    [HideInInspector] public bool canMove = true;

    [HideInInspector] public bool isJumping;
    [HideInInspector] public bool doubleJump;
    [HideInInspector] public bool isBlowing;

    public float speed;
    public float jumpForce;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        desappearing = transform.Find("Desappearing").gameObject;
        walkDust = transform.Find("WalkDustPS").gameObject.GetComponent<ParticleSystem>();
        jumpDust = transform.Find("JumpDustPS").gameObject.GetComponent<ParticleSystem>();
    }

    void Update()
    {
        // Cannot move the player with chat focused
        if (!ChatManager.instance.chatBox.isFocused && canMove)
        {
            Move();
            Jump();
        }
        else
        {
            rig.velocity = new Vector2(0, rig.velocity.y);
            anim.SetBool("Walk", false);
        }
    }

    void Move() 
    {
        //Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        
        ////Transform position, without physics
        //transform.position += movement * Time.deltaTime * speed;

        float horizontalMovement = Input.GetAxis("Horizontal"); 

        rig.velocity = new Vector2(horizontalMovement * speed, rig.velocity.y);

        // Going right
        if (horizontalMovement > 0f) 
        {
            anim.SetBool("Walk", true);
            WalkDust();
            // Rotating right
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }

        // Going left
        if (horizontalMovement < 0f) 
        {
            anim.SetBool("Walk", true);
            WalkDust();
            // Rotating left
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }

        // Stopped
        if (horizontalMovement == 0f) 
        {
            anim.SetBool("Walk", false);
        }
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && !isBlowing)
        {
            if (!isJumping)
            {
                //rig.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
                rig.velocity = Vector2.up * jumpForce;
                doubleJump = true;

                JumpDust();
                FindObjectOfType<AudioManager>().Play("Player Jump");
                anim.SetBool("Jump", true);
            }
            else
            {
                if (doubleJump)
                {
                    FindObjectOfType<AudioManager>().Play("Player Jump");
                    anim.SetBool("Double Jump", true);

                    rig.velocity = Vector2.up * jumpForce;
                    doubleJump = false;
                }
            }   
        }
    }

    public void ResetJumpAnimations()
    {
        anim.SetBool("Jump", false);
        anim.SetBool("Double Jump", false);
    }

    public void Desappear()
    {
        rig.bodyType = RigidbodyType2D.Kinematic;
        rig.velocity = new Vector2(0f, 0f);
        speed = 0;

        sr.enabled = false;
        desappearing.SetActive(true);
        
        Destroy(gameObject, 0.3f);
    }

    public void WalkDust()
    {
        walkDust.Play();
    }

    public void JumpDust()
    {
        jumpDust.Play();
    }

}
