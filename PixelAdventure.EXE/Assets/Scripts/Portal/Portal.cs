using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Portal : MonoBehaviour
{

    private Player Player;
    private CinemachineVirtualCamera vcam;
    private Rigidbody2D enteredRigidbody;
    private float enterDir, exitDir;

    void Start()
    {
        Player = GameObject.Find("Player").GetComponent<Player>();
        vcam = GameObject.Find("CM vcam1").GetComponent<CinemachineVirtualCamera>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {     
        if (collider.gameObject.tag == "Player")
        {
            enteredRigidbody = collider.gameObject.GetComponent<Rigidbody2D>();
            enterDir = enteredRigidbody.velocity.x;

            if (gameObject.name == "Portal In")
            {
                PortalController.instance.DisableCollider("out");
                PortalController.instance.CreateClone("atOut");
            }
            else if (gameObject.name == "Portal Out")
            {
                PortalController.instance.DisableCollider("in");
                PortalController.instance.CreateClone("atIn");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            exitDir = enteredRigidbody.velocity.x;
            
            if (enterDir >= 0 && exitDir >= 0 || enterDir <= 0 && exitDir <= 0)
            {
                Destroy(collider.gameObject);
                GameObject.Find("Clone").name = "Player";
                
                Player.isJumping = false;

                PortalController.instance.EnableColliders();
            }
            // If player give up to enter the portal
            else
            {
                vcam.m_Follow = GameObject.Find("Player").transform;
                
                Destroy(GameObject.Find("Clone"));
                PortalController.instance.EnableColliders();
            }
        }
    }

}
