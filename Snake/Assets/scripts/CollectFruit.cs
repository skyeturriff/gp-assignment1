using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CollectFruit : MonoBehaviour 
{
    public Camera sceneCamera;      // The camera we will querying for screen size info
    Vector2 screenBounds;           // Holds screen size information 
    public Text scoreText;          // Displays current score to user
    int score;                      // Holds the user's current score
    public GameObject snakePrefab;  // Object to add onto snake body
    int offset;             // Distance from head to first snake unit

    // Initialize screen size information
    void Start()
    {
        screenBounds.y = sceneCamera.orthographicSize;              // Half total screen height
        screenBounds.x = (screenBounds.y * sceneCamera.aspect) / 2; // Half total screen width
        offset = 3;
    }

    // Handle fruit collecion by snake
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Fruit"))                // If snake hits a fruit
        {
            UpdateScore();                                          // Update user's score
            SpawnSnakeUnit();                                       // Add unit onto snake
            MoveFruit(collider.gameObject);                         // Respawn fruit in a new location
        }
    }

    // Get a random position within screen bounds and move fruit
    void MoveFruit(GameObject fruit)
    {
        float randomX = Random.Range(screenBounds.x*(-1), screenBounds.x);
        float randomY = Random.Range(screenBounds.y*(-1), screenBounds.y);
        fruit.transform.position = new Vector2(randomX, randomY);
    }

    // Increment user's score and update score display
    void UpdateScore()
    {
        ++score;
        scoreText.text = "Score: " + score.ToString();
    }

    void SpawnSnakeUnit()
    {
        GameObject spawnedSnakeUnit = GameObject.Instantiate(snakePrefab);
        spawnedSnakeUnit.transform.parent = transform;
        
        // Spawn new unit at a distance of offset * the number of current units
        spawnedSnakeUnit.transform.localPosition = new Vector3(offset*score, 0, 0);
    }
}
