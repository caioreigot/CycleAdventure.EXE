using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlitchAreaController : MonoBehaviour
{

    private GameObject mainCamera;
    private GlitchEffect glitchScript;
    private bool colorGlitchCalled;
    private float glitchTimeExitCounter;

    [Header("Applied when OnTriggerEnter2D is called")]
    [Range(0, 1)]
    public float intensity = 0.27f; // 0.9f
    [Range(0, 1)]
    public float flipIntensity = 0.7f; // 1f
    [Range(0, 1)]
    public float colorIntensity = 0f; // 0.57f

    [Header("Buggy Color Blink")]
    [Tooltip("Makes the screen blink with the color intensity passed")]
    public bool colorGlitch;
    
    [Range(0, 1)]
    public float glitchIntensity = 1f;
    
    [Tooltip("Glitch interval, in seconds")]
    [Range(0, 3)]
    public float glitchInterval = 1.5f;

    [Range(0, 10)]
    public float glitchTimeExit = 1f;

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
            AudioManager.instance.MusicOnOff("off");

            glitchScript.intensity = intensity;
            glitchScript.flipIntensity = flipIntensity;
            glitchScript.colorIntensity = colorIntensity;
        }

        if (colorGlitch && !colorGlitchCalled)
        {
            StartCoroutine(ColorIntensityBug());
            colorGlitchCalled = true;
        }
    }

    IEnumerator ColorIntensityBug()
    {
        while (true)
        {
            yield return new WaitForSeconds(glitchInterval);

            glitchTimeExitCounter += 0.5f;

            if (glitchScript.colorIntensity != glitchIntensity)
                glitchScript.colorIntensity = glitchIntensity;
            else
                glitchScript.colorIntensity = 0;

            if (glitchTimeExitCounter >= glitchTimeExit)
                yield break;
        }
    }
}
