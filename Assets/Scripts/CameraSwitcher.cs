using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraSwitcher : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera follow;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("flame"))
        {
            follow.Priority = 0;
            collision.gameObject.GetComponentsInChildren<CinemachineVirtualCamera>()[0].Priority = 1;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("flame"))
        {
            follow.Priority = 1;
            collision.gameObject.GetComponentsInChildren<CinemachineVirtualCamera>()[0].Priority = 0;
        }
    }
}
