using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OverlayUI : MonoBehaviour
{
    [SerializeField] Image itemOnePanel;
    [SerializeField] Image itemTwoPanel;
    [SerializeField] Image itemThreePanel;
    [SerializeField] Image itemFourPanel;

    [SerializeField] TMP_Text itemOneTracker;
    [SerializeField] TMP_Text itemTwoTracker;
    [SerializeField] TMP_Text itemThreeTracker;
    [SerializeField] TMP_Text itemFourTracker;

    [SerializeField] Color inactive;
    [SerializeField] Color active;
    [SerializeField] Color selected;

    string selectedItem;
    Consumable consumables;
    int checkOne;
    int checkTwo;
    int checkThree;
    int checkFour;

    const string _ONE = "one";
    const string _TWO = "two";
    const string _THREE = "three";
    const string _FOUR = "four";

    

    private void Start()
    {
        consumables = FindObjectOfType<Consumable>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateConsumablesUI();
        WhatsSelected();
    }

    private void UpdateConsumablesUI()
    {
        checkOne = consumables.GetOneCount();
        checkTwo = consumables.GetTwoCount();
        checkThree = consumables.GetThreeCount();
        checkFour = consumables.GetFourCount();

        if (checkOne > 0)
        {
            itemOneTracker.text = checkOne.ToString();
            itemOnePanel.color = active;
        } else
        {
            itemOneTracker.text = string.Empty;
            itemOnePanel.color = inactive;
        }

        if (checkTwo > 0)
        {
            itemTwoTracker.text = checkTwo.ToString();
            itemTwoPanel.color = active;
        } else
        {
            itemTwoTracker.text = string.Empty;
            itemTwoPanel.color = inactive;
        }

        if (checkThree > 0)
        {
            itemThreeTracker.text = checkThree.ToString();
            itemThreePanel.color = active;
        } else
        {
            itemThreeTracker.text = string.Empty;
            itemThreePanel.color = inactive;
        }

        if (checkFour > 0)
        {
            itemFourTracker.text = checkFour.ToString();
            itemFourPanel.color = active;
        } else
        {
            itemFourTracker.text = string.Empty;
            itemFourPanel.color = inactive;
        }
    }

    private void WhatsSelected()
    {
        if (checkOne == 0 && checkTwo == 0 && checkThree == 0 && checkFour == 0) { return; }

        selectedItem = consumables.GetSelectedItem();

        if (selectedItem == _ONE && checkOne != 0)
        {
            itemOnePanel.color = selected;
        } else if (selectedItem == _TWO && checkTwo != 0)
        {
            itemTwoPanel.color = selected;
        } else if (selectedItem == _THREE && checkThree != 0)
        {
            itemThreePanel.color = selected;
        } else if (selectedItem == _FOUR && checkFour != 0) 
        {
            itemFourPanel.color = selected;
        }
    }
}
