using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    GameObject[] collectables;

    public int numberOfCollectables;

    private void Start()
    {
        collectables = GameObject.FindGameObjectsWithTag("collectable");

        foreach (GameObject collectable in collectables)
        {
            numberOfCollectables++;
        }
    }

    public void Collect()
    {
        numberOfCollectables--;
    }
}
