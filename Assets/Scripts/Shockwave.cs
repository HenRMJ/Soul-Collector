using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shockwave : MonoBehaviour
{
    [SerializeField] float knockback;
    [SerializeField] float delayInSeconds;

    Rigidbody2D playerBody;
    GameObject player;

    IEnumerator coroutine;

    private void OnEnable()
    {
        playerBody = FindObjectOfType<PlayerMovement>().GetComponent<Rigidbody2D>();
        player = playerBody.gameObject;
        coroutine = Pexplode();
        StartCoroutine(coroutine);

    }


    IEnumerator Pexplode()
    {
        AkSoundEngine.PostEvent("Blue_Charge", gameObject);
        yield return new WaitForSeconds(delayInSeconds);
        Vector2 direction = (player.transform.position - this.transform.position);
        AkSoundEngine.PostEvent("Blue_Explode", gameObject);
        direction.Normalize();
        playerBody.AddForce(direction * knockback, ForceMode2D.Impulse);
        Destroy(gameObject);
    }
}
