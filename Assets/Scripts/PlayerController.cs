using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Vector2 playerVelocity;

    [SerializeField] float speed;

    private Rigidbody2D rb;
    private SpriteRenderer sprRend;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprRend = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // TODO: use arrow keys and/or WASD to move around

        UpdateVelocity();
    }

    private void UpdateVelocity()
    {
        //declare a new Vector2 (an x direction and a y direction), and set it equal to the rigidbody's current velocity
        Vector2 newVelocity = rb.velocity; 

        if (Input.GetKey(KeyCode.LeftArrow)) //If we are pressing the left arrow
        {
            newVelocity.x = -speed; //set to x value to be negative speed (because speed is a number)
            sprRend.flipX = true; //set to true to tell player is going left
        }

        else if (Input.GetKey(KeyCode.RightArrow)) // If you are pressing the right arrow
        {
            newVelocity.x = speed; //Set the x value to be speed
            sprRend.flipX = false;  //set to false to tell player is going right
        }
        
        else //If we are not pressing either the left or right arrow keys...
        {
            newVelocity.x = 0; // remove velocity
            sprRend.flipX = false; //set to false to tell player is not facing left
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            newVelocity.y = speed;
        }

        else if (Input.GetKey(KeyCode.DownArrow))
        {
            newVelocity.y = -speed;
        }

        else
        {
            newVelocity.y = 0;
        }

        //When we've worked out what the velocity should be, we write the value back onto our rigidbody so it will move
        rb.velocity = newVelocity;
        playerVelocity = newVelocity;
    }
}
