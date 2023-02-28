using System;
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

    [SerializeField] float fadeAmount = 10f;


    string selectedItem;
    Consumable consumables;
    int checkOne;
    int checkTwo;
    int checkThree;
    int checkFour;
    bool overlayActive;
    Image[] overlayImageList;
    TMP_Text[] overlayTextList;
    List<float> imageAlphas = new List<float>();
    List<float> textAlphas = new List<float>();

    const string _ONE = "one";
    const string _TWO = "two";
    const string _THREE = "three";
    const string _FOUR = "four";

    private void Start()
    {
        overlayActive = true;
        CameraSwitcher.OnPlayerEnterAnyDialogue += CameraSwitcher_OnPlayerEnterAnyDialogue;
        CameraSwitcher.OnPlayerExitAnyDialogue += CameraSwitcher_OnPlayerExitAnyDialogue;
        consumables = FindObjectOfType<Consumable>();
    }

    private void OnDisable()
    {
        CameraSwitcher.OnPlayerEnterAnyDialogue -= CameraSwitcher_OnPlayerEnterAnyDialogue;
        CameraSwitcher.OnPlayerExitAnyDialogue -= CameraSwitcher_OnPlayerExitAnyDialogue;
    }

    // Update is called once per frame
    void Update()
    {
        

        if (!overlayActive)
        {
            foreach (Image image in overlayImageList)
            {
                image.color = new Color(image.color.r, image.color.g, image.color.b, Mathf.Lerp(image.color.a, 0, Time.deltaTime * fadeAmount));
            }

            foreach (TMP_Text text in overlayTextList)
            {
                text.color = new Color(text.color.r, text.color.g, text.color.b, Mathf.Lerp(text.color.a, 0, Time.deltaTime * fadeAmount));
            }
        } else
        {
            ReappearOverlay();
            UpdateConsumablesUI();
            WhatsSelected();
        }
    }

    private void ReappearOverlay()
    {
        if (overlayTextList == null) return;

        for (int i = 0; i < overlayTextList.Length; i++)
        {
            overlayTextList[i].color = new Color(overlayTextList[i].color.r, 
                overlayTextList[i].color.g, 
                overlayTextList[i].color.b, 
                Mathf.Lerp(overlayTextList[i].color.a, 
                textAlphas[i], Time.deltaTime * fadeAmount));
        }

        for (int i = 0; i < overlayImageList.Length; i++)
        {
            overlayImageList[i].color = new Color(overlayImageList[i].color.r,
                overlayImageList[i].color.g,
                overlayImageList[i].color.b,
                Mathf.Lerp(overlayImageList[i].color.a,
                imageAlphas[i], Time.deltaTime * fadeAmount));
        }
    }

    private void CameraSwitcher_OnPlayerExitAnyDialogue(object sender, EventArgs e)
    {
        overlayActive = true;
    }

    private void CameraSwitcher_OnPlayerEnterAnyDialogue(object sender, EventArgs e)
    {
        overlayImageList = GetComponentsInChildren<Image>();
        overlayTextList = GetComponentsInChildren<TMP_Text>();

        foreach (Image image in overlayImageList)
        {
            imageAlphas.Add(image.color.a);
        }
        
        foreach (TMP_Text text in overlayTextList)
        {
            textAlphas.Add(text.color.a);
        }

        overlayActive = false;
    }

    private void UpdateConsumablesUI()
    {
        if (Time.timeScale == 0) { return; }

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
        if (Time.timeScale == 0) { return; }

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
