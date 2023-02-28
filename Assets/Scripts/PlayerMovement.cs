using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement Instance { get; private set; }

    // Adjust the move speed of the player with a slider
    [Range(0f, 20f)] [SerializeField] float moveSpeed;
    [Range(0f, 20f)] [SerializeField] float jumpHeight;
    [SerializeField] float acceleration;
    [Tooltip("Lower for more severe behavior")][Range(0f, 1f)][SerializeField] float cancelJumpAmount;
    [SerializeField] float coyoteTime;
    [SerializeField] float jumpBufferTime;

    [SerializeField] Rigidbody2D myBody;
    [SerializeField] BoxCollider2D groundCheck;


    Vector2 moveInput;
    GenereationGameJam2022 playerInputAction;

    float coyoteTimer;
    float direction = 1;
    float jumpBufferTimer;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("There is another PlayerMovement Instance " + Instance + " -" + transform);
            Destroy(gameObject);
            return;
        }
        Instance = this;

        playerInputAction = new GenereationGameJam2022();
    }

    private void OnEnable()
    {
        // this just subscribes to an event to check if they pressed the interact key
        playerInputAction.Player.Jump.started += StartJump;
        playerInputAction.Player.Jump.canceled += EndJump;
        playerInputAction.Player.Jump.Enable();
    }

    private void OnDisable()
    {
        // when this object is disabled this disables the subscription to the interact key
        playerInputAction.Player.Jump.performed -= StartJump;
        playerInputAction.Player.Jump.canceled -= EndJump;
        playerInputAction.Player.Jump.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        if (groundCheck.IsTouchingLayers(LayerMask.GetMask("Ground"))) { coyoteTimer = coyoteTime; } else
        {
            coyoteTimer -= Time.deltaTime;
        }

        if (jumpBufferTimer > 0f)
        {
            jumpBufferTimer -= Time.deltaTime;
        }

        Jump();
        Run();
        FlipPlayer();
    }

    void StartJump(InputAction.CallbackContext value)
    {
        jumpBufferTimer = jumpBufferTime;
    }

    private void Jump()
    {
        if (coyoteTimer > 0f && jumpBufferTimer > 0f) // checks if the player is touching the ground
        {
            Vector2 playerVelocity = new Vector2(myBody.velocity.x, myBody.velocity.y + jumpHeight); // makes a new variable that adds jump height to the velocity

            myBody.velocity = playerVelocity; // replaces the player velocity with (player velocity + jump height)
            AkSoundEngine.PostEvent("Jump_Event", gameObject);
            jumpBufferTimer = 0f;
        }
    }

    void EndJump(InputAction.CallbackContext value)
    {
        if (myBody.velocity.y > Mathf.Epsilon)
        {
            Vector2 playerVelocity = new Vector2(myBody.velocity.x, myBody.velocity.y * cancelJumpAmount);

            myBody.velocity = playerVelocity;

            coyoteTimer = 0f;
        }
    }

    // OnMove gets called by Input System whenever a value is detected
    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void Run()
    {
        if (myBody.velocity.x > moveSpeed && moveInput.x > Mathf.Epsilon) { return; }
        if (myBody.velocity.x < -moveSpeed && moveInput.x < Mathf.Epsilon) { return; }
        // Prevents player from flying
        Vector2 playerVelocity = new Vector2(myBody.velocity.x + moveInput.x*acceleration, myBody.velocity.y);

        // Adds velocity to player's X value
        myBody.velocity = playerVelocity;
    }

    private void FlipPlayer()
    {
        bool playerIsMoving = Mathf.Abs(myBody.velocity.x) > Mathf.Epsilon;

        if (moveInput.x > 0)
        {
            direction = 1f;
        }

        if (moveInput.x < 0)
        {
            direction = -1f;
        }

        if (playerIsMoving)
        {
            transform.localScale = new Vector2(direction, 1f);
        }
    }
}
