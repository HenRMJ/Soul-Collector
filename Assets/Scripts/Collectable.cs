using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    GameLogic gameLogic;

    private void Awake()
    {
        // this finds the game logic script so we don't have to hook it up for every collectable
        gameLogic = FindObjectOfType<GameLogic>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // this line checks if the player is colliding
        {
            gameLogic.Collect();

            if (gameLogic.GetNumberOfCollectables() == 0) // this destroys the parent if there is no more collectables
            {
                Destroy(gameObject.transform.parent.gameObject);
            }

            Destroy(gameObject);
        } 
    }
}
