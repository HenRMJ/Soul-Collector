using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonBackgroundAudio : MonoBehaviour
{
    public static SingletonBackgroundAudio Instance { get; private set; }
    private void Start()
    {
        // If there is an instance, and it's not me, delete myself.
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(transform.gameObject);
        }
    }
}
