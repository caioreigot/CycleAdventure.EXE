using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterTreshCutscene : MonoBehaviour
{

    private bool onTriggerEnterCalled = true;

    [SerializeField] GameObject trash;
    [SerializeField] GameObject prototype;
    [SerializeField] GameObject spikeHeads; // 4
    [SerializeField] GameObject spikes; // 41
    [SerializeField] GameObject colliders; // 10

    List<GameObject> spikeChildren = new List<GameObject>();
    List<GameObject> spikeHeadsChildren = new List<GameObject>();
    List<GameObject> collidersChildren = new List<GameObject>();
    
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (onTriggerEnterCalled)
            onTriggerEnterCalled = false;
        else
            return;
        
        // Destroying garbage
        Destroy(trash);

        // Destroying prototype
        Destroy(prototype);

        // Destroying spikes placed before (until 42)
        foreach (Transform child in spikes.transform)
        {
            spikeChildren.Add(child.gameObject);
        }

        for (int i = 0; i < 42; i++)
        {
            Destroy(spikeChildren[i]);
        }

        // Destroying spike heads placed before (until 4)
        foreach (Transform child in spikeHeads.transform)
        {
            spikeHeadsChildren.Add(child.gameObject);
        }

        for (int i = 0; i < 4; i++)
        {
            Destroy(spikeHeadsChildren[i]);
        }

        // Destroying colliders placed before (until 42)
        foreach (Transform child in colliders.transform)
        {
            collidersChildren.Add(child.gameObject);
        }

        for (int i = 0; i < 10; i++)
        {
            Destroy(collidersChildren[i]);
        }

        Destroy(gameObject);
    }

}
