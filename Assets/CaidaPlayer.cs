using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaidaPlayer : MonoBehaviour
{

     public GameObject player;

    void Start()
    {
        // Ensure the player reference is set in the Inspector
        if (player == null)
        {
            Debug.LogError("CaidaPlayer: Please assign the Player object in the Inspector!");
        }
    }

    // Called whenever a Collider2D (other) enters the trigger collider attached to this object
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the colliding object is the Player
        if (other.gameObject == player)
        {
            // Perform the desired action when the Player collides
            Debug.Log("Player has fallen!"); // Replace with your actual logic (e.g., play a sound effect, trigger an animation, decrease health)

            // Optional: Prevent further collision detection if needed
            // this.GetComponent<Collider2D>().enabled = false; // Disable this collider
        }
    }
}
