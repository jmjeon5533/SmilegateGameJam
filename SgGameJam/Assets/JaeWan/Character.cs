using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : GameManager
{
    //피로 상태
    public static bool IsTired = false;
    //배고픔 상태
    public static bool IsHungry = false;
    //번아웃 ( 의지박약 ) 상태
    public static bool IsBurnOut = false;

    [SerializeField]
    Text texts;

    [SerializeField]
    SpriteRenderer spr;

    [SerializeField]
    Sprite[] sprites = new Sprite[4];

    // 랜덤 값 ( 이 친구에 기반해서 상태 이상이 정해진다 )
    public int DeBuff_Range = 0;
    public int DeBuff_Time = 0;

    public static int Plus;
    public bool Abort = false;
    void Start()
    {
        StartCoroutine(De_Buff());
    }

    void Update()
    {
        CheatKey();
        GameManager.GmStatusPlus = Plus;
        texts.text = Plus + " 올라요";


        if (IsBurnOut == true)
        {
            spr.sprite = sprites[0];
        }
        else if (IsHungry == true)
        {
            spr.sprite = sprites[1];
        }
        else if (IsTired == true)
        {
            spr.sprite = sprites[2];
        }
        else 
        {
            spr.sprite = sprites[3];
        }
    }
    IEnumerator De_Buff() 
    {
        Debug.Log("디버프 실행");
        if (IsHungry == false && IsBurnOut == false && IsTired == false) 
        {
            Plus = 10;
            DeBuff_Time = Random.Range(15,46);
            yield return new WaitForSecondsRealtime(DeBuff_Time);
            DeBuff_Range = Random.Range(1,4);
        }
        // 랜덤값 검사
        switch (DeBuff_Range)
        {
            case 1:
                IsBurnOut = true;
                IsTired = false;
                IsHungry = false;
                break;

            case 2:
                IsTired = true;
                IsBurnOut = false;
                IsHungry = false;
                break;

            case 3:
                IsHungry = true;
                IsBurnOut = false;
                IsTired = false;
                break;

            default:
                StartCoroutine(De_Buff());
                break;
        }
        if (IsBurnOut == true || IsHungry == true || IsTired == true) 
        {
            StartCoroutine(WaitSec());
        }
    }
    IEnumerator WaitSec()
    {
        Debug.Log("다른거 실행");
        Plus = 5;
        for (int i = 0; i < 20; i++) 
        {
            if (IsHungry == false && IsBurnOut == false && IsTired == false)
            {
                break;
            }
            yield return new WaitForSecondsRealtime(1);
        }
        for (int i = 0; i < 10000; i++)
        {
            if (IsHungry == false && IsBurnOut == false && IsTired == false)
            {
                break;
            }
            yield return new WaitForSecondsRealtime(1);
            Plus = 0;
        }
        StartCoroutine(De_Buff());
    }


    // 이 함수는 개발용 함수기에 완성 후에는 지워주세요.
    void CheatKey() 
    {
        if (Input.GetKeyDown(KeyCode.Q)) 
            IsBurnOut = false;

        if (Input.GetKeyDown(KeyCode.W))
            IsTired = false;

        if (Input.GetKeyDown(KeyCode.E))
            IsHungry = false;
    }

}
