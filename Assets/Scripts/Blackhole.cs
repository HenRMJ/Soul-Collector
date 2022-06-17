using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blackhole : MonoBehaviour
{
    [SerializeField] float pull;
    [SerializeField] float delayInSeconds;
    [SerializeField] GameObject suction;

    Rigidbody2D playerBody;
    GameObject player;

    IEnumerator coroutine;

    private void OnEnable()
    {
        playerBody = FindObjectOfType<PlayerMovement>().GetComponent<Rigidbody2D>();
        player = playerBody.gameObject;
        coroutine = Inplode();
        StartCoroutine(coroutine);

    }


    IEnumerator Inplode()
    {
        Instantiate(suction, gameObject.transform);
        AkSoundEngine.PostEvent("Purple_Crystal", gameObject);
        yield return new WaitForSeconds(delayInSeconds);
        Vector2 direction = (player.transform.position - this.transform.position);
        direction.Normalize();
        playerBody.AddForce(-direction * pull, ForceMode2D.Impulse);
        Destroy(gameObject);
    }
}
