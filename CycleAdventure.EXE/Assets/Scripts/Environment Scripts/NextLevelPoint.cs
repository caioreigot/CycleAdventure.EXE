using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevelPoint : MonoBehaviour
{

    private Player Player;

    void Start()
    {
        Player = GameObject.Find("Player").GetComponent<Player>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Player.Desappear();
            LevelLoader.instance.LoadNextLevel();
        }
    }
    
}
