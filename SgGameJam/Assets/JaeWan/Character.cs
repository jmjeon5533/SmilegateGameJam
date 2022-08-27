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
    Text test;

    [SerializeField]
    SpriteRenderer spr;

    [SerializeField]
    Sprite[] sprites = new Sprite[4];

    // 랜덤 값 ( 이 친구에 기반해서 상태 이상이 정해진다 )
    public int DeBuff_Range = 0;
    public int DeBuff_Time = 0;
    public int DeBuff_Time_Min;
    public int DeBuff_Time_Max;

    public static int Plus;

    int Count = 0; //초

    public bool Abort = false; //추가량이 0인 상태
    void Start()
    {
        StartCoroutine(De_Buff());
    }

    void Update()
    {
        CheatKey();
        GameManager.GmStatusPlus = Plus; //개발 수치 증가량 적용
        test.text = $"허기 : {IsHungry}, 피로 : {IsTired}, 번아웃 : {IsBurnOut}";


        if (IsBurnOut == true) //스프라이트 변경
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
    IEnumerator De_Buff() //디버프
    {
        Debug.Log("디버프 실행");
        if (IsHungry == false && IsBurnOut == false && IsTired == false)
        //모든 디버프 비활성화일때
        {
            Plus = 10;
            DeBuff_Time = Random.Range(DeBuff_Time_Min, DeBuff_Time_Max); //임의의 디버프 쿨타임 지정
            yield return new WaitForSecondsRealtime(DeBuff_Time); //디버프 쿨타임
            DeBuff_Range = Random.Range(1, 4); //디버프 랜덤 상태
        }
        // 랜덤값 검사
        if (IsBurnOut == false && IsHungry == false && IsTired == false)
        //디버프가 하나도 없을 때
        {
            switch (DeBuff_Range) //랜덤으로 나옴
            {
                case 1:
                    IsBurnOut = true; //번아웃 활성화
                    break;

                case 2:
                    IsTired = true; //피로 활성화
                    break;

                case 3:
                    IsHungry = true; //배고픔 활성화
                    break;

                default:
                    StartCoroutine(De_Buff()); //다시 쿨타임을 돌리기
                    break;
            }
        }
        if (IsBurnOut == true || IsHungry == true || IsTired == true)
        {
            Plus = 0;
        }
        else if (IsBurnOut == false && IsHungry == false && IsTired == false)
        //3개 다 비활성화 상태라면
        {
            Plus = 10; //추가량은 10
        }
        StartCoroutine(De_Buff()); //이후 쿨타임 돌리기
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
    /// 버프 아이템 ▽▽▽▽▽▽
    public void Good_Ggum()
    {
        //초당 작업량 + 2
        if (IsBurnOut == false && IsHungry == false && IsTired == false)
        {
            Plus = 12;
        }
        else if (IsBurnOut == true || IsHungry == true || IsTired == true)
        {
            Plus = 7;
        }
    }
    public void Good_Americano()
    {
        //초당 작업량 + 4
        if (IsBurnOut == false && IsHungry == false && IsTired == false)
        {
            Plus = 14;
        }
        else if (IsBurnOut == true || IsHungry == true || IsTired == true)
        {
            Plus = 9;
        }
    }
    public void Good_JinRamen()
    {
        //초당 작업량 + 6 
        if (IsBurnOut == false && IsHungry == false && IsTired == false)
        {
            Plus = 16;
        }
        else if (IsBurnOut == true || IsHungry == true || IsTired == true)
        {
            Plus = 11;
        }
    }
    /// 상태이상 해제 아이템
    public void Good_PowerAde()
    {
        // 캐릭터의 모든 상태이상 회복
        IsBurnOut = false;
        IsHungry = false;
        IsTired = false;
    }
    public void Bad_CanCoffee()
    {
        // 피로 상태를 해제
        IsTired = false;
    }

    public void Bad_Yagurt()
    {
        //번아웃 상태를 해제
        IsBurnOut = false;
    }
    public void Bad_HoneyButter()
    {
        // 배고픔 상태를 해제
        IsHungry = false;
    }
    /// 상태이상 해제 & 버프 아이템
    public void Good_Monster()
    {
        //번아웃 상태를 해제 / 초당 작업량 + 7
        IsBurnOut = false;
        if (IsBurnOut == false && IsHungry == false && IsTired == false)
        {
            Plus = 17;
        }
        else if (IsBurnOut == true || IsHungry == true || IsTired == true)
        {
            Plus = 7;
        }
    }
    public void Bad_Chiken()
    {
        // 허기짐 상태 회복 / 초당 작업량 + 12
        IsHungry = false;
        if (IsBurnOut == false && IsHungry == false && IsTired == false)
        {
            Plus = 22;
        }
        else if (IsBurnOut == true || IsHungry == true || IsTired == true)
        {
            Plus = 17;
        }
    }
    

    /// 특수 아이템 ▽▽▽▽▽▽
    public void Bad_BlueFill()
    {
        DeBuff_Range = Random.Range(1, 3); //디버프 랜덤 상태

        if (IsBurnOut == false && IsHungry == false && IsTired == false)
        //디버프가 하나도 없을 때
        {
            switch (DeBuff_Range) //랜덤으로 나옴
            {
                case 1:
                    IsBurnOut = true; //번아웃 활성화
                    break;

                case 2:
                    IsTired = true; //피로 활성화
                    break;

                case 3:
                    IsHungry = true; //배고픔 활성화
                    break;
            }
        }
        else if (IsBurnOut == true || IsHungry == true || IsTired == true)
        {
            IsBurnOut = false;
            IsTired = false;
            IsHungry = false;
        }
    }
}
