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
            AkSoundEngine.PostEvent("Blue_Pickup", gameObject);
            consumable.AddPickup(collision.tag);
            Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("two"))
        {
            AkSoundEngine.PostEvent("Green_Pickup", gameObject);
            consumable.AddPickup(collision.tag);
            Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("three"))
        {
            AkSoundEngine.PostEvent("Purple_Pickup", gameObject);
            consumable.AddPickup(collision.tag);
            Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("four"))
        {
            AkSoundEngine.PostEvent("Red_Pickup", gameObject);
            consumable.AddPickup(collision.tag);
            Destroy(collision.gameObject);
        }
    }
}
