using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HW1ScriptManager : MonoBehaviour {

    // The player object.
    public GameObject player;

    // The initial spawn point.
    public Transform initialSpawnTransform;

    // Where the player currently spawns after dying.
    public Vector3 currentSpawnPoint;

    // How many gateways the player has passed through.
    public int currentScore;

    // How many gateways there are total.
    public int maxScore;

    // The text objs for displaying count (score) and a win message.
    public Text scoreText;
    public Text winText;

    // Use this for initialization
    void Start () {
        // Initialize the current spawn.
        currentSpawnPoint = initialSpawnTransform.position;

        // Initialize the score.
        currentScore = 0;

        // Initialize the text.
        winText.text = "";
        SetScoreText();

	}

    // Respawn the player at the latest spawn point.
    public void Respawn()
    {
        // Set the position to the spawn point.
        player.transform.position = currentSpawnPoint;

        // Zero out any left over velocity.
        player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        player.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    }

    // Bump the score up by one, and update the GUI appropriately.
    public void ProcessGatewayActivation(Gateway gateway)
    {
        // Increase the score.
        currentScore += 1;

        // Update the progress text.
        SetScoreText();

        // Update the spawn location.
        //currentSpawnPoint = gateway.spawnPointObject.transform.position;
    }

    // Create a standalone function that can update the 'countText' UI and check if the required amount to win has been achieved
    void SetScoreText()
    {
        // Update the text field of our 'countText' variable
        scoreText.text = "Progress: " + currentScore.ToString() + " / " + maxScore.ToString();
    }
}
