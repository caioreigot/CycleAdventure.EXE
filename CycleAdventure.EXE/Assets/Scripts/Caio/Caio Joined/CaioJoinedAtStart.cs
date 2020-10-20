using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaioJoinedAtStart : MonoBehaviour
{

    void Start()
    {
        Invoke("DeactivateJoined", 4f);
    }

    void DeactivateJoined()
    {
        gameObject.SetActive(false);
    }

}
