using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MoveSnake : MonoBehaviour 
{
    public float movementSpeed = 0.5f;  // The speed at which the snake will move
    Vector3 movement;                   // The direction of movement, depending on last arrow key pressed

    int lifeCount;
    public Image life1;
    public Image life2;
    public Image life3;

    void Start()
    {
        lifeCount = 3;  // Snake begins with three lives
    }
	
	void Update () 
    {
        // Move left
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            movement = Vector3.left;
        }

        // Move up
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            movement = Vector3.up;
        }

        // Move right
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            movement = Vector3.right;
        }
        
        // Move down
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            movement = Vector3.down;
        }

        // Update position of game object
        transform.position += movement * movementSpeed * Time.deltaTime;
	}

    // Handle snake collision with wall
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Wall"))
        {
            gameObject.SetActive(false);
        }
     }
}
