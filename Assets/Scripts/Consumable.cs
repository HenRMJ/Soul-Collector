using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Consumable : MonoBehaviour
{
    [SerializeField] GameObject itemOne;
    [SerializeField] GameObject itemTwo;
    [SerializeField] GameObject itemThree;
    [SerializeField] GameObject itemFour;
    [SerializeField] GameObject spawn;

    string selectedItem;

    const string _ONE = "one";
    const string _TWO = "two";
    const string _THREE = "three";
    const string _FOUR = "four";

    int oneCount;
    int twoCount;
    int threeCount;
    int fourCount;

    GameObject currentItem;
    int currentCount;

    Vector2 up = new Vector2(0, 1);
    Vector2 right = new Vector2(1, 0);
    Vector2 down = new Vector2(0, -1);
    Vector2 left = new Vector2(-1, 0);

    void OnItem(InputValue value)
    {
        if (currentCount <= 0) { return; }

        GameObject item = Instantiate(currentItem, spawn.transform.position, Quaternion.identity);

        if (currentItem == itemOne)
        {
            oneCount--;
            currentCount = oneCount;
        }
        else if (currentItem == itemTwo)
        {
            twoCount--;
            currentCount = twoCount;
        }
        else if (currentItem == itemThree)
        {
            threeCount--;
            currentCount = threeCount;
        }
        else if (currentItem == itemFour)
        {
            fourCount--;
            currentCount = fourCount;
        }

        if (item.GetComponent<Rigidbody2D>() == null) { return; }

        item.GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, GetComponent<Rigidbody2D>().velocity.y);

        
    }

    void OnChoose(InputValue value)
    {
        if (value.Get<Vector2>() == up)
        {
            selectedItem = _ONE;
            currentItem = itemOne;
            currentCount = oneCount;
        } else if (value.Get<Vector2>() == right)
        {
            selectedItem = _TWO;
            currentItem = itemTwo;
            currentCount = twoCount;
        } else if (value.Get<Vector2>() == down)
        {
            selectedItem = _THREE;
            currentItem = itemThree;
            currentCount = threeCount;
        } else if (value.Get<Vector2>() == left)
        {
            selectedItem = _FOUR;
            currentItem = itemFour;
            currentCount = fourCount;
        }
    }

    public void AddPickup(string cTag)
    {

        if (cTag == "one")
        {
            oneCount++;
        } else if (cTag == "two")
        {
            twoCount++;
        } else if (cTag == "three")
        {
            threeCount++;
        } else if (cTag == "four")
        {
            fourCount++;
        }
    }

    public int GetOneCount()
    {
        return oneCount;
    }
    public int GetTwoCount()
    {
        return twoCount;
    }
    public int GetThreeCount()
    {
        return threeCount;
    }
    public int GetFourCount()
    {
        return fourCount;
    }

    public string GetSelectedItem()
    {
        return selectedItem;
    }
}
