using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrototypeSpawnTrigger : MonoBehaviour
{

    private GameObject prototype;

    void Start()
    {
        prototype = GameObject.Find("Prototype");
        prototype.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            prototype.SetActive(true);
        }
    }

}
