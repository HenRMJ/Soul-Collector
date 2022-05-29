using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class ChangeUI : MonoBehaviour
{
    [SerializeField] Image[] images;
    [SerializeField] Sprite[] keyboardUI;
    [SerializeField] Sprite[] gamepadUI;

    const string _KEY = "Keyboard&Mouse";
    const string _PAD = "Gamepad";

    void OnControlsChanged()
    {
        var controls = GetComponent<PlayerInput>().currentControlScheme;

        for (int i = 0; i < images.Length; i++)
        {
            if (controls == _KEY)
            {
                images[i].sprite = keyboardUI[i];
            } else if (controls == _PAD)
            {
                images[i].sprite = gamepadUI[i];
            }
        }
    }
}
