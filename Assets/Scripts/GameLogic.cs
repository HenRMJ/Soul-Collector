using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    public static GameLogic Instance { get; private set; }

    GameObject[] collectables;

    [Tooltip("If 0, you have to collect all collectables")] [SerializeField] int collectsLeftToWin;

    int numberOfCollectables;
    int startingCollectables;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("There is an extra instance of GameLogic" + Instance + " -" + transform);
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    private void Start()
    {
        collectables = GameObject.FindGameObjectsWithTag("collectable"); // fills collectables array with object that have the tag "collectable"

        numberOfCollectables = collectables.Length;

        startingCollectables = numberOfCollectables; // this just sets the staring number of collectables to the number of collectables in the beginning
    }

    public void Collect()
    {
        numberOfCollectables--;
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

    public int GetNumberOfCollectables() => numberOfCollectables;
    public int GetTotalCollectables() => startingCollectables;
    public int GetCollected() => startingCollectables - numberOfCollectables;
    public int GetTotalToWin() => startingCollectables - collectsLeftToWin;
    public bool HaveCollected() => numberOfCollectables != startingCollectables;
    public bool HasWon() => numberOfCollectables <= collectsLeftToWin;
}