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
    public void Left()
    {
        Shop_Page_Value--;
    }
    public void Right()
    {
        Shop_Page_Value++;
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
}
