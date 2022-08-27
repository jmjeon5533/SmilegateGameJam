using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : GameManager
{
    //�Ƿ� ����
    public bool IsTired = false;
    //����� ����
    public bool IsHungry = false;
    //���ƿ� ( �����ھ� ) ����
    public bool IsBurnOut = false;
    
    // ���� �� ( �� ģ���� ����ؼ� ���� �̻��� �������� )
    public int DeBuff_Range = 0;
    public int DeBuff_Time = 0;

    public bool Abort = false;
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
        Debug.Log("����� ����");
        if (IsHungry == false && IsBurnOut == false && IsTired == false) 
        {
            GmStatusPlus = 10;
            DeBuff_Time = Random.Range(15,46);
            yield return new WaitForSecondsRealtime(DeBuff_Time);
            DeBuff_Range = Random.Range(1,4);
        }
        // ������ �˻�
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
        Debug.Log("�ٸ��� ����");
        GmStatusPlus = 5;
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
            GmStatusPlus = 0;
        }
        StartCoroutine(De_Buff());
    }


    // �� �Լ��� ���߿� �Լ��⿡ �ϼ� �Ŀ��� �����ּ���.
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
