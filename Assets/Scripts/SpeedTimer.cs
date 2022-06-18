using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpeedTimer : MonoBehaviour
{
    [SerializeField] TMP_Text timerText;

    float timer;

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
    void Update()
    {
        timer += Time.deltaTime;
        float time = (Mathf.Round(timer * 100) * .01f);


        timerText.text = time.ToString();
    }
}
