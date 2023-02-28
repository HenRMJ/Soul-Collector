using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpeedRunTime : MonoBehaviour
{
    [SerializeField] TMP_Text timerText;
    [SerializeField] TMP_Text fastestTime;

    // Update is called once per frame
    void Update()
    {
        if (timerText.text == PlayerPrefs.GetString("Run")) return;

        if (!(PlayerPrefs.HasKey("Fastest_Time")) || PlayerPrefs.GetFloat("Fastest_Time") == 0f)
        {
            PlayerPrefs.SetFloat("Fastest_Time", PlayerPrefs.GetFloat("Speed"));
            PlayerPrefs.SetString("HighSpeed", PlayerPrefs.GetString("Run"));
        }

        if (PlayerPrefs.GetFloat("Speed") < PlayerPrefs.GetFloat("Fastest_Time"))
        {
            PlayerPrefs.SetFloat("Fastest_Time", PlayerPrefs.GetFloat("Speed"));
            PlayerPrefs.SetString("HighSpeed", PlayerPrefs.GetString("Run"));
        }

        fastestTime.text = PlayerPrefs.GetString("HighSpeed");
        timerText.text = PlayerPrefs.GetString("Run");
    }
}
