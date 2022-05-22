using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    // Adjust the move speed of the player with a slider
    [Range(0f, 10f)] [SerializeField] float moveSpeed;

    Rigidbody2D myBody;
    Vector2 moveInput;


    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Run();
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
