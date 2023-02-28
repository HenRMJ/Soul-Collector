using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField] float delayInSeconds;

    Rigidbody2D playerBody;
    GameObject player;

    IEnumerator coroutine;

    private void OnEnable()
    {
        playerBody = PlayerMovement.Instance.GetComponent<Rigidbody2D>();
        player = playerBody.gameObject;
        coroutine = Teleplode();
        StartCoroutine(coroutine);
    }


    IEnumerator Teleplode()
    {
        AkSoundEngine.PostEvent("Green_Crystal", gameObject);
        yield return new WaitForSeconds(delayInSeconds);
        player.transform.position = gameObject.transform.position;
        playerBody.velocity = gameObject.GetComponent<Rigidbody2D>().velocity;
        Destroy(gameObject);
    }
}
