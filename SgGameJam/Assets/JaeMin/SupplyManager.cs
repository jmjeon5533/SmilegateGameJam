using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SupplyManager : MonoBehaviour
{
    Inventory inv;
    [SerializeField]
    public int Supplydelay; //������ �� �ð�
    public static bool Supplykit = false; //���� ���� ����

    public int Supplymin;
    public int SupplyMax;

    public static bool OptionOn = false;

    public Item[] RandomItem = new Item[11];
    void Start()
    {
        inv = GameObject.Find("Inventory").GetComponent<Inventory>();
        Supplydelay = Random.Range(Supplymin, SupplyMax); 
        //������ �� �ð��� 1�� ~ 1�� 30�ʷ� ����
        StartCoroutine(Supply()); //����
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Option();
        }
    }
    public IEnumerator Supply() //����
    {
        yield return new WaitForSeconds(Supplydelay);
        //������ �� �ð���ŭ ��ٸ� ��
        Supplykit = true; //������ �ޱ�
        Supplydelay = Random.Range(Supplymin, SupplyMax); //���� �ð� ������
        

    }
    public void Additem()
    {
        if (inv.items.Count < inv.slots.Length)
        {
            inv.items.Add(RandomItem[Random.Range(0, 10)]);
            inv.FreshSlot();
            Supplykit = false;
            StartCoroutine(Supply());
        }
        else
        {
            print("������ ���� �� �ֽ��ϴ�.");
        }
    }
    public void Option()
    {
        OptionOn = !OptionOn;
    }
    public void Exit()
    {
        SceneManager.LoadScene("Title");
    }
}
