using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalAnimManager : MonoBehaviour
{

    [SerializeField] GameObject portal;
    [SerializeField] GameObject nextLevelPoint;

    void Start()
    {
        Invoke("EnablePortal", 2f);
        Invoke("DisablePortal", 3.2f);
    }

    void EnablePortal()
    {
        portal.SetActive(true);

        Invoke("ThrowNextLevelPoint", 0.28f);
    }

    void DisablePortal()
    {
        portal.SetActive(false);
    }

    void ThrowNextLevelPoint()
    {
        nextLevelPoint.GetComponent<Rigidbody2D>().constraints = ~RigidbodyConstraints2D.FreezePositionY;

        Invoke("StartAnimation", 1f);
    }

    void StartAnimation()
    {
        nextLevelPoint.GetComponent<Animator>().enabled = true;
    }

}
