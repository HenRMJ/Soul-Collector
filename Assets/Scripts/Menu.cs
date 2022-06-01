using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] GameObject canvas;

    AudioManager audioManager;

    private void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(2);
        Time.timeScale = 1;
    }

    public void Credits()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void SelectSound()
    {
        audioManager.PlaySound("select");
    }

    void OnPause()
    {
        if (canvas == null) { return; }

        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            canvas.SetActive(true);
        } else
        {
            Time.timeScale = 1;
            canvas.SetActive(false);
        }
        
    }
}

