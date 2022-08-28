using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Button_Script : MonoBehaviour
{
    [SerializeField]
    GameObject manager;
    void Start()
    {

    }

    void Update()
    {

    }
    public void Go_Title()
    {
        Destroy(manager);
        SceneManager.LoadScene(0);
    }
    public void Go_Shop() 
    {
        SceneManager.LoadScene(2);
    }
    public void Go_Credit() 
    {
        SceneManager.LoadScene(1);
    }
    public void GameStart()
    {
        SceneManager.LoadScene(3);
    }
    public void GameQuit() 
    {
        Application.Quit();
        PlayerPrefs.SetInt("Money", GameManager.GmMoney);
        PlayerPrefs.Save();
    }
    public void Flower_Buy() 
    {
        if (GameManager.GmMoney >= 50000)
        {
            Shop_Manager.IsFlower = true;
            GameManager.GmMoney -= 50000;
        }
        else 
        {
            Shop_Manager.IsFlower = false;
        }
    }
    public void Console_Buy() 
    {
        if (GameManager.GmMoney >= 1000000)
        {
            Shop_Manager.IsConsole = true;
            GameManager.GmMoney -= 1000000;
        }
        else
        {
            Shop_Manager.IsConsole = false;
        }
    }
    public void Bear_Buy()
    {
        if (GameManager.GmMoney >= 30000)
        {
            Shop_Manager.IsBear = true;
            GameManager.GmMoney -= 30000;
        }
        else 
        {
            Shop_Manager.IsBear = false;
        }
    }
    public void Cabinet_Buy()
    {
        if (GameManager.GmMoney >= 200000)
        {
            Shop_Manager.IsCabinet = true;
            GameManager.GmMoney -= 200000;
        }
        else
        {
            Shop_Manager.IsCabinet = false;
        }
    }
    public void Poster_Buy() 
    {
        Shop_Manager.IsPoster = true;
    }
}
