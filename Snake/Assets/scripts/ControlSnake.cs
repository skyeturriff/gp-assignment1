using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/*
 * This class controls the movement of the snake around the game world, and handles 
 * any collision with the walls. Each frame, Update() checks for an arrow key input
 * from the user, and updates the direction the snake travels according to that input.
 * The snake moves at a predefined constant speed. If the snake collides with a wall,
 * one of the lives are decrimented. If all lives are used, the game is over, and 
 * the user can return to the main menu.
 */ 
public class ControlSnake : MonoBehaviour 
{
    public float movementSpeed;         // The speed at which the snake will move
    Vector3 movement;                   // The direction of movement, depending on last arrow key pressed

    int lifeCount;                      // The current number of lives the snake has
    public Image life1;                 // Images representing each life
    public Image life2;
    public Image life3;
    Image[] lives;                      // Used to store life representations

    public Text gameOverText;           // Notifies the user that they have died
    public Button gameOverButton;       // Allows user to navigate back to menu

    void Start()
    {
        lifeCount = 3;                                  // Snake begins with three lives
        lives = new Image[] { life1, life2, life3 };    // Store lives
    }
	
    // Each frame, check for a change in the snake's direction
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

        // Update position of snake
        transform.position += movement * movementSpeed * Time.deltaTime;
	}

    // Handle snake collision with wall
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Wall"))
        {
            if (lifeCount > 0) // If snake still has lives left, decriment one
            {
                --lifeCount;
                lives[lifeCount].gameObject.SetActive(false);
            }
            if (lifeCount == 0) // Game is over
            {
                gameObject.SetActive(false);                // Deactivate snake
                gameOverText.gameObject.SetActive(true);    // Activate game over GUI
                gameOverButton.gameObject.SetActive(true); 
            }
        }
     }
}
