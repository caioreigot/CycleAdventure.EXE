using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrototypeRunning : MonoBehaviour
{

    public float speed;
    private Rigidbody2D rig;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //transform.position += new Vector3(1f, 0f, 0f) * Time.deltaTime * speed;
        rig.velocity = new Vector2(speed, rig.velocity.y);
    }

}
