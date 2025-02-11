using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private bool pickedUp = false; // A boolean to track whether or not this pickup has been collected or not
    private void OnTriggerEnter(Collider other) // OnTriggerEnter is a function that is called when a collider marked as a trigger collides with this object
    {  
        if (pickedUp) return; // We do not want to do anything if this pickup is already collected by the player

        // If the object this pickup was just touched by was the player: destroy this pickup object
        if (other.gameObject.CompareTag("Player"))
        {
            pickedUp = true; // Mark this pickup as collected so it cannot be interacted with more than once
            AudioManager.Instance.PlaySound("PickUp"); // Tell the AudioManager to play the SFX for picking this item up
            GameManager.Instance.UpdateScore(1); // Call the 'UpdateScore()' function from the GameManager script
            Destroy(this.gameObject);
        }
    }
}
