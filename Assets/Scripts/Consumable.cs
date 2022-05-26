using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Consumable : MonoBehaviour
{
    [SerializeField] GameObject itemOne;
    [SerializeField] GameObject spawn;

    void OnItem(InputValue value)
    {
        GameObject item = Instantiate(itemOne, spawn.transform.position, Quaternion.identity);
        item.GetComponent<Rigidbody2D>().velocity = GetComponent<Rigidbody2D>().velocity;
    }
}
