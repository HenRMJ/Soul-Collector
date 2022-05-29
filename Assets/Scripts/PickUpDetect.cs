using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpDetect : MonoBehaviour
{
    [SerializeField] Consumable consumable;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("one"))
        {
            consumable.AddPickup(collision.tag);
            Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("two"))
        {
            consumable.AddPickup(collision.tag);
            Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("three"))
        {
            consumable.AddPickup(collision.tag);
            Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("four"))
        {
            consumable.AddPickup(collision.tag);
            Destroy(collision.gameObject);
        }
    }
}
