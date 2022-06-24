using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class SpeedTimer : MonoBehaviour
{
    [SerializeField] TMP_Text timerText;

    double timer;
    string runTime;

    private void Awake()
    {
        int numBackgroundAudio = FindObjectsOfType<SpeedTimer>().Length;

        if (numBackgroundAudio > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void OnLevelWasLoaded()
    {
        string currentScene = SceneManager.GetActiveScene().name;

        if (currentScene.Contains("Level"))
        {
            return;
        } else
        {
            PlayerPrefs.SetString("Run", runTime);
            PlayerPrefs.SetFloat("Speed", Convert.ToSingle(timer));
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        double minute = Math.Floor(timer / 60);
        double seconds = Math.Round(timer % 60, 3);

        string secondsAsString;

        if (seconds.ToString().IndexOf(".") == 1)
        {
            secondsAsString = seconds.ToString().Insert(0, "0");
        } else
        {
            secondsAsString = seconds.ToString();
        }

        runTime = minute.ToString() + ":" + secondsAsString.Replace(".", ":");

        timerText.text = runTime;
    }
}
