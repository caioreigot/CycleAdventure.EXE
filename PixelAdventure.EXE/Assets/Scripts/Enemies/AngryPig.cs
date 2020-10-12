using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngryPig : MonoBehaviour
{
    private Rigidbody2D rig;
    
    private Animator anim;

    public Transform colA;
    public Transform colB;
    public Transform headPoint;

    public LayerMask layer;

    public BoxCollider2D BoxCollider2D;
    public CircleCollider2D CircleCollider2D;

    private bool colliding;
    private bool playerDestroyed;

    [Header("Variables")]
    
    [SerializeField] float speed;
    
    [Range(5, 20)]
    [SerializeField] int repulsionForce = 10;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        rig.velocity = new Vector2(speed, rig.velocity.y);

        colliding = Physics2D.Linecast(colA.position, colB.position, layer);

        if (colliding)
        {
            transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
            speed = -speed;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            float height = collision.contacts[0].point.y - headPoint.position.y;

            if (height > 0 && !playerDestroyed)
            {
                // Prevent the enemy from falling off the platform (after turning off the colliders)
                rig.bodyType = RigidbodyType2D.Kinematic;

                // To make the player "bounce"
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * repulsionForce, ForceMode2D.Impulse);

                // Stopping the enemy
                speed = 0;

                anim.SetTrigger("Hit");

                // Desabling colliders
                BoxCollider2D.enabled = false;
                CircleCollider2D.enabled = false;
                
                Destroy(gameObject, 0.27f);
            }
            else
            {
                playerDestroyed = true;
                Player.instance.Desappear();
                GameController.instance.ShowGameOver();
            }
        }
    }
}
