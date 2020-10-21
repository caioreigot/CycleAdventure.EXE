using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JumpLevel : MonoBehaviour
{
    void Start()
    {
        // After closing the game at Level_8, will load scene Level_9
        if (PlayerPrefs.GetInt("AfterQuit", 0) == 1)
        {
            StaticVariables.TotalScore = PlayerPrefs.GetInt("ApplesWhenQuit", 0);
            SceneManager.LoadScene(11);
        }
    }
}
