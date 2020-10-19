using System.Runtime.InteropServices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PortalController : MonoBehaviour
{

    public static PortalController instance;

    [SerializeField] GameObject clone;

    private GameObject portalIn, portalOut;
    private Transform portalInSpawnPoint, portalOutSpawnPoint;
    private Collider2D portalInCollider, portalOutCollider;
    private CinemachineVirtualCamera vcam;
    private Vector3 vcamPos;

    void Start()
    {
        portalIn = GameObject.Find("Portal In").gameObject;
        portalOut = GameObject.Find("Portal Out").gameObject;

        portalInSpawnPoint = portalIn.transform.Find("Spawn Point");
        portalOutSpawnPoint = portalOut.transform.Find("Spawn Point");

        portalInCollider = portalIn.GetComponent<Collider2D>();
        portalOutCollider = portalOut.GetComponent<Collider2D>();

        vcam = GameObject.Find("CM vcam1").GetComponent<CinemachineVirtualCamera>();
        vcamPos = GameObject.Find("CM vcam1").transform.position;

        instance = this;
    }

    public void CreateClone(string whereToCreate)
    {
        if (whereToCreate == "atIn")
        {
            var instantiatedClone = Instantiate(clone, portalInSpawnPoint.position, Quaternion.identity);
            instantiatedClone.gameObject.name = "Clone";
            vcam.m_Follow = instantiatedClone.transform;
        }
        else if (whereToCreate == "atOut")
        {
            var instantiatedClone = Instantiate(clone, portalOutSpawnPoint.position, Quaternion.identity);
            instantiatedClone.gameObject.name = "Clone";
            vcam.m_Follow = instantiatedClone.transform;
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
