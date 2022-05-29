using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    // This is just a field to turn alpha to 1
    Color on = new Color(1,1,1,1);

    SpriteRenderer render;
    GameLogic gameLogic;
    int nextScene;

    // Start is called before the first frame update
    void Start()
    {
        gameLogic = FindObjectOfType<GameLogic>();
        nextScene = SceneManager.GetActiveScene().buildIndex + 1;
        render = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (render.color.a == 1) { return; } // if the portal is already visually on, this stops the rest of the code

        // If the player has collected all the collectables, this visually turns on the portal
        if (gameLogic.HasWon())
        {
            render.color = on;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        bool isPlayer = collision.CompareTag("Player"); // Sets isPlayer to true or false depending on whether the player is colliding with the game object

        if (isPlayer && SceneManager.sceneCountInBuildSettings <= nextScene) // if there isn't a next scene it will warn you in the console
        {
            Debug.LogWarning("No next level, or you have to put the next level in the build settings.  File > Build Settings > Drag & Drop scene into 'Scenes in Build'");
            return; 
        }
        
        if (isPlayer && gameLogic.HasWon()) // this checks if the player touched the exit and if the player collected all the collectables
        {
            SceneManager.LoadScene(nextScene); // this loads the next level
        }
    }
}
