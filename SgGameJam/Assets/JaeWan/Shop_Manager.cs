using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop_Manager : MonoBehaviour
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
    private void Awake()
    {
        var Objs = FindObjectsOfType<Shop_Manager>();
        if (Objs.Length == 1)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Update()
    {
        Flower_Button = GameObject.Find("Flower");
        Cabinet_Button = GameObject.Find("Cabinet");
        Console_Button = GameObject.Find("Console_Game");
        Bear_Button = GameObject.Find("Teddy_Bear");
        Poster_Button = GameObject.Find("Poster");

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
