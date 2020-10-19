using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaioSendMessages : MonoBehaviour
{

    public Message.MessageType messageType = Message.MessageType.caioMessage;
    public static bool caioTalking;

    void Start()
    {
        Invoke("StartCoroutine", 4f);
        caioTalking = true;
    }

    void StartCoroutine()
    {
        StartCoroutine(SendMessages());
    }

    IEnumerator SendMessages()
    {
        ChatManager.instance.SendMessageToChat(
            "Caio: What the hell happened here?!", messageType);

        yield return new WaitForSeconds(8f);

        ChatManager.instance.SendMessageToChat(
            "Caio: Oh! Sorry, I didn't introduce myself, I'm the guy who wrote the signs you read, I'm the creator of the game", messageType);

        yield return new WaitForSeconds(13f);

        ChatManager.instance.SendMessageToChat(
            "Caio: I saw what happened to you at the last level, I need to tell you something", messageType);

        yield return new WaitForSeconds(11f);

        ChatManager.instance.SendMessageToChat(
            "Caio: That bizarre thing is the second player I designed, I didn't use it because its texture was all buggy, initially I thought it was a sprite configuration problem", messageType);
        
        yield return new WaitForSeconds(13f);

        ChatManager.instance.SendMessageToChat(
            "Caio: It seems that he hates those who play this game, for not being able to participate and for not being able to get the reward at the end", messageType);
        
        yield return new WaitForSeconds(13f);

        ChatManager.instance.SendMessageToChat(
            "Caio: He had only appeared once while I was finishing the game, and after I deleted everything related to him, he stopped showing up, I don't know what's going on", messageType);
        
        yield return new WaitForSeconds(13f);
        
        ChatManager.instance.SendMessageToChat(
            "Caio: You better get out while I try to fix this, come back tomorrow and I'll tell you what happened, if I don't come here, don't play!", messageType);
        
        yield return new WaitForSeconds(13f);
        
        ChatManager.instance.SendMessageToChat(
            "Caio: Sorry about that, see ya!", messageType);

        yield return new WaitForSeconds(4f);

        caioTalking = false;
        CaioDisconnect.instance.Disconnect();
    }
    
}
