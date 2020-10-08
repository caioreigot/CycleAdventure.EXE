using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    private SpriteRenderer sr;
    private CircleCollider2D circle;

    public GameObject collected;
    public int score;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        circle = GetComponent<CircleCollider2D>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            // Desabling collider and sprite renderer
            sr.enabled = false;
            circle.enabled = false;
            
            // Making the effect of collecting appear
            collected.SetActive(true);

            StaticVariables.TotalScore += score;

            GameController.instance.UpdateScoreText();

            Destroy(gameObject, 0.25f);
        }
    }
}
