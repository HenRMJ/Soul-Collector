using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraSwitcher : MonoBehaviour
{
    public static event EventHandler OnPlayerEnterAnyDialogue;
    public static event EventHandler OnPlayerExitAnyDialogue;

    [SerializeField] CinemachineVirtualCamera follow;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("flame"))
        {
            OnPlayerEnterAnyDialogue?.Invoke(this, EventArgs.Empty);
            follow.Priority = 0;
            collision.gameObject.GetComponentsInChildren<CinemachineVirtualCamera>()[0].Priority = 1;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("flame"))
        {
            OnPlayerExitAnyDialogue?.Invoke(this, EventArgs.Empty);
            follow.Priority = 1;
            collision.gameObject.GetComponentsInChildren<CinemachineVirtualCamera>()[0].Priority = 0;
        }
    }
}
