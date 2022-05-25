using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    // Adjust the move speed of the player with a slider
    [Range(0f, 10f)] [SerializeField] float moveSpeed;
    [Range(0f, 10f)] [SerializeField] float jumpHeight;


    [SerializeField] Rigidbody2D myBody;
    [SerializeField] BoxCollider2D groundCheck;
    
    Vector2 moveInput;

    // Update is called once per frame
    void Update()
    {
        Run();
    }

    void OnJump(InputValue value)
    {
        if (groundCheck.IsTouchingLayers(LayerMask.GetMask("Ground"))) // checks if the player is touching the ground
        {
            Vector2 playerVelocity = new Vector2(myBody.velocity.x, myBody.velocity.y + jumpHeight); // makes a new variable that adds jump height to the velocity

            myBody.velocity = playerVelocity; // replaces the player velocity with (player velocity + jump height)
        }
    }

    // OnMove gets called by Input System whenever a value is detected
    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void Run()
    {
        // Prevents player from flying
        Vector2 playerVelocity = new Vector2(moveInput.x*moveSpeed, myBody.velocity.y);

        // Adds velocity to player's X value
        myBody.velocity = playerVelocity;
    }
}
