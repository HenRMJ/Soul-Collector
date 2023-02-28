using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrackSpeaker : MonoBehaviour
{
    [SerializeField] DialogueSystem dialogueSystem;

    bool playerTalking;
    Vector3 startingPostion;

    // Start is called before the first frame update
    void Start()
    {
        playerTalking = false;
        startingPostion = gameObject.transform.position;
        dialogueSystem.OnPlayerSpeaks += DialogueSystem_OnPlayerSpeaks;
        dialogueSystem.OnNPCSpeaks += DialogueSystem_OnNPCSpeaks;
    }

    private void Update()
    {
        if (playerTalking)
        {
            transform.position = new Vector3(PlayerMovement.Instance.gameObject.transform.position.x, startingPostion.y, startingPostion.z);
        }
        else
        {
            if (transform.position == startingPostion) return;
            transform.position = startingPostion;
        }
    }

    private void DialogueSystem_OnPlayerSpeaks(object sender, EventArgs e)
    {
        playerTalking = true;
    }
    private void DialogueSystem_OnNPCSpeaks(object sender, EventArgs e)
    {
        playerTalking = false;
    }
}
