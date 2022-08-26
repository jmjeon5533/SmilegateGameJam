using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Supply : SupplyManager
{
    RectTransform rect;
    float Rect;
    void Start()
    {
        rect = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Supplykit)
        {
            rect.anchoredPosition = new Vector2(Mathf.Lerp(rect.anchoredPosition.x, 400,0.05f), 75);
        }
        else
        {
            rect.anchoredPosition = new Vector2(Mathf.Lerp(rect.anchoredPosition.x,0, 0.05f), 75);
        }
        /*
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Supplykit = !Supplykit;
        }
        */
    }
}
