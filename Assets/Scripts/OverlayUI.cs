using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OverlayUI : MonoBehaviour
{
    [Header("Item Panels")]
    [SerializeField] Image itemOnePanel;
    [SerializeField] Image itemTwoPanel;
    [SerializeField] Image itemThreePanel;
    [SerializeField] Image itemFourPanel;

    [Header("Item Number Trackers")]
    [SerializeField] TMP_Text itemOneTracker;
    [SerializeField] TMP_Text itemTwoTracker;
    [SerializeField] TMP_Text itemThreeTracker;
    [SerializeField] TMP_Text itemFourTracker;

    [Header("Colors")]
    [SerializeField] Color inactive;
    [SerializeField] Color active;

    [Header("Not Selected Images")]
    [SerializeField] Sprite itemOneNotSelected;
    [SerializeField] Sprite itemTwoNotSelected;
    [SerializeField] Sprite itemThreeNotSelected;
    [SerializeField] Sprite itemFourNotSelected;

    [Header("Selected Images")]
    [SerializeField] Sprite itemOneSelected;
    [SerializeField] Sprite itemTwoSelected;
    [SerializeField] Sprite itemThreeSelected;
    [SerializeField] Sprite itemFourSelected;

    [Header("Tracker Backgrounds")]
    [SerializeField] GameObject oneBackground;
    [SerializeField] GameObject twoBackground;
    [SerializeField] GameObject threeBackground;
    [SerializeField] GameObject fourBackground;


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

        itemOnePanel.sprite = itemOneNotSelected;
        itemTwoPanel.sprite = itemTwoNotSelected;
        itemThreePanel.sprite = itemThreeNotSelected;
        itemFourPanel.sprite = itemFourNotSelected;

        if (checkOne > 0)
        {
            itemOneTracker.text = checkOne.ToString();
            itemOnePanel.color = active;
            oneBackground.SetActive(true);
        } else
        {
            itemOneTracker.text = string.Empty;
            itemOnePanel.color = inactive;
            oneBackground.SetActive(false);
        }

        if (checkTwo > 0)
        {
            itemTwoTracker.text = checkTwo.ToString();
            itemTwoPanel.color = active;
            twoBackground.SetActive(true);
        } else
        {
            itemTwoTracker.text = string.Empty;
            itemTwoPanel.color = inactive;
            twoBackground.SetActive(false);
        }

        if (checkThree > 0)
        {
            itemThreeTracker.text = checkThree.ToString();
            itemThreePanel.color = active;
            threeBackground.SetActive(true);
        } else
        {
            itemThreeTracker.text = string.Empty;
            itemThreePanel.color = inactive;
            threeBackground.SetActive(false);
        }

        if (checkFour > 0)
        {
            itemFourTracker.text = checkFour.ToString();
            itemFourPanel.color = active;
            fourBackground.SetActive(true);
        } else
        {
            itemFourTracker.text = string.Empty;
            itemFourPanel.color = inactive;
            fourBackground.SetActive(false);
        }
    }

    private void WhatsSelected()
    {
        if (checkOne == 0 && checkTwo == 0 && checkThree == 0 && checkFour == 0) { return; }

        selectedItem = consumables.GetSelectedItem();

        if (selectedItem == _ONE && checkOne != 0)
        {
            itemOnePanel.sprite = itemOneSelected;
        } else if (selectedItem == _TWO && checkTwo != 0)
        {
            itemTwoPanel.sprite = itemTwoSelected;
        } else if (selectedItem == _THREE && checkThree != 0)
        {
            itemThreePanel.sprite = itemThreeSelected;
        } else if (selectedItem == _FOUR && checkFour != 0) 
        {
            itemFourPanel.sprite = itemFourSelected;
        }
    }
}
