using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class SpeedTimer : MonoBehaviour
{
    [SerializeField] TMP_Text timerText;

    double timer;

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

    // Update is called once per frame
    void FixedUpdate()
    {
        timer += Time.deltaTime;
        float time = Convert.ToSingle(Math.Round(timer, 2));


        timerText.text = time.ToString();
    }
}
