using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : GameManager
{
    //�Ƿ� ����
    public static bool IsTired = false;
    //����� ����
    public static bool IsHungry = false;
    //���ƿ� ( �����ھ� ) ����
    public static bool IsBurnOut = false;

    [SerializeField]
    Text texts;

    [SerializeField]
    Text test;

    [SerializeField]
    SpriteRenderer spr;

    [SerializeField]
    Sprite[] sprites = new Sprite[4];

    // ���� �� ( �� ģ���� ����ؼ� ���� �̻��� �������� )
    public int DeBuff_Range = 0;
    public int DeBuff_Time = 0;
    public int DeBuff_Time_Min;
    public int DeBuff_Time_Max;

    public static int Plus;

    int Count = 0; //��

    public bool Abort = false; //�߰����� 0�� ����
    void Start()
    {
        StartCoroutine(De_Buff());
    }

    void Update()
    {
        CheatKey();
        GameManager.GmStatusPlus = Plus; //���� ��ġ ������ ����
        test.text = $"��� : {IsHungry}, �Ƿ� : {IsTired}, ���ƿ� : {IsBurnOut}";


        if (IsBurnOut == true) //��������Ʈ ����
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
    IEnumerator De_Buff() //�����
    {
        Debug.Log("����� ����");
        if (IsHungry == false && IsBurnOut == false && IsTired == false)
        //��� ����� ��Ȱ��ȭ�϶�
        {
            Plus = 10;
            DeBuff_Time = Random.Range(DeBuff_Time_Min, DeBuff_Time_Max); //������ ����� ��Ÿ�� ����
            yield return new WaitForSecondsRealtime(DeBuff_Time); //����� ��Ÿ��
            DeBuff_Range = Random.Range(1, 4); //����� ���� ����
        }
        // ������ �˻�
        if (IsBurnOut == false && IsHungry == false && IsTired == false)
        //������� �ϳ��� ���� ��
        {
            switch (DeBuff_Range) //�������� ����
            {
                case 1:
                    IsBurnOut = true; //���ƿ� Ȱ��ȭ
                    break;

                case 2:
                    IsTired = true; //�Ƿ� Ȱ��ȭ
                    break;

                case 3:
                    IsHungry = true; //����� Ȱ��ȭ
                    break;

                default:
                    StartCoroutine(De_Buff()); //�ٽ� ��Ÿ���� ������
                    break;
            }
        }
        if (IsBurnOut == true || IsHungry == true || IsTired == true)
        {
            Plus = 0;
        }
        else if (IsBurnOut == false && IsHungry == false && IsTired == false)
        //3�� �� ��Ȱ��ȭ ���¶��
        {
            Plus = 10; //�߰����� 10
        }
        StartCoroutine(De_Buff()); //���� ��Ÿ�� ������
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
    /// ���� ������ �������
    public void Good_Ggum()
    {
        //�ʴ� �۾��� + 2
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
        //�ʴ� �۾��� + 4
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
        //�ʴ� �۾��� + 6 
        if (IsBurnOut == false && IsHungry == false && IsTired == false)
        {
            Plus = 16;
        }
        else if (IsBurnOut == true || IsHungry == true || IsTired == true)
        {
            Plus = 11;
        }
    }
    /// �����̻� ���� ������
    public void Good_PowerAde()
    {
        // ĳ������ ��� �����̻� ȸ��
        IsBurnOut = false;
        IsHungry = false;
        IsTired = false;
    }
    public void Bad_CanCoffee()
    {
        // �Ƿ� ���¸� ����
        IsTired = false;
    }

    public void Bad_Yagurt()
    {
        //���ƿ� ���¸� ����
        IsBurnOut = false;
    }
    public void Bad_HoneyButter()
    {
        // ����� ���¸� ����
        IsHungry = false;
    }
    /// �����̻� ���� & ���� ������
    public void Good_Monster()
    {
        //���ƿ� ���¸� ���� / �ʴ� �۾��� + 7
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
        // ����� ���� ȸ�� / �ʴ� �۾��� + 12
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
    

    /// Ư�� ������ �������
    public void Bad_BlueFill()
    {
        DeBuff_Range = Random.Range(1, 3); //����� ���� ����

        if (IsBurnOut == false && IsHungry == false && IsTired == false)
        //������� �ϳ��� ���� ��
        {
            switch (DeBuff_Range) //�������� ����
            {
                case 1:
                    IsBurnOut = true; //���ƿ� Ȱ��ȭ
                    break;

                case 2:
                    IsTired = true; //�Ƿ� Ȱ��ȭ
                    break;

                case 3:
                    IsHungry = true; //����� Ȱ��ȭ
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
