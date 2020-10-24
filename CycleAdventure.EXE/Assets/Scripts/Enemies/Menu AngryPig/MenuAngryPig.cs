using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAngryPig : MonoBehaviour
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

}
