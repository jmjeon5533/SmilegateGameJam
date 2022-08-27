using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop_Manager : GameManager
{
    public static bool IsFlower = false;
    public static bool IsConsole = false;
    public static bool IsBear = false;
    public static bool IsCabinet = false;
    public static bool IsPoster = false;

    [SerializeField]
    GameObject Flower_Button;
    [SerializeField]
    GameObject Bear_Button;
    [SerializeField]
    GameObject Cabinet_Button;
    [SerializeField]
    GameObject Poster_Button;
    [SerializeField]
    GameObject Console_Button;
    void Start()
    {
        
    }
    void Update()
    {
        if (IsFlower == true)
        {
            Flower_Button.SetActive(false);
        }

        if (IsConsole == true)
        {
            Console_Button.SetActive(false);
        }

        if (IsBear == true)
        {
            Bear_Button.SetActive(false);
        }

        if (IsCabinet == true)
        {
            Cabinet_Button.SetActive(false);
        }

        if (IsPoster == true)
        {
            Poster_Button.SetActive(false);
        }
    }
}
