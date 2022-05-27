using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class HiddenWall : MonoBehaviour
{
    [SerializeField] Color off;
    Color on = new Color(1, 1, 1, 1);

    Tilemap myTile;

    private void Start()
    {
        myTile = GetComponent<Tilemap>();
        myTile.color = on;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            myTile.color = off;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            myTile.color = on;
        }
    }
}
