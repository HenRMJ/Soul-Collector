using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    GameObject[] collectables;

    AudioManager audioManager;

    [Tooltip("If 0, you have to collect all collectables")] [SerializeField] int collectsLeftToWin;

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

    public int GetCollected()
    {
        return (startingCollectables - numberOfCollectables);
    }

    public int GetTotalToWin()
    {
        return (startingCollectables - collectsLeftToWin);
    }

    public int GetCurrentToWin()
    {
        if (numberOfCollectables - collectsLeftToWin <= 0)
        {
            return 0;
        } else
        {
            return (numberOfCollectables - collectsLeftToWin);
        }
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

    public bool HasWon()
    {
        if (numberOfCollectables <= collectsLeftToWin)
        {
            return true;
        } else
        { 
            return false;
        }
    }

    public AudioManager GetAudio()
    {
        return audioManager;
    }
}
