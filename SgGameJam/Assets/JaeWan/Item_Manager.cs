using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Manager : Character
{
    void Start()
    {
        
    }
    void Update()
    {
        
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
        if (IsBurnOut == false && IsHungry == false && IsTired == false)
        {
            Plus = 12;
        }
        else if (IsBurnOut == true || IsHungry == true || IsTired == true) 
        {
            Plus = 7;
        }
        yield return new WaitForSecondsRealtime(5);
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
        if (IsBurnOut == false && IsHungry == false && IsTired == false)
        {
            Plus = 18;
        }
        else if (IsBurnOut == true || IsHungry == true || IsTired == true) 
        {
            Plus = 13;
        }
        yield return new WaitForSecondsRealtime(5);
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
        if (IsBurnOut == false && IsHungry == false && IsTired == false)
        {
            Plus = 13;
        }
        else if (IsBurnOut == true || IsHungry == true || IsTired == true)
        {
            Plus = 8;
        }
        yield return new WaitForSecondsRealtime(5);
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
        if (IsBurnOut == false && IsHungry == false && IsTired == false)
        {
            Plus = 14;
        }
        else if (IsBurnOut == true || IsHungry == true || IsTired == true)
        {
            Plus = 9;
        }
        yield return new WaitForSecondsRealtime(5);
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
        if (IsBurnOut == false && IsHungry == false && IsTired == false)
        {
            Plus = 2;
        }
        else if (IsBurnOut == true || IsHungry == true || IsTired == true)
        {
            Plus = 0;
        }
        yield return new WaitForSecondsRealtime(5);
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
