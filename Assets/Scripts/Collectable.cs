using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // this line checks if the player is colliding
        {
            GameLogic.Instance.Collect();

            if (GameLogic.Instance.GetNumberOfCollectables() == 0) // this destroys the parent if there is no more collectables
            {
                AkSoundEngine.PostEvent("Soul_Pickup_Event", gameObject);
                AkSoundEngine.PostEvent("All_Souls", gameObject);
                Destroy(gameObject.transform.parent.gameObject);
            } else
            {
                AkSoundEngine.PostEvent("Soul_Pickup_Event", gameObject);
            }

            Destroy(gameObject);
        } 
    }
}
