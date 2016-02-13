using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/*
 * This class first gets the size of the viewport of the camera. This information is
 * used to repawn the fruit at random locations within the screen bounds after it has
 * been collected. When a fruit is collected, the user's score is incremented by one,
 * a new body unit is spawned onto the snake at a predefined offset from the head,
 * taking into consideration the distance to the last "tail" unit. The fruit is then
 * moved to a new location.
 */
public class CollectFruit : MonoBehaviour 
{
    public Camera sceneCamera;      // The camera we will querying for screen size info
    Vector2 screenBounds;           // Holds screen size information 
    public Text scoreText;          // Displays current score to user
    int score;                      // Holds the user's current score
    public GameObject snakePrefab;  // Object to add onto snake body
    int offset;                     // Distance from head to first snake unit

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
        // Spawn a new unit and make the snake head its parent
        GameObject spawnedSnakeUnit = GameObject.Instantiate(snakePrefab);
        spawnedSnakeUnit.transform.parent = transform;
        
        // Spawn new unit at a distance from the head of offset * the number of current units
        spawnedSnakeUnit.transform.localPosition = new Vector3(offset*score, 0, 0);
    }
}
