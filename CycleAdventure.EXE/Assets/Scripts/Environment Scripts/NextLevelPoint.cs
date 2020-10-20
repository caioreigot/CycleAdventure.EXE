using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevelPoint : MonoBehaviour
{
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        Player Player = GameObject.Find("Player").GetComponent<Player>();

        if (collision.gameObject.tag == "Player")
        {
            Player.Desappear();
            LevelLoader.instance.LoadNextLevel();
        }
    }
    
}
