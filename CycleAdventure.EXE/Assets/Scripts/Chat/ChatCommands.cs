using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChatCommands : MonoBehaviour
{
    public static ChatCommands instance;

    void Start()
    {
        instance = this;
    }

    public void CheckCommand(string command)
    {
        command = command.ToLower();

        switch (command)
        {
            case "/help":
                ChatManager.instance.SendMessageToChat("[/restart] Restart the level", Message.MessageType.info);
                break;
            
            case "/restart":
                // Taking out the amount of apples picked up on the level
                StaticVariables.TotalScore = StaticVariables.AmountApplesLevelPast;

                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                break;

            default:
                break;
        }

    }
}
