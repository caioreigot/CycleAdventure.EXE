using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlitchAreaController : MonoBehaviour
{

    private GameObject mainCamera;
    private GlitchEffect glitchScript;

    [Header("Applied when OnTriggerEnter2D is called")]
    [Range(0, 1)]
    public float intensity = 0.27f;
    [Range(0, 1)]
    public float flipIntensity = 0.7f;
    [Range(0, 1)]
    public float colorIntensity = 0f;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GameObject.Find("Main Camera");
        glitchScript = mainCamera.GetComponent<GlitchEffect>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            glitchScript.intensity = intensity;
            glitchScript.flipIntensity = flipIntensity;
            glitchScript.colorIntensity = colorIntensity;
        }
    }
}
