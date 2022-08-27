using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    Option opt;

    public static float GmStatus = 0; //���� ���� ��ġ
    public static int GmStatusPlus = 10; //�ʴ� �ö󰡴� ���߼�ġ
    static int GmNum = 0; //���� �� ���� ����

    public static int GmMoney = 0; //���� ���� ��ȭ
    public int moneyValue = 10000; //���� ��ȭ�� �߰��� ��
    public int moneyValue2 = 3000;

    int time = 0; //�ð�

    public Text SliderText; //���� ���� ��ġ �ؽ�Ʈ
    public Slider SliderBar; //���� ���� ��ġ �����̴�

    public GameObject shadow;
    public GameObject[] ItemTab;

    private void OnValidate()
    {
        shadow.SetActive(false);
        ItemTab[0].SetActive(false);
        ItemTab[1].SetActive(false);
        ItemTab[2].SetActive(false);
    }
    void Start()
    {
        opt = GameObject.Find("OptionTab").GetComponent<Option>();
        GmStatus = 0; //ó�� ������ ���ߵ� ���� 0
        StartCoroutine(GameMaking()); //���� ���� ����
        opt.ItemPage = 0;
        SupplyManager.OptionOn = false;
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
            GmMoney += 300000;


            //���� ���� ��ȭ�� �� �ð��� �ݺ���� ���

            GmStatus = 0; //���� ��ġ�� �ʱ�ȭ
        }
        else if(GmStatus <= 10000) //���� ��ġ�� �� ���� �ʾҴٸ�
        {
            GmStatus += GmStatusPlus; //���� ���� ��ġ�� ����
            time++;
        }
        StartCoroutine(GameMaking()); //�ٽ� ����
    }
    void GmStatusSlider()
    {
        SliderText.text = $"{(GmStatus/5000)*100}%"; //��� ���� ��ġ �ؽ�Ʈ �����ֱ�
        SliderBar.value = GmStatus; //��� ���� ��ġ �����̴� �����ֱ�
    }
}
