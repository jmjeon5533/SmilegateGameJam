using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    Option opt;

    public static float GmStatus = 0; //게임 개발 수치
    public static int GmStatusPlus = 10; //초당 올라가는 개발수치
    static int GmNum = 0; //만든 총 게임 개수

    public static int GmMoney = 0; //게임 외적 재화
    public int moneyValue = 10000; //외적 재화에 추가될 양
    public int moneyValue2 = 3000;

    int time = 0; //시간

    public Text SliderText; //게임 개발 수치 텍스트
    public Slider SliderBar; //게임 개발 수치 슬라이더

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
        GmStatus = 0; //처음 게임이 개발된 양은 0
        StartCoroutine(GameMaking()); //게임 개발 과정
        opt.ItemPage = 0;
        SupplyManager.OptionOn = false;
    }
    void Update()
    {
        GmStatusSlider();
    }
    IEnumerator GameMaking() //게임 개발 과정
    {
        yield return new WaitForSeconds(1); //1초마다
        if (GmStatus >= 10000) //만약 개발 수치가 꽉 차면
        {
            GmMoney += 300000;


            //게임 외적 재화를 깬 시간에 반비례해 얻기

            GmStatus = 0; //개발 수치는 초기화
        }
        else if(GmStatus <= 10000) //개발 수치가 꽉 차지 않았다면
        {
            GmStatus += GmStatusPlus; //게임 개발 수치를 높임
            time++;
        }
        StartCoroutine(GameMaking()); //다시 실행
    }
    void GmStatusSlider()
    {
        SliderText.text = $"{(GmStatus/5000)*100}%"; //계속 개발 수치 텍스트 보여주기
        SliderBar.value = GmStatus; //계속 개발 수치 슬라이더 보여주기
    }
}
