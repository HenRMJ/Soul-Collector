using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anchor : MonoBehaviour
{
    [SerializeField] float delayInSeconds;

    GameObject player;

    IEnumerator coroutine;

    private void OnEnable()
    {
        player = FindObjectOfType<PlayerMovement>().gameObject;
        coroutine = Teleplode();
        StartCoroutine(coroutine);
    }


    IEnumerator Teleplode()
    {
        yield return new WaitForSeconds(delayInSeconds);
        player.transform.position = gameObject.transform.position;
        Destroy(gameObject);
    }
}
