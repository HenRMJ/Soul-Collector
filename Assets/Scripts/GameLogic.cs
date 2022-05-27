using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    GameObject[] collectables;

    AudioManager audioManager;

    int numberOfCollectables;
    int startingCollectables;


    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();

        collectables = GameObject.FindGameObjectsWithTag("collectable"); // fills collectables array with object that have the tag "collectable"

        numberOfCollectables = collectables.Length;

        startingCollectables = numberOfCollectables; // this just sets the staring number of collectables to the number of collectables in the beginning
    }

    public void Collect()
    {
        numberOfCollectables--;
    }

    public int GetNumberOfCollectables()
    {
        return numberOfCollectables;
    }

    public int GetTotalCollectables()
    {
        return startingCollectables;
    }

    public bool HaveCollected()
    {
        if (numberOfCollectables == startingCollectables)
        {
            return false;
        } else
        {
            return true;
        }
    }

    public AudioManager GetAudio()
    {
        return audioManager;
    }
}
