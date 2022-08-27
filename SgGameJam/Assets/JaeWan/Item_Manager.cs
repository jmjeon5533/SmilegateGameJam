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
        // ���� �ھ� ���� ȸ�� / �ʴ� �۾��� +2
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
        // �ʴ� �۾��� +8
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
        // ĳ������ ��� �����̻� ȸ��
        IsBurnOut = false;
        IsHungry = false;
        IsTired = false;
    }
    public void Good_JinRamen()
    {
        // ����� ���� ȸ�� / �ʴ� �۾��� +3
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
        // �Ƿ� ���� ȸ�� / �ʴ� �۾��� +4
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

    /// ������ ������ �������
    public void Bad_HoneyButter() 
    {
        // ���� �ھ� ���·� ����
        IsBurnOut = true;
    }

    public void Bad_CanCoffee() 
    {
        // �Ƿ� ���·� ����
        IsTired = true;
    }

    public void Bad_BlueFill()
    {
        // ���� ��ô�� 10% ��´�
        GameManager.GmStatus -= (GameManager.GmStatus / 10);
    }
    public void Bad_Yagurt() 
    {
        //  ����� ���·� ����
        IsHungry = true;
    }
    public void Bad_Chiken() 
    {
        // ����� ���� ȸ�� / �۾��� -8
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
