using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    public float fallingTime;

    private Vector3 platformPosition;
    private Vector3 playerPosition;

    private TargetJoint2D target;
    private BoxCollider2D boxCollider;

    public static bool playerOnPlatform;

    void Start()
    {
        target = GetComponent<TargetJoint2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        
        platformPosition = GetComponent<Transform>().position;
        playerPosition = GameObject.FindObjectOfType<Player>().transform.position;
    }

    void OnCollisionEnter2D(Collision2D collision) 
    {
        // if (collision.gameObject.tag == "Player" && playerPosition.y - 1 > platformPosition.y)
        if (collision.gameObject.tag == "Player" && playerOnPlatform)
        {
            playerOnPlatform = false;
            
            // When the player collides with the platform, the Falling() function will be called after (fallingTime)
            Invoke("Falling", fallingTime);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.layer == 9) 
        {
            Destroy(gameObject);
        }
    }

    void Falling() 
    {
        target.enabled = false;
        boxCollider.isTrigger = true;
    }
}
