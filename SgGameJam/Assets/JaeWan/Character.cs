using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : GameManager
{
    //피로 상태
    public bool IsTired = false;
    //배고픔 상태
    public bool IsHungry = false;
    //번아웃 ( 의지박약 ) 상태
    public bool IsBurnOut = false;
    
    // 랜덤 값 ( 이 친구에 기반해서 상태 이상이 정해진다 )
    public int DeBuff_Range = 0;
    public int DeBuff_Time = 0;
    void Start()
    {
        StartCoroutine(De_Buff());
    }

    void Update()
    {
        CheatKey();
    }
    IEnumerator De_Buff() 
    {
        if (IsBurnOut == false && IsHungry == false && IsTired == false)
        {
            Abort = false;
            // 15~45초 범위 이내로 디버프 쿨 타임을 정해주는 구문
            DeBuff_Time = Random.Range(1, 6);
            yield return new WaitForSecondsRealtime(DeBuff_Time);
            // 랜덤값 바꿔주는 구문
            DeBuff_Range = Random.Range(1, 4);
            IsBurnOut = false;
            IsHungry = false;
            IsTired = false;
        }
        // 랜덤값 검사
        switch (DeBuff_Range)
        {
            case 1:
                IsBurnOut = true;
                break;

            case 2:
                IsTired = true;
                break;

            case 3:
                IsHungry = true;
                break;

            default:
                StartCoroutine(De_Buff());
                break;
        }
        if (IsTired == true || IsHungry == true || IsBurnOut == true) 
        {
            GmStatusPlus /= 2;
            yield return new WaitForSecondsRealtime(20);
            Abort = true;
        }

        yield return new WaitForSecondsRealtime(DeBuff_Time);
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
