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
        yield return new WaitForSeconds(delayInSeconds);

        Vector2 direction = (player.transform.position - this.transform.position);
        playerBody.AddForce(direction * knockback, ForceMode2D.Impulse);

        Destroy(gameObject);

    }
}
