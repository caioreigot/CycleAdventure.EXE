using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevelPoint : MonoBehaviour
{
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        Player Player = FindObjectOfType<Player>();

        if (collision.gameObject.tag == "Player")
        {
            FindObjectOfType<AudioManager>().Play("Next Level");

            Player.Desappear();
            LevelLoader.instance.LoadNextLevel();
        }
    }
    
}
