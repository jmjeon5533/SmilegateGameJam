using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SupplyManager : MonoBehaviour
{
    Inventory inv;
    [SerializeField]
    public int Supplydelay; //보급이 올 시간
    public static bool Supplykit = false; //보급 보유 유무

    public int Supplymin;
    public int SupplyMax;

    public static bool OptionOn = false;

    public Item[] RandomItem = new Item[11];
    void Start()
    {
        inv = GameObject.Find("Inventory").GetComponent<Inventory>();
        Supplydelay = Random.Range(Supplymin, SupplyMax); 
        //보급이 올 시간은 1분 ~ 1분 30초로 지정
        StartCoroutine(Supply()); //보급
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Option();
        }
    }
    public IEnumerator Supply() //보급
    {
        yield return new WaitForSeconds(Supplydelay);
        //보급이 올 시간만큼 기다린 후
        Supplykit = true; //보급을 받기
        Supplydelay = Random.Range(Supplymin, SupplyMax); //보급 시간 재조정
        

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
            print("슬롯이 가득 차 있습니다.");
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
