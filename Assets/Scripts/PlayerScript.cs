using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    Rigidbody2D rb; //stores rigidbody of player; Rigidbody:component that allows a GameObject to react to real-time physics

    public Vector2 direction; //stores the player's direction
    public float speed; //stores the player speed
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Input.mousePosition; //makes a position of the cursor
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition); //turns that possition into something game objects can interact with

        direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y); //sets the desired direction in between the distances between the cursor and player
    
        transform.right = direction; //changes the player's direction (points the red(x) axis's direction towards the desired direction)

        rb.velocity = transform.right * speed * Time.deltaTime; //sets the velocity

        flipPlayer();
    }

    void flipPlayer() //function to flip player based on rotation
    {
        float currentScale = 0.5f; 

        // Get the world space up vector of the object
        Vector3 upVector = transform.up; //gets the green(y) axis direction

        // Check if the up vector points downward (y component < 0)
        if (upVector.y < 0f)
        {
            transform.localScale = new Vector3(currentScale, -currentScale, currentScale); //turns the y axis inside out
        }
        else
        {
            transform.localScale = new Vector3(currentScale, currentScale, currentScale); //turns the y axis inside out
        }
    }
}

