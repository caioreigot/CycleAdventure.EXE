using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaioSendMessages2 : MonoBehaviour
{

    [HideInInspector] public Message.MessageType messageType = Message.MessageType.caioMessage;
    private bool onTriggerEnterCalled = false;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (!onTriggerEnterCalled)
        {
            onTriggerEnterCalled = true;
            Invoke("StartCoroutine", 4f);
        }
        else return;
    }

    void StartCoroutine()
    {
        CaioManager.talking = true;
        StartCoroutine(SendMessages());
    }

    IEnumerator SendMessages()
    {
        ChatManager.instance.SendMessageToChat(
            "Caio: Heey, why didn't you stop playing?!", messageType);

        yield return new WaitForSeconds(8f);

        ChatManager.instance.SendMessageToChat(
            "Caio: What he is doing?? I don't remember making the map that way, he messed with something", messageType);

        yield return new WaitForSeconds(10f);

        ChatManager.instance.SendMessageToChat(
            "Caio: He's not letting me configure the map to help you, I'll give you server moderator permissions, try to do something with the commands", messageType);

        yield return new WaitForSeconds(8f);

        ChatCommands.instance.modCommands = true;

        ChatManager.instance.SendMessageToChat(
            "You have been promoted to moderator.", Message.MessageType.info);

        yield return new WaitForSeconds(3f);

        ChatManager.instance.SendMessageToChat(
            "Caio: Done! Type /help to see them", messageType);

        CaioManager.talking = false;
    }

}
