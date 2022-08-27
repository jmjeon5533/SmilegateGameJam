using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop_Manager : MonoBehaviour
{
    [SerializeField]
    GameObject Shop_1;
    [SerializeField]
    GameObject Shop_2;

    public static int Shop_Page_Value = 1;
    void Start()
    {
        
    }

    void Update()
    {
        Shop_Page();
    }
    void Shop_Page()
    {
        if (Shop_Page_Value > 2)
        {
            Shop_Page_Value = 1;
        }
        else if (Shop_Page_Value < 0) 
        {
            Shop_Page_Value = 2;
        }
        switch (Shop_Page_Value)
        {
            case 1:
                Shop_1.SetActive(true);
                Shop_2.SetActive(false);
                break;
            case 2:
                Shop_1.SetActive(false);
                Shop_2.SetActive(true);
                break;
            default:
                break;
        }
    }
}
