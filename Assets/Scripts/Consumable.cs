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
    [SerializeField] Transform moveToward;
    [SerializeField] float speed;
    [SerializeField] float distance;

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

    private void Update()
    {
        if (Vector2.Distance(spawn.transform.position, moveToward.position) > distance)
        {
            spawn.transform.position = gameObject.transform.position;
        }

        float step = speed * Time.deltaTime;

        spawn.transform.position = Vector2.MoveTowards(spawn.transform.position, moveToward.position, step);
    }

    void OnItem(InputValue value)
    {
        if (currentItem == itemOne)
        {
            currentCount = oneCount;
        }
        else if (currentItem == itemTwo)
        {
            currentCount = twoCount;
        }
        else if (currentItem == itemThree)
        {
            currentCount = threeCount;
        }
        else if (currentItem == itemFour)
        {
            currentCount = fourCount;
        }

        if (currentCount <= 0) { return; }

        GameObject item = Instantiate(currentItem, spawn.transform.position, Quaternion.identity);

        if (currentItem == itemOne)
        {
            oneCount--;
        }
        else if (currentItem == itemTwo)
        {
            twoCount--;
        }
        else if (currentItem == itemThree)
        {
            threeCount--;
        }
        else if (currentItem == itemFour)
        {
            fourCount--;
        }

        if (item.GetComponent<Rigidbody2D>() == null) { return; }

        item.GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, GetComponent<Rigidbody2D>().velocity.y);

        
    }

    void OnChoose(InputValue value)
    {
        if (value.Get<Vector2>() == Vector2.up)
        {
            selectedItem = _ONE;
            currentItem = itemOne;
            currentCount = oneCount;
        } else if (value.Get<Vector2>() == Vector2.right)
        {
            selectedItem = _TWO;
            currentItem = itemTwo;
            currentCount = twoCount;
        } else if (value.Get<Vector2>() == Vector2.down)
        {
            selectedItem = _THREE;
            currentItem = itemThree;
            currentCount = threeCount;
        } else if (value.Get<Vector2>() == Vector2.left)
        {
            selectedItem = _FOUR;
            currentItem = itemFour;
            currentCount = fourCount;
        }
    }

    public void AddPickup(string cTag)
    {
        switch (cTag)
        {
            case _ONE:
                oneCount++;
                selectedItem = _ONE;
                currentItem = itemOne;
                currentCount = oneCount;
                break;
            case _TWO:
                twoCount++;
                selectedItem = _TWO;
                currentItem = itemTwo;
                currentCount = twoCount;
                break;
            case _THREE:
                threeCount++;
                selectedItem = _THREE;
                currentItem = itemThree;
                currentCount = threeCount;
                break;
            case _FOUR:
                fourCount++;
                selectedItem = _FOUR;
                currentItem = itemFour;
                currentCount = fourCount;
                break;
        }
    }

    public int GetOneCount() => oneCount;
    public int GetTwoCount() => twoCount;
    public int GetThreeCount() => threeCount;
    public int GetFourCount() => fourCount;
    public string GetSelectedItem() => selectedItem;
}
