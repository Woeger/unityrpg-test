using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Fighter {
    //BoxCollider for collision
    private BoxCollider2D boxCollider;

    //Variable to hold difference between players position and how far player has moved
    private Vector3 moveDelta;

    //Raycast for collision detection
    private RaycastHit2D hit;

    //Start method - Runs on 1st frame
    private void Start() {
        //Get instance of BoxCollider when player is created on start
        boxCollider = GetComponent<BoxCollider2D>();
    }

    //Function to update on each frame
    private void FixedUpdate() {
        //Get x + y input, set to floats
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        //Reset moveDelta with input values
        moveDelta = new Vector3(x, y, 0);

        //Swap sprite direction
        if(moveDelta.x > 0) {
            transform.localScale = Vector3.one;
        }
        else if(moveDelta.x < 0) {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        //Updating Raycast for y axis, checking for Blocking + Actor collisions
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("Actor","Blocking"));
        
        //If collider is null, no collision so can update y axis
        if (hit.collider == null) {
            //Move on y axis based on updated vector
            transform.Translate(0, moveDelta.y * Time.deltaTime, 0);
        }

        //Updating Raycast for x axis, checking for Blocking + Actor collisions
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(moveDelta.x, 0), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Actor","Blocking"));
        
        //If collider is null, no collision so can update x axis
        if (hit.collider == null) {
            //Move on x axis based on updated vector
            transform.Translate(moveDelta.x * Time.deltaTime, 0, 0);
        }
        
    }
}
