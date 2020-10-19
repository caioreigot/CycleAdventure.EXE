using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFootArea : MonoBehaviour
{

    private Player Player;

    void Start()
    {
        /*
         * Using GetComponentInParent to always get the parent object script, 
         * even when using the portal and the clone name is "Clone"
        */
        Player = GetComponentInParent<Player>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        // Stepping on a falling platform
        if (collider.gameObject.layer == 10)
        {
            FallingPlatform.playerOnPlatform = true;
            
            Player.isJumping = false;
            Player.anim.SetBool("Jump", false);
        }

        // Colliding with the ground or a falling platform
        if (collider.gameObject.layer == 8 || collider.gameObject.layer == 10) 
        {
            if (collider.gameObject.layer == 8) FallingPlatform.playerOnPlatform = false;

            Player.isJumping = false;

            Player.ResetJumpAnimations();
            Player.JumpDust();
        }

        // Colliding with spikes (game over)
        if (collider.gameObject.tag == "Spike")
        {
            Player.Desappear();

            GameController.instance.ShowGameOver();
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.layer == 8 || collider.gameObject.layer == 10) 
        {
            Player.isJumping = true;
        }

        if (collider.gameObject.layer == 14)
        {
            Player.isBlowing = false;
        }
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.layer == 14)
        {
            Player.isBlowing = true;
        }
    }

}
