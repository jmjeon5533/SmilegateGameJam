using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Button_Script : Shop_Manager
{
    void Start()
    {

    }

    void Update()
    {

    }
    public void Go_Title()
    {
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
    }
    public void Flower_Buy() 
    {
        if (GmMoney >= 50000)
        {
            IsFlower = true;
        }
        else 
        {
            IsFlower = false;
        }
    }
    public void Console_Buy() 
    {
        if (GmMoney >= 1000000)
        {
            IsConsole = true;
        }
        else
        {
            IsConsole = false;
        }
    }
    public void Bear_Buy()
    {
        if (GmMoney >= 30000)
        {
            IsBear = true;
        }
        else 
        {
            IsBear = false;
        }
    }
    public void Cabinet_Buy()
    {
        if (GmMoney >= 200000)
        {
            IsCabinet = true;
        }
        else
        {
            IsCabinet = false;
        }
    }
    public void Poster_Buy() 
    {
        IsPoster = true;
    }
}
