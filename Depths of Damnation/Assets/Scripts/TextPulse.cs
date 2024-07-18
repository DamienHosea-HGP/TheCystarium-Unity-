using UnityEngine;
using TMPro;

public class PulseText : MonoBehaviour
{
    public float pulseSpeed = 1.0f; // Speed of the pulsing effect
    public float maxScale = 1.2f;   // Maximum scale
    public float minScale = 0.8f;   // Minimum scale

    private TextMeshProUGUI textComponent;
    private Vector3 originalScale;

    void Start()
    {
        textComponent = GetComponent<TextMeshProUGUI>();
        originalScale = textComponent.transform.localScale;
    }

    void Update()
    {
        // Calculate the pulsing scale factor
        float scale = minScale + Mathf.PingPong(Time.time * pulseSpeed, maxScale - minScale);
        
        // Ensure the scale is valid
        if (scale > 0 && !float.IsNaN(scale))
        {
            textComponent.transform.localScale = originalScale * scale;
        }
    }
}
