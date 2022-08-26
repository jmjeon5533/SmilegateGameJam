using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static int GmStatus = 0; //���� ���� ��ġ
    public static int GmStatusPlus = 10; //�ʴ� �ö󰡴� ���߼�ġ
    static int GmNum = 0; //���� �� ���� ����
    public static bool Abort = false; //���� �ߴ� ����


    public Text SliderText; //���� ���� ��ġ �ؽ�Ʈ
    public Slider SliderBar; //���� ���� ��ġ �����̴�
    void Start()
    {
        GmStatus = 0; //ó�� ������ ���ߵ� ���� 0
        StartCoroutine(GameMaking()); //���� ���� ����
    }
    void Update()
    {
        GmStatusSlider();
    }
    IEnumerator GameMaking() //���� ���� ����
    {
        yield return new WaitForSeconds(1); //1�ʸ���
        if (GmStatus >= 10000) //���� ���� ��ġ�� �� ����
        {
            GmNum++; //���� ������ �ϳ� �ø���
            GmStatus = 0; //���� ��ġ�� �ʱ�ȭ
        }
        else if(GmStatus <= 10000 && !Abort) //���� ��ġ�� �� ���� �ʾҴٸ�
        {
            GmStatus += GmStatusPlus; //���� ���� ��ġ�� ����
        }
        StartCoroutine(GameMaking()); //�ٽ� ����
    }
    void GmStatusSlider()
    {
        SliderText.text = $"{GmStatus}/10000"; //��� ���� ��ġ �ؽ�Ʈ �����ֱ�
        SliderBar.value = GmStatus; //��� ���� ��ġ �����̴� �����ֱ�
    }
}
