using UnityEngine;
using TMPro;

public class TerminalController : MonoBehaviour
{
    public GameObject uiPanel; // Reference to the UI Panel
    public float detectionRadius = 3f; // Detection radius for the player
    public LayerMask playerLayer; // Layer for detecting the player
    public GameObject player; // Reference to the player GameObject
    public TextMeshPro floatingText; // Reference to the TextMeshPro component for floating text

    private PlayerController playerController; // Reference to the PlayerController script
    private bool isPlayerNearby = false;

    void Start()
    {
        // Get the PlayerController component from the player GameObject
        playerController = player.GetComponent<PlayerController>();
        // Initially disable the floating text
        floatingText.gameObject.SetActive(false);
    }

    void Update()
    {
        DetectPlayer();
        
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E))
        {
            bool uiActive = !uiPanel.activeSelf;
            uiPanel.SetActive(uiActive); // Toggle the UI Panel

            // Enable or disable the PlayerController based on the UI state
            playerController.enabled = !uiActive;
        }
    }

    void DetectPlayer()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, detectionRadius, playerLayer);
        if (hitColliders.Length > 0)
        {
            if (!isPlayerNearby)
            {
                isPlayerNearby = true;
                ShowFloatingText("Hello, and welcome to the Crystal Lab on Planet ???, Enter the code to enter");
            }
        }
        else
        {
            if (isPlayerNearby)
            {
                isPlayerNearby = false;
                HideFloatingText();
            }
        }
    }

    void ShowFloatingText(string message)
    {
        floatingText.text = message;
        floatingText.gameObject.SetActive(true);
    }

    void HideFloatingText()
    {
        floatingText.gameObject.SetActive(false);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
