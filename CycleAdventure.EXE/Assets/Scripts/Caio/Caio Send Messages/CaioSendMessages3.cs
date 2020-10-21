using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaioSendMessages3 : MonoBehaviour
{

    [HideInInspector] public Message.MessageType messageType = Message.MessageType.caioMessage;

    void Start()
    {
        Invoke("StartCoroutine", 1f);
    }

    void StartCoroutine()
    {
        CaioManager.talking = true;
        StartCoroutine(SendMessages());
    }

    IEnumerator SendMessages()
    {
        ChatCommands.instance.modCommands = false;

        ChatManager.instance.SendMessageToChat(
            "You have been demoted from moderator to player.", Message.MessageType.info);

        yield return new WaitForSeconds(7f);

        ChatManager.instance.SendMessageToChat(
            "Caio: Hey, it wasn't me who got your moderator permission! But im glad that the commands helped you at the last level", messageType);

        yield return new WaitForSeconds(10f);

        ChatManager.instance.SendMessageToChat(
            "Caio: Player_0 is still on the server, I can't see where it is or what it is doing, but apparently everything is normal", messageType);

        yield return new WaitForSeconds(10f);
        
        ChatManager.instance.SendMessageToChat(
            "Caio: He's not letting me do anything on the server, but I managed to program a script so that when you take the final level trophy, it really deletes player_0 once and for all, and guess what, this is the last level", messageType);

        yield return new WaitForSeconds(6f);

        ChatManager.instance.SendMessageToChat(
            "Caio: You can do it, sorry for all this", messageType);

        CaioManager.talking = false;
    }

}
