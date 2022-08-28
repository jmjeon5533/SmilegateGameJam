using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Text_Script : MonoBehaviour
{
    [SerializeField]
    Text texts;
    void Start()
    {
        
    }

    void Update()
    {
        texts.text = " : "+ GameManager.GmMoney + "¿ø";
    }
}
