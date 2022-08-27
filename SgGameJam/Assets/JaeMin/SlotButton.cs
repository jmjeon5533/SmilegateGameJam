using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotButton : MonoBehaviour
{
    Inventory inven;
    void Start()
    {
        inven = GameObject.Find("Inventory").GetComponent<Inventory>();
    }

    
    void Update()
    {
        
    }
    public void Button(int _item)
    {
        if (inven.items[_item].name == "Bad_BluePill")
        {
            print("1");
        }
        else if (inven.items[_item].name == "Bad_CanCoffee")
        {
            print("2");
        }
        else if (inven.items[_item].name == "Bad_Chiken")
        {
            print("3");
        }
        else if (inven.items[_item].name == "Bad_HoneyButter")
        {
            print("4");
        }
        else if (inven.items[_item].name == "Bad_Yagurt")
        {
            print("5");
        }
        else if (inven.items[_item].name == "Good_Americano")
        {
            print("6");
        }
        else if (inven.items[_item].name == "Good_Ggum")
        {
            print("7");
        }
        else if (inven.items[_item].name == "Good_JinRamen")
        {
            print("8");
        }
        else if (inven.items[_item].name == "Good_Monster")
        {
            print("9");
        }
        else if (inven.items[_item].name == "Good_PowerAde")
        {
            print("10");
        }
        inven.items.RemoveAt(_item);
    }
}
