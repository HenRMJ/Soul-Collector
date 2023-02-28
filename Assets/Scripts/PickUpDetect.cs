using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpDetect : MonoBehaviour
{
    [SerializeField] Consumable consumable;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        string cTag = collision.tag;

        switch (cTag)
        {
            case "one":
                AkSoundEngine.PostEvent("Blue_Pickup", gameObject);
                consumable.AddPickup(cTag);
                Destroy(collision.gameObject);
                break;
            case "two":
                AkSoundEngine.PostEvent("Green_Pickup", gameObject);
                consumable.AddPickup(cTag);
                Destroy(collision.gameObject);
                break;
            case "three":
                AkSoundEngine.PostEvent("Purple_Pickup", gameObject);
                consumable.AddPickup(cTag);
                Destroy(collision.gameObject);
                break;
            case "four":
                AkSoundEngine.PostEvent("Red_Pickup", gameObject);
                consumable.AddPickup(cTag);
                Destroy(collision.gameObject);
                break;
        }
    }
}
