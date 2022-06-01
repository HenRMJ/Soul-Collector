using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpDetect : MonoBehaviour
{
    [SerializeField] Consumable consumable;
    AudioManager audioManager;

    private void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("one"))
        {
            audioManager.PlaySound("blue");
            consumable.AddPickup(collision.tag);
            Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("two"))
        {
            audioManager.PlaySound("green");
            consumable.AddPickup(collision.tag);
            Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("three"))
        {
            audioManager.PlaySound("purple");
            consumable.AddPickup(collision.tag);
            Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("four"))
        {
            audioManager.PlaySound("red");
            consumable.AddPickup(collision.tag);
            Destroy(collision.gameObject);
        }
    }
}
