using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChatManager : MonoBehaviour
{

    public static ChatManager instance;

    public string username = "You";

    public int maxMessages = 20;

    public GameObject chat, chatPanel, textObject;
    public InputField chatBox;

    public Color playerMessage, caioMessage, info;

    [SerializeField]
    List<Message> messageList = new List<Message>();

    // Usage: SendMessageToChat(message, Message.MessageType.*whoIsSending*)

    void Start()
    {
        instance = this;

        chat = GameObject.Find("Canvas").transform.Find("Chat").gameObject;
        chatPanel = chat.transform.Find("Scroll View").transform.Find("Viewport").transform.Find("Content").gameObject;
        chatBox = chat.transform.Find("InputField").GetComponent<InputField>();
        textObject = Resources.Load("Text") as GameObject;
    }

    void Update()
    {

        // Open chat
        if (chat.activeSelf == false && Input.GetKeyDown(KeyCode.Return))
        {
            chat.SetActive(true);
        }

        // Close chat
        if (chat.activeSelf == true && Input.GetKeyDown(KeyCode.Escape))
        {
            chat.SetActive(false);
        }

        // Sending message with return key
        if (chatBox.text != "")
        {
            if (Input.GetKeyDown(KeyCode.Return) && !CaioManager.talking)
            {
                SendMessageToChat(username + ": " + chatBox.text, Message.MessageType.playerMessage);

                ChatCommands.instance.CheckCommand(chatBox.text);
                chatBox.text = "";
            }
        }
        // Focusing on chat after opening
        else
        {
            if (!chatBox.isFocused && Input.GetKeyDown(KeyCode.Return))
            {
                chatBox.ActivateInputField();
            }
        }
    }

    // Add message to messageList
    public void SendMessageToChat(string text, Message.MessageType messageType)
    {
        if (messageList.Count >= maxMessages)
        {
            Destroy(messageList[0].textObject.gameObject);
            messageList.Remove(messageList[0]);
        }
            

        Message newMessage = new Message();
        newMessage.text = text;

        GameObject newText = Instantiate(textObject, chatPanel.transform);

        newMessage.textObject = newText.GetComponent<Text>();

        newMessage.textObject.text = newMessage.text;
        newMessage.textObject.color = MessageTypeColor(messageType);

        messageList.Add(newMessage);

        // Show chat to player
        chat.SetActive(true);
    }

    Color MessageTypeColor(Message.MessageType messageType)
    {
        // Default
        Color color = info;

        switch (messageType)
        {
            case Message.MessageType.playerMessage:
                color = playerMessage;
                break;
                
            case Message.MessageType.caioMessage:
                color = caioMessage;
                break;

            case Message.MessageType.info:
                color = info;
                break;

            default:
                break;
        }

        return color;
    }

}

[System.Serializable]
public class Message
{
    public string text;
    public Text textObject;
    public MessageType messageType;

    public enum MessageType
    {
        playerMessage,
        caioMessage,
        info
    }
}
