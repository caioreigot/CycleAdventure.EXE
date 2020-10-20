using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChatCommands : MonoBehaviour
{

    public static ChatCommands instance;
    [HideInInspector] public bool modCommands; 

    private GameObject spikeHeadParent;

    void Start()
    {
        instance = this;
    }

    public void CheckCommand(string command)
    {
        command = command.ToLower();

        if (command == "/help")
        {
            ChatManager.instance.SendMessageToChat("[/restart] Restart the level", Message.MessageType.info);
            ChatManager.instance.SendMessageToChat("[/stoptraps] Freezes all level traps", Message.MessageType.info);
            ChatManager.instance.SendMessageToChat("[/resumetraps] Resume all level traps", Message.MessageType.info);
        }
        
        if (command == "/restart")//&& modCommands)
        {
            // Taking out the amount of apples picked up on the level
            StaticVariables.TotalScore = StaticVariables.AmountApplesLevelPast;

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (command == "/stoptraps")//&& modCommands)
        {
            spikeHeadParent = GameObject.Find("Spike Heads").gameObject;
            
            foreach (Transform child in spikeHeadParent.transform)
            {
                child.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            }

            ChatManager.instance.SendMessageToChat("All traps freezed.", Message.MessageType.info);
        }

        if (command == "/resumetraps")
        {
            spikeHeadParent = GameObject.Find("Spike Heads").gameObject;

            foreach (Transform child in spikeHeadParent.transform)
            {
                child.gameObject.GetComponent<Rigidbody2D>().constraints = ~RigidbodyConstraints2D.FreezePositionY;
            }

            ChatManager.instance.SendMessageToChat("All traps resumed.", Message.MessageType.info);
        }
    }

}
