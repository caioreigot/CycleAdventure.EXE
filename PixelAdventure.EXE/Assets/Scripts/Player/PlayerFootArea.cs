using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFootArea : MonoBehaviour
{

    private BoxCollider2D bc;

    void Start()
    {
        bc = GetComponent<BoxCollider2D>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        // Stepping on a falling platform
        if (collider.gameObject.layer == 10)
        {
            FallingPlatform.playerOnPlatform = true;
            
            Player.instance.isJumping = false;
            Player.anim.SetBool("Jump", false);
        }

        // Colliding with the ground or a falling platform
        if (collider.gameObject.layer == 8 || collider.gameObject.layer == 10) 
        {
            if (collider.gameObject.layer == 8) FallingPlatform.playerOnPlatform = false;

            Player.instance.isJumping = false;

            Player.instance.ResetJumpAnimations();
        }

        // Colliding with spikes (game over)
        if (collider.gameObject.tag == "Spike")
        {
            bc.enabled = false;
            Player.instance.Desappear();

            GameController.instance.ShowGameOver();
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.layer == 8 || collider.gameObject.layer == 10) 
        {
            Player.instance.isJumping = true;
        }
    }

}
