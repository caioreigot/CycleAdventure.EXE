using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrototypeJoined : MonoBehaviour
{

    private GameObject prototypeJoined;
    private BoxCollider2D boxCollider2D;

    [Range(0, 5)]
    [SerializeField] float deactivateTime = 3f;

    void Start()
    {
        prototypeJoined = GameObject.Find("Canvas").transform.Find("Prototype Joined").gameObject;
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            boxCollider2D.enabled = false;
            prototypeJoined.SetActive(true);

            Invoke("DeactivateJoined", deactivateTime);
        }
    }

    void DeactivateJoined()
    {
        prototypeJoined.SetActive(false);
    }

}
