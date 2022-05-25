using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    // Values you want each to be when you enter water
    [SerializeField] Rigidbody2D player;
    [SerializeField] float gravity;
    [SerializeField] float drag;
    [SerializeField] float mass;

    float startingGravity;
    float startingDrag;
    float startingMass;

    // Start is called before the first frame update
    void Start()
    {
        startingGravity = player.gravityScale;
        startingDrag = player.drag;
        startingMass = player.mass;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player.gravityScale = gravity;
            player.drag = drag;
            player.mass = mass;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player.gravityScale = startingGravity;
            player.drag = startingDrag;
            player.mass = startingMass;
        }
    }
}
