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

    public static int Plus, PlusUnDebuff = 10,PlusDebuff = 5;//���� ��ġ �߰���

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
        texts.text = Plus + " �ö��";
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
            Plus = PlusUnDebuff; //�߰����� �⺻ 10
            DeBuff_Time = Random.Range(DeBuff_Time_Min,DeBuff_Time_Max); //������ ����� ��Ÿ�� ����
            yield return new WaitForSecondsRealtime(DeBuff_Time); //����� ��Ÿ��
            DeBuff_Range = Random.Range(1,4); //����� ���� ����
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
        //���� 3���� �ϳ��� Ȱ��ȭ �Ǹ�
        {
            Plus = PlusDebuff; //�߰����� 5
            for (int i = 0; i < 20; i++)
            {
                if (IsBurnOut == false && IsHungry == false && IsTired == false)
                    break;
                else
                    yield return new WaitForSeconds(1);
            }
            Plus = 0; //�߰��� ����
        }
        if (IsBurnOut == false && IsHungry == false && IsTired == false)
        //3�� �� ��Ȱ��ȭ ���¶��
        {
            Plus = PlusUnDebuff; //�߰����� 10
            //������ ��Ÿ�� �ʱ�ȭ
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
    /// ������ ������ �������
    public void Good_Americano()
    {
        // ���� �ھ� ���� ȸ�� / �ʴ� �۾��� +2
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
        // �ʴ� �۾��� + 8
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
        // ĳ������ ��� �����̻� ȸ��
        Abort = false;
        IsBurnOut = false;
        IsHungry = false;
        IsTired = false;
    }
    public void Good_JinRamen()
    {
        // ����� ���� ȸ�� / �ʴ� �۾��� +3
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
        // �Ƿ� ���� ȸ�� / �ʴ� �۾��� +4
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
        // ����� ���� ȸ�� / �۾��� ����
        IsHungry = false;
        Plus = 0;
    }
}
