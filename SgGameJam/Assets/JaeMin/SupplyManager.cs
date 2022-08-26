using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SupplyManager : MonoBehaviour
{
    [SerializeField]
    int Supplydelay; //������ �� �ð�
    public static bool Supplykit = false; //���� ���� ����
    void Start()
    {
        Supplydelay = Random.Range(60, 90); 
        //������ �� �ð��� 1�� ~ 1�� 30�ʷ� ����
        StartCoroutine(Supply()); //����
    }
    void Update()
    {
        
    }
    IEnumerator Supply() //����
    {
        yield return new WaitForSeconds(Supplydelay);
        //������ �� �ð���ŭ ��ٸ� ��
        Supplykit = true; //������ �ޱ�

    }
    public void SupplyButton() //������ �޴� ��ư
    {
        Supplykit = false;
        Supplydelay = Random.Range(60, 90); //���� �ð� ������
        StartCoroutine(Supply()); //�ٽ� ��ٸ���
    }
}
