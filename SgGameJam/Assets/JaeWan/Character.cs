using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    // �Ƿ� ����
    public bool IsTired = false;
    // ����� ����
    public bool IsHungry = false;
    // ���ƿ� ( �����ھ� ) ����
    public bool IsBurnOut = false;

    // ���� �ߴ� ����
    public bool Abort = false;

    // ���� �� ( �� ģ���� ����ؼ� ���� �̻��� �������� )
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
            // 15~45�� ���� �̳��� ����� �� Ÿ���� �����ִ� ����
            DeBuff_Time = Random.Range(1, 6);
            yield return new WaitForSecondsRealtime(DeBuff_Time);
            // ������ �ٲ��ִ� ����
            DeBuff_Range = Random.Range(1, 4);
            IsBurnOut = false;
            IsHungry = false;
            IsTired = false;

            Abort = false;
        }
        // ������ �˻�
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
            yield return new WaitForSecondsRealtime(5);
            Abort = true;
        }

        yield return new WaitForSecondsRealtime(DeBuff_Time);
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
