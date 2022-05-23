using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class DialogueSystem : MonoBehaviour
{
    [SerializeField] TMP_Text dialogueText;
    [SerializeField] Dialogue dialogue;

    bool closeEnough;
    int pressed;

    private GenereationGameJam2022 playerInputAction;

    private void Awake()
    {
        playerInputAction = new GenereationGameJam2022();
    }

    private void OnEnable()
    {
        playerInputAction.Player.Interact.performed += NextText;
        playerInputAction.Player.Interact.Enable();
    }

    private void OnDisable()
    {
        playerInputAction.Player.Interact.Disable();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        closeEnough = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        closeEnough = false;
    }

    private void NextText(InputAction.CallbackContext obj)
    {
        if (!closeEnough) { return; }

        if (pressed < dialogue.GetDialogueText().Length - 1)
        {
            pressed++;
            dialogueText.text = dialogue.GetDialogueText()[pressed];
        }
    }
}
