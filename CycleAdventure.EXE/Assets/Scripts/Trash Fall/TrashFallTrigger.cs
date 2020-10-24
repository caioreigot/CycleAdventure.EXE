using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashFallTrigger : MonoBehaviour
{

    [SerializeField] GameObject trashFall;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            trashFall.SetActive(true);
            ChatManager.instance.SendMessageToChat("Player joined world of the deleted.", Message.MessageType.info);

            Destroy(gameObject);
        }
    }
}
