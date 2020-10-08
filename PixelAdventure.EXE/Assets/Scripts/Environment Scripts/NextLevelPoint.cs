using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevelPoint : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Player.instance.Desappear();
            LevelLoader.instance.LoadNextLevel();
        }
    }
}
