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

    public static int Plus, PlusUnDebuff = 10,PlusDebuff = 5;//개발 수치 추가량

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
        texts.text = Plus + " 올라요";
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
            Plus = PlusUnDebuff; //추가량은 기본 10
            DeBuff_Time = Random.Range(DeBuff_Time_Min,DeBuff_Time_Max); //임의의 디버프 쿨타임 지정
            yield return new WaitForSecondsRealtime(DeBuff_Time); //디버프 쿨타임
            DeBuff_Range = Random.Range(1,4); //디버프 랜덤 상태
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
        //만약 3개중 하나라도 활성화 되면
        {
            Plus = PlusDebuff; //추가량은 5
            for (int i = 0; i < 20; i++)
            {
                if (IsBurnOut == false && IsHungry == false && IsTired == false)
                    break;
                else
                    yield return new WaitForSeconds(1);
            }
            Plus = 0; //추가량 없음
        }
        if (IsBurnOut == false && IsHungry == false && IsTired == false)
        //3개 다 비활성화 상태라면
        {
            Plus = PlusUnDebuff; //추가량은 10
            //임의의 쿨타임 초기화
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
    /// 긍정적 아이템 ▽▽▽▽▽▽
    public void Good_Americano()
    {
        // 의지 박약 상태 회복 / 초당 작업량 +2
        IsBurnOut = false;
        Abort = false;
        if(IsBurnOut == false && IsHungry == false && IsTired == false)
        {
            Plus = PlusUnDebuff + 2;
        }
        else if(IsBurnOut == true || IsHungry == true || IsTired == true)
        {
            Plus = PlusDebuff + 2;
        }
    }

    public void Good_Monster()
    {
        // 초당 작업량 + 8
        Abort = false;
        if (IsBurnOut == false && IsHungry == false && IsTired == false)
        {
            Plus = PlusUnDebuff + 8;
        }
        else if (IsBurnOut == true || IsHungry == true || IsTired == true)
        {
            Plus = PlusDebuff + 8;
        }
    }

    public void Good_PowerAde()
    {
        // 캐릭터의 모든 상태이상 회복
        Abort = false;
        IsBurnOut = false;
        IsHungry = false;
        IsTired = false;
    }
    public void Good_JinRamen()
    {
        // 허기짐 상태 회복 / 초당 작업량 +3
        Abort = false;
        IsHungry = false;
        if (IsBurnOut == false && IsHungry == false && IsTired == false)
        {
            Plus = PlusUnDebuff + 3;
        }
        else if (IsBurnOut == true || IsHungry == true || IsTired == true)
        {
            Plus = PlusDebuff + 3;
        }
    }
    public void Good_Ggum()
    {
        // 피로 상태 회복 / 초당 작업량 +4
        Abort = false;
        IsTired = false;
        if (IsBurnOut == false && IsHungry == false && IsTired == false)
        {
            Plus = PlusUnDebuff + 4;
        }
        else if (IsBurnOut == true || IsHungry == true || IsTired == true)
        {
            Plus = PlusDebuff + 4;
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
        //  허기짐 상태로 만듬
        IsHungry = true;
    }
    public void Bad_Chiken()
    {
        // 허기짐 상태 회복 / 작업량 없음
        IsHungry = false;
        Plus = 0;
    }
}
