using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    // Adjust the move speed of the player with a slider
    [Range(0f, 20f)] [SerializeField] float moveSpeed;
    [Range(0f, 20f)] [SerializeField] float jumpHeight;

    [SerializeField] Rigidbody2D myBody;
    [SerializeField] BoxCollider2D groundCheck;
    [SerializeField] GameLogic gameLogic;
    [SerializeField] Image[] imgs;
    [SerializeField] Sprite gamepadUI;
    [SerializeField] Sprite keyboardUI;

    const string _KEY = "Keyboard&Mouse";
    const string _PAD = "Gamepad";

    Vector2 moveInput;

    // Update is called once per frame
    void Update()
    {
        Run();
        FlipPlayer();
    }

    void OnJump(InputValue value)
    {
        if (groundCheck.IsTouchingLayers(LayerMask.GetMask("Ground"))) // checks if the player is touching the ground
        {
            Vector2 playerVelocity = new Vector2(myBody.velocity.x, myBody.velocity.y + jumpHeight); // makes a new variable that adds jump height to the velocity

            myBody.velocity = playerVelocity; // replaces the player velocity with (player velocity + jump height)
            gameLogic.GetAudio().PlaySound("jump");
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
        Vector2 playerVelocity = new Vector2(Mathf.Clamp(myBody.velocity.x + moveInput.x*moveSpeed, -moveSpeed, moveSpeed), myBody.velocity.y);

        // Adds velocity to player's X value
        myBody.velocity = playerVelocity;
    }

    private void FlipPlayer()
    {
        bool playerIsMoving = Mathf.Abs(myBody.velocity.x) > Mathf.Epsilon;

        if (playerIsMoving)
        {
            transform.localScale = new Vector2(Mathf.Sign(myBody.velocity.x), 1f);
        }
    }

    void OnControlsChanged()
    {
        var controls = GetComponent<PlayerInput>().currentControlScheme;

        foreach (Image img in imgs)
        {
            if (controls == _PAD)
            {
                img.sprite = gamepadUI;
            }
            else if (controls == _KEY)
            {
                img.sprite = keyboardUI;
            }
        }
    }
}
