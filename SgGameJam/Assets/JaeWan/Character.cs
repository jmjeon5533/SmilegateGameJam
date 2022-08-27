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
    public void Good_Americano()
    {
        // 의지 박약 상태 회복 / 초당 작업량 +2
        IsBurnOut = false;
        StopAllCoroutines();
        StartCoroutine(Good_Americano_Wait());
    }
    IEnumerator Good_Americano_Wait()
    {
        for (int i = 0; i <= 5; i++) {
            if (IsBurnOut == false && IsHungry == false && IsTired == false)
            {
                Plus = 12;
            }
            else if (IsBurnOut == true || IsHungry == true || IsTired == true)
            {
                Plus = 7;
            }
            yield return new WaitForSecondsRealtime(1);
        }
        if (IsBurnOut == false && IsHungry == false && IsTired == false)
        {
            Plus = 10;
        }
        else if (IsBurnOut == true || IsHungry == true || IsTired == true)
        {
            Plus = 5;
        }
    }

    public void Good_Monster()
    {
        // 초당 작업량 +8
        StopAllCoroutines();
        StartCoroutine(Good_Monster_Wait());
    }
    IEnumerator Good_Monster_Wait()
    {
        for (int i =0; i <= 5; i++) 
        {
            if (IsBurnOut == false && IsHungry == false && IsTired == false)
            {
                Plus = 18;
            }
            else if (IsBurnOut == true || IsHungry == true || IsTired == true)
            {
                Plus = 13;
            }
            yield return new WaitForSecondsRealtime(1);
        }
        if (IsBurnOut == false && IsHungry == false && IsTired == false)
        {
            Plus = 10;
        }
        else if (IsBurnOut == true || IsHungry == true || IsTired || true)
        {
            Plus = 5;
        }
    }
    public void Good_PowerAde()
    {
        // 캐릭터의 모든 상태이상 회복
        IsBurnOut = false;
        IsHungry = false;
        IsTired = false;
    }
    public void Good_JinRamen()
    {
        // 허기짐 상태 회복 / 초당 작업량 +3
        IsHungry = false;
        StopAllCoroutines();
        StartCoroutine(Good_JinRamen_Wait());
    }
    IEnumerator Good_JinRamen_Wait()
    {
        for (int i = 0; i <= 5; i++)
        {
            if (IsBurnOut == false && IsHungry == false && IsTired == false)
            {
                Plus = 13;
            }
            else if (IsBurnOut == true || IsHungry == true || IsTired == true)
            {
                Plus = 8;
            }
            yield return new WaitForSecondsRealtime(1);
        }
        if (IsBurnOut == false && IsHungry == false && IsTired == false)
        {
            Plus = 10;
        }
        else if (IsBurnOut == true || IsHungry == true || IsTired == true)
        {
            Plus = 5;
        }

    }
    public void Good_Ggum()
    {
        // 피로 상태 회복 / 초당 작업량 +4
        IsTired = false;
        StopAllCoroutines();
        StartCoroutine(Good_Ggum_Wait());
    }
    IEnumerator Good_Ggum_Wait()
    {
        for (int i = 0; i <= 5; i++) {
            if (IsBurnOut == false && IsHungry == false && IsTired == false)
            {
                Plus = 14;
            }
            else if (IsBurnOut == true || IsHungry == true || IsTired == true)
            {
                Plus = 9;
            }
            yield return new WaitForSecondsRealtime(1);
        }
        if (IsBurnOut == false && IsHungry == false && IsTired == false)
        {
            Plus = 10;
        }
        else if (IsBurnOut == true || IsHungry == true || IsTired == true)
        {
            Plus = 5;
        }
    }

    /// 부정적 아이템 ▽▽▽▽▽▽
    public void Bad_HoneyButter()
    {
        // 의지 박약 상태로 만듬
        IsBurnOut = true;
    }

    public void Bad_CanCoffee()
    {
        // 피로 상태로 만듬
        IsTired = true;
    }

    public void Bad_BlueFill()
    {
        // 게임 진척도 10% 깎는다
        GameManager.GmStatus -= (GameManager.GmStatus / 10);
    }
    public void Bad_Yagurt()
    {
        //  허기짐 살태로 만듬
        IsHungry = true;
    }
    public void Bad_Chiken()
    {
        // 허기짐 상태 회복 / 작업량 -8
        IsHungry = false;
        StopAllCoroutines();
        StartCoroutine(Bad_Chiken_Wait());
    }
    IEnumerator Bad_Chiken_Wait()
    {
        for (int i = 0; i < 5; i++)
        {
            if (IsBurnOut == false && IsHungry == false && IsTired == false)
            {
                Plus = 2;
            }
            else if (IsBurnOut == true || IsHungry == true || IsTired == true)
            {
                Plus = 0;
            }
            yield return new WaitForSecondsRealtime(1);
        }
        if (IsBurnOut == false && IsHungry == false && IsTired == false)
        {
            Plus = 10;
        }
        else if (IsBurnOut == true || IsHungry == true || IsTired == true)
        {
            Plus = 5;
        }
    }

}
