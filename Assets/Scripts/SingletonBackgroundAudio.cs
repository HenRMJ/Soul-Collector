using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonBackgroundAudio : MonoBehaviour
{
    private void Awake()
    {
        int numBackgroundAudio = FindObjectsOfType<SingletonBackgroundAudio>().Length;

        if (numBackgroundAudio > 1)
        {
            Destroy(gameObject);
        } else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
