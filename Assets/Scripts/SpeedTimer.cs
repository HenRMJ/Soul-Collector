using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class SpeedTimer : MonoBehaviour
{
    public static SpeedTimer Instance { get; private set; }

    [SerializeField] TMP_Text timerText;

    double timer;
    string runTime;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Too many instances of SpeedTimer");
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(Instance);
    }

    private void OnEnable()
    {
        SceneManager.activeSceneChanged += NewLevelLoaded;
    }

    private void NewLevelLoaded(Scene currentScene, Scene nextScene)
    {
        if (!nextScene.name.Contains("Level"))
        {
            PlayerPrefs.SetString("Run", runTime);
            PlayerPrefs.SetFloat("Speed", Convert.ToSingle(timer));
            SceneManager.activeSceneChanged -= NewLevelLoaded;
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
