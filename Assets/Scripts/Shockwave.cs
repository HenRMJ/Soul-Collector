using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Shockwave : MonoBehaviour
{
    [SerializeField] float knockback;
    [SerializeField] float delayInSeconds;
    [SerializeField] GameObject explosion;

    Rigidbody2D playerBody;
    GameObject player;
    CinemachineImpulseSource source;

    IEnumerator coroutine;

    private void OnEnable()
    {
        source = GetComponent<CinemachineImpulseSource>();
        playerBody = PlayerMovement.Instance.GetComponent<Rigidbody2D>();
        player = playerBody.gameObject;
        coroutine = Pexplode();
        StartCoroutine(coroutine);

    }


    IEnumerator Pexplode()
    {
        AkSoundEngine.PostEvent("Blue_Charge", gameObject);
        yield return new WaitForSeconds(delayInSeconds);
        Vector2 direction = (player.transform.position - this.transform.position).normalized;
        source.GenerateImpulse();
        Instantiate(explosion, gameObject.transform.position, explosion.transform.rotation);
        AkSoundEngine.PostEvent("Blue_Explode", gameObject);
        playerBody.AddForce(direction * knockback, ForceMode2D.Impulse);
        Destroy(gameObject);
    }
}
