using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Prototype : MonoBehaviour
{

    public float speed; // 4.5
    private Rigidbody2D rig;

    private GameObject prototypeSpeak;
    private GameObject player;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
    }

    void Update()
    {
        //transform.position += new Vector3(1f, 0f, 0f) * Time.deltaTime * speed;
        rig.velocity = new Vector2(speed, rig.velocity.y);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        { 
            GameController.instance.gameOverCalledThisFrame = true;
            PrototypeController.instance.PrototypeSpeak();

            Destroy(player);
            Destroy(gameObject);
        }
    }

}
