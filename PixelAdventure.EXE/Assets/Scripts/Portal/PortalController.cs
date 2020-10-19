using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalController : MonoBehaviour
{

    public static PortalController instance;

    [SerializeField] GameObject clone;

    private GameObject portalIn, portalOut;
    private Transform portalInSpawnPoint, portalOutSpawnPoint;
    private Collider2D portalInCollider, portalOutCollider;

    void Start()
    {
        portalIn = GameObject.Find("Portal In").gameObject;
        portalOut = GameObject.Find("Portal Out").gameObject;

        portalInSpawnPoint = portalIn.transform.Find("Spawn Point");
        portalOutSpawnPoint = portalOut.transform.Find("Spawn Point");

        portalInCollider = portalIn.GetComponent<Collider2D>();
        portalOutCollider = portalOut.GetComponent<Collider2D>();

        instance = this;
    }

    public void CreateClone(string whereToCreate)
    {
        if (whereToCreate == "atIn")
        {
            var instantiatedClone = Instantiate(clone, portalInSpawnPoint.position, Quaternion.identity);
            instantiatedClone.gameObject.name = "Clone";
        }
        else if (whereToCreate == "atOut")
        {
            var instantiatedClone = Instantiate(clone, portalOutSpawnPoint.position, Quaternion.identity);
            instantiatedClone.gameObject.name = "Clone";
        }
    }

    public void DisableCollider(string colliderToDisable)
    {
        if (colliderToDisable == "out")
        {
            portalOutCollider.enabled = false;
        }
        else if (colliderToDisable == "in")
        {
            portalInCollider.enabled = false;
        }
    }

    public void EnableColliders()
    {
        portalOutCollider.enabled = true;
        portalInCollider.enabled = true;
    }

}
