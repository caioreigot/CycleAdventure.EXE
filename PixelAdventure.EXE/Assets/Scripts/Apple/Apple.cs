using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    private SpriteRenderer sr;
    private CircleCollider2D circle;

    public GameObject collected;
    public int score;

    // Para saber quantas maças foram pegas na scene (pra subtrair do score, caso o jogador perca)
    public static int sceneScoreEarned; // [!] Resetado no script LevelLoader

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        circle = GetComponent<CircleCollider2D>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            // Desativando o colisor e o sprite renderer
            sr.enabled = false;
            circle.enabled = false;
            // Fazendo o efeito de coletar aparecer
            collected.SetActive(true);

            StaticVariables.TotalScore += score;
            sceneScoreEarned += score;

            GameController.instance.UpdateScoreText();

            Destroy(gameObject, 0.25f);
        }
    }
}
