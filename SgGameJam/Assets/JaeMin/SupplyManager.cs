using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupplyManager : MonoBehaviour
{
    int Supplydelay; //������ �� �ð�
    bool Supplykit = false; //���� ���� ����
    void Start()
    {
        Supplydelay = Random.Range(60, 90); 
        //������ �� �ð��� 1�� ~ 1�� 30�ʷ� ����
        StartCoroutine(Supply()); //����
    }

    // Update is called once per frame
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
    }
}
