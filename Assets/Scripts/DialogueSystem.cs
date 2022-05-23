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
    GameObject canvas;

    private GenereationGameJam2022 playerInputAction;

    private void Awake()
    {
        playerInputAction = new GenereationGameJam2022();
        canvas = FindObjectOfType<Canvas>().gameObject;
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

    private void Update()
    {
        if (closeEnough)
        {
            canvas.SetActive(true);
        }
        else
        {
            pressed = 1;
            dialogueText.text = dialogue.GetDialogueText()[pressed];
            canvas.SetActive(false);
        }
    }

    private void NextText(InputAction.CallbackContext obj)
    {
        if (!closeEnough) { return; }

        if (pressed < dialogue.GetDialogueText().Length - 1)
        {
            pressed++;
            dialogueText.text = dialogue.GetDialogueText()[pressed];
        } else
        {
            dialogueText.text = dialogue.GetRepeatingText();
        }
    }
}
