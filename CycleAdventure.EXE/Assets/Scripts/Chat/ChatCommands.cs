using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChatCommands : MonoBehaviour
{

    public static ChatCommands instance;

    private GameObject spikeHeadParent;
    private GameObject sawParent;
    private Player Player;

    [HideInInspector] public bool modCommands; 
    private float playerNormalJumpForce;
   
    void Start()
    {
        playerNormalJumpForce = GameObject.Find("Player").GetComponent<Player>().jumpForce;

        instance = this;

        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            Invoke("SendMessageFirstLevel", 1f);
        }
    }

    void SendMessageFirstLevel()
    {
        ChatManager.instance.SendMessageToChat("Type /help to see the available commands.", Message.MessageType.info);
    }

    public void CheckCommand(string command)
    {
        command = command.ToLower();

        if (command == "/help")
        {
            ChatManager.instance.SendMessageToChat("[/restart] Restart the level", Message.MessageType.info);
            
            if (modCommands)
            {
                ChatManager.instance.SendMessageToChat("[/stoptraps] Freezes all level traps", Message.MessageType.info);
                ChatManager.instance.SendMessageToChat("[/resumetraps] Resume all level traps", Message.MessageType.info);
                ChatManager.instance.SendMessageToChat("[/highjump] Activates the high jump", Message.MessageType.info);
                ChatManager.instance.SendMessageToChat("[/normaljump] Disable high jump", Message.MessageType.info);
            }
        }
        
        if (command == "/restart")
        {
            // Taking out the amount of apples picked up on the level
            StaticVariables.TotalScore = StaticVariables.AmountApplesLevelPast;

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (command == "/stoptraps" && modCommands)
        {
            spikeHeadParent = GameObject.Find("Spike Heads").gameObject;
            sawParent = GameObject.Find("Saw's").gameObject;
            
            foreach (Transform child in spikeHeadParent.transform)
            {
                child.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            }

            foreach (Transform child in sawParent.transform)
            {
                child.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            }

            ChatManager.instance.SendMessageToChat("All traps freezed.", Message.MessageType.info);
        }

        if (command == "/resumetraps" && modCommands)
        {
            spikeHeadParent = GameObject.Find("Spike Heads").gameObject;
            sawParent = GameObject.Find("Saw's").gameObject;

            foreach (Transform child in spikeHeadParent.transform)
            {
                child.gameObject.GetComponent<Rigidbody2D>().constraints = ~RigidbodyConstraints2D.FreezePositionY;
            }

            foreach (Transform child in sawParent.transform)
            {
                child.gameObject.GetComponent<Rigidbody2D>().constraints = ~RigidbodyConstraints2D.FreezePositionY;
            }

            ChatManager.instance.SendMessageToChat("All traps resumed.", Message.MessageType.info);
        }

        if (command == "/highjump" && modCommands)
        {
            Player = GameObject.Find("Player").GetComponent<Player>();

            Player.jumpForce = 30f;

            ChatManager.instance.SendMessageToChat("High jump on.", Message.MessageType.info);
        }

        if (command == "/normaljump" && modCommands)
        {
            Player = GameObject.Find("Player").GetComponent<Player>();

            Player.jumpForce = playerNormalJumpForce;

            ChatManager.instance.SendMessageToChat("High jump off.", Message.MessageType.info);
        }
    }

}
