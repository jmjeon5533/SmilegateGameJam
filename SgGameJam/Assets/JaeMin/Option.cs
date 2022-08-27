using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Option : SupplyManager
{
    RectTransform rect;
    GameManager Gm;

    public int ItemPage = 0;

    void Start()
    {
        rect = GetComponent<RectTransform>();
        Gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    void Update()
    {
        if (OptionOn)
        {
            rect.anchoredPosition = new Vector2(0, Mathf.Lerp(rect.anchoredPosition.y, -100, 0.05f));
            Gm.shadow.SetActive(true);
        }
        else
        {
            rect.anchoredPosition = new Vector2(0, Mathf.Lerp(rect.anchoredPosition.y, -945, 0.05f));
            Gm.shadow.SetActive(false);
        }
    }
    public void ItemTabOn()
    {
        Gm.ItemTab[0].SetActive(true);
        ItemPage = 0;
    }
    public void ItemTabOff()
    {
        for (int i = 0; i < 3; i++)
        {
            Gm.ItemTab[i].SetActive(false);
        }
    }
    public void ItemLeftButton()
    {
        ItemPage--;
        for(int i = 0; i < 3; i++)
        {
            if(i == ItemPage)
            {
                Gm.ItemTab[i].SetActive(true);
            }
            else
            {
                Gm.ItemTab[i].SetActive(false);
            }
        }
    }
    public void ItemRightButton()
    {
        ItemPage++;
        for (int i = 0; i < 3; i++)
        {
            if (i == ItemPage)
            {
                Gm.ItemTab[i].SetActive(true);
            }
            else
            {
                Gm.ItemTab[i].SetActive(false);
            }
        }
    }
}
