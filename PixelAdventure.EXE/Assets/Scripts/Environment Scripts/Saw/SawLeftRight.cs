using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawLeftRight : MonoBehaviour
{
    public float speed;
    public float moveTime;

    private bool dirRight = true;
    private float timer;

    void Update()
    {
        if (dirRight)
        {
            // If true, saw goes right
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        else
        {
            // Else, goes left
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }

        timer += Time.deltaTime;
        if (timer >= moveTime)
        {
            dirRight = !dirRight;
            timer = 0f;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Player.instance.Desappear();
            GameController.instance.ShowGameOver();
        }
    }
}
