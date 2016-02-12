using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CollectFruit : MonoBehaviour 
{

    public Camera sceneCamera;  // The camera we will querying for screen size info
    Vector2 screenBounds;       // Holds screen size information 
    public Text scoreText;      // Displays current score to user
    int score;                  // Holds the current score

	void Start () 
    {
        // Initialize screen size information
        screenBounds.y = sceneCamera.orthographicSize;              // Half total screen height
        screenBounds.x = (screenBounds.y * sceneCamera.aspect) / 2; // Half total screen width
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Fruit"))    // If snake hits a fruit
        {
            RespawnFruit(collider.gameObject);          // Respawn it in a new location
            UpdateScore();                              // Update user's score
        }
    }

    void RespawnFruit(GameObject fruit)
    {
        // Get a random position within screen bounds
        float randomX = Random.Range(-screenBounds.x, screenBounds.x);
        float randomY = Random.Range(-screenBounds.y, screenBounds.y);

        // Repsawn fruit at random position
        fruit.transform.position = new Vector2(randomX, randomY);
    }

    void UpdateScore()
    {
        ++score;                                        // Increment user's score
        scoreText.text = "Score: " + score.ToString();  // Update score display text
    }
}
