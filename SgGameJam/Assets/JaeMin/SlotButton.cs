using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotButton : Item_Manager
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
            Bad_BlueFill();
        }
        else if (inven.items[_item].name == "Bad_CanCoffee")
        {
            print("2");
            Bad_CanCoffee();
        }
        else if (inven.items[_item].name == "Bad_Chiken")
        {
            print("3");
            Bad_Chiken();
        }
        else if (inven.items[_item].name == "Bad_HoneyButter")
        {
            print("4");
            Bad_HoneyButter();
        }
        else if (inven.items[_item].name == "Bad_Yagurt")
        {
            print("5");
            Bad_Yagurt();
        }
        else if (inven.items[_item].name == "Good_Americano")
        {
            print("6");
            Good_Americano();
        }
        else if (inven.items[_item].name == "Good_Ggum")
        {
            print("7");
            Good_Ggum();
        }
        else if (inven.items[_item].name == "Good_JinRamen")
        {
            print("8");
            Good_JinRamen();
        }
        else if (inven.items[_item].name == "Good_Monster")
        {
            print("9");
            Good_Monster();
        }
        else if (inven.items[_item].name == "Good_PowerAde")
        {
            print("10");
            Good_PowerAde();
        }
        inven.items.RemoveAt(_item);
    }
}
