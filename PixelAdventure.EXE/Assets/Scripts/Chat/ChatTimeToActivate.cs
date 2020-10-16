using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatTimeToActivate : MonoBehaviour
{

    void Start()
    {
        Invoke("ActivateChat", 4f);
        gameObject.SetActive(false);
    }

    void ActivateChat()
    {
        gameObject.SetActive(true);
    }

}
