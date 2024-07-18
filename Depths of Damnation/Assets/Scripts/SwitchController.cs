using UnityEngine;

public class SwitchController : MonoBehaviour
{
    [SerializeField] private Animator doorAnimator = null;
    [SerializeField] private string doorOpenAnimation = "DoorOpen";
    [SerializeField] private string doorCloseAnimation = "DoorClose";

    private bool isDoorOpen = false;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && gameObject.CompareTag("CrystalSwitch"))
        {
            if (Input.GetMouseButtonDown(0)) // Left mouse button click
            {
                if (isDoorOpen)
                {
                    doorAnimator.Play(doorOpenAnimation, 0, 0.0f);
                    isDoorOpen = false;
                }
                else
                {
                    doorAnimator.Play(doorCloseAnimation, 0, 0.0f);
                    isDoorOpen = true;
                }
            }
        }
    }
}
