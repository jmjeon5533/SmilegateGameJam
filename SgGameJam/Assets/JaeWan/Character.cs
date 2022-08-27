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
    SpriteRenderer spr;

    [SerializeField]
    Sprite[] sprites = new Sprite[4];

    // ���� �� ( �� ģ���� ����ؼ� ���� �̻��� �������� )
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
        texts.text = Plus + " �ö��";


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
        Debug.Log("����� ����");
        if (IsHungry == false && IsBurnOut == false && IsTired == false) 
        {
            Plus = 10;
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
