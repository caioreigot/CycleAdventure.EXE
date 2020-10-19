using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawUpAndDown : MonoBehaviour
{

    private Player Player;

    public float speed;
    public float moveTime;

    private float timer;

    [SerializeField] bool dirUp = true;

    void Start()
    {
        Player = GameObject.Find("Player").GetComponent<Player>();
    }

    void Update()
    {
        if (dirUp)
        {
            // If true, saw goes up
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }
        else
        {
            // Else, goes down
            transform.Translate(Vector2.down * speed * Time.deltaTime);
        }

        timer += Time.deltaTime;
        if (timer >= moveTime)
        {
            dirUp = !dirUp;
            timer = 0f;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Player.Desappear();
            GameController.instance.ShowGameOver();
        }
    }
    
}
