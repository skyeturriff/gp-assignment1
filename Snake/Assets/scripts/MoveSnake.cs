using UnityEngine;
using System.Collections;

public class MoveSnake : MonoBehaviour 
{
    // The speed at which the snake will move
    public float movementSpeed = 0.5f;

    // The direction of movement, depending on last arrow key pressed
    Vector3 movement;
	
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
}
