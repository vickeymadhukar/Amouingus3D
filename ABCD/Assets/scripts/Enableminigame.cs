using UnityEngine;
using UnityEngine.UI;

public class Enableminigame : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public Transform objectToEnable; // Reference to the object whose button will be enabled
    public float activationDistance = 5f; // Distance at which the button gets enabled
    public Button miniGameButton; // Reference to the button that triggers the mini-game

    private bool isWithinRange = false;

    void Update()
    {
        // Calculate the distance between the player and the object
        float distance = Vector3.Distance(player.position, objectToEnable.position);

        // Check if the player is within the activation distance
        if (distance <= activationDistance)
        {
            isWithinRange = true;
            miniGameButton.interactable = true; // Enable the button
        }
        else
        {
            isWithinRange = false;
            miniGameButton.interactable = false; // Disable the button
        }
    }

    // Method to be called when the button is pressed
    public void StartMiniGame()
    {
        if (isWithinRange)
        {
            // Call a method to start the mini-game
            Debug.Log("Starting Mini-Game!");
        }
        else
        {
            Debug.Log("Player is not within range to start Mini-Game.");
        }
    }
}
