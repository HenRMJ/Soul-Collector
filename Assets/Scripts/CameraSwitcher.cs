using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraSwitcher : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera follow;
    [SerializeField] CinemachineVirtualCamera[] dialogue;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("flame1"))
        {
            follow.Priority = 0;
            dialogue[0].Priority = 1;
        }

        if (collision.CompareTag("flame2"))
        {
            follow.Priority = 0;
            dialogue[1].Priority = 1;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("flame1"))
        {
            follow.Priority = 1;
            dialogue[0].Priority = 0;
        }

        if (collision.CompareTag("flame2"))
        {
            follow.Priority = 1;
            dialogue[1].Priority = 0;
        }
    }
}
