using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static int GmStatus; //���� ���� ��ġ

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
        GmStatus += 10; //���� ���� ��ġ�� 10 ����
        StartCoroutine(GameMaking()); //�ٽ� ����
    }
    void GmStatusSlider()
    {
        SliderText.text = $"{GmStatus}/10000"; //��� ���� ��ġ �ؽ�Ʈ �����ֱ�
        SliderBar.value = GmStatus; //��� ���� ��ġ �����̴� �����ֱ�
    }
}
