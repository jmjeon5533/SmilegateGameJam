using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SupplyManager : MonoBehaviour
{
    [SerializeField]
    int Supplydelay; //보급이 올 시간
    public static bool Supplykit = false; //보급 보유 유무
    void Start()
    {
        Supplydelay = Random.Range(60, 90); 
        //보급이 올 시간은 1분 ~ 1분 30초로 지정
        StartCoroutine(Supply()); //보급
    }
    void Update()
    {
        
    }
    IEnumerator Supply() //보급
    {
        yield return new WaitForSeconds(Supplydelay);
        //보급이 올 시간만큼 기다린 후
        Supplykit = true; //보급을 받기

    }
    public void SupplyButton() //보급을 받는 버튼
    {
        Supplykit = false;
        Supplydelay = Random.Range(60, 90); //보급 시간 재조정
        StartCoroutine(Supply()); //다시 기다리기
    }
}
