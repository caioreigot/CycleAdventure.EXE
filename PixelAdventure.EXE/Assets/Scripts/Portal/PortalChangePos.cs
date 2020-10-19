using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalChangePos : MonoBehaviour
{
    public void ChangePosition(Vector3 position)
    {
        transform.position = position;
    }
}
