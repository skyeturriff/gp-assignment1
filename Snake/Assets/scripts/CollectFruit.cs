using UnityEngine;
using System.Collections;

public class CollectFruit : MonoBehaviour 
{
    // The camera we will querying for rendering info
    public Camera sceneCamera;

    // Holds screen size information
    Vector2 screenBounds;   

	void Start () 
    {
        // Initialize screen size information
        screenBounds.y = sceneCamera.orthographicSize;  // Half total screen height
        screenBounds.x = (screenBounds.y * sceneCamera.aspect) / 2; // Half total screen width
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Fruit"))    // If snake hits a fruit
        {
            // Get a random position within screen bounds
            float randomX = Random.Range(-screenBounds.x, screenBounds.x);
            float randomY = Random.Range(-screenBounds.y, screenBounds.y);

            // Repsawn fruit at random position on the creen
            collider.gameObject.transform.position = new Vector2(randomX, randomY);
        }
    }
}
