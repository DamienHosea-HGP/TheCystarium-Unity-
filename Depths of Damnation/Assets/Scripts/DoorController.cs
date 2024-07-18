using UnityEngine;

public class DoorController : MonoBehaviour
{
    public Animator doorAnimator;
    public string parameterName = "character_nearby";
    public float detectionRadius = 5f;
    public string playerLayerName = "Player";  // The name of the player layer

    private bool isCharacterNearby = false;
    private LayerMask playerLayer;

    void Start()
    {
        // Convert the layer name to a LayerMask
        playerLayer = LayerMask.GetMask(playerLayerName);
    }

    void Update()
    {
        DetectCharacter();
        doorAnimator.SetBool(parameterName, isCharacterNearby);
    }

    void DetectCharacter()
    {
        // Check for colliders in the specified layer within the detection radius
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, detectionRadius, playerLayer);
        if (hitColliders.Length > 0)
        {
            isCharacterNearby = true;
        }
        else
        {
            isCharacterNearby = false;
        }
    }

    void OnDrawGizmosSelected()
    {
        // Visualize the detection radius in the Scene view
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
