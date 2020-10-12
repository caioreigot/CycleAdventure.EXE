using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawUpAndDown : MonoBehaviour
{
    public float speed;
    public float moveTime;

    private float timer;

    [SerializeField] bool dirUp = true;

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
            Player.instance.Desappear();
            GameController.instance.ShowGameOver();
        }
    }
}
