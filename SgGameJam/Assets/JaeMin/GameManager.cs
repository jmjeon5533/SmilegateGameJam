using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static int GmStatus = 0; //게임 개발 수치
    public static int GmStatusPlus = 10; //초당 올라가는 개발수치
    static int GmNum = 0; //만든 총 게임 개수
    public static bool Abort = false; //개발 중단 상태


    public Text SliderText; //게임 개발 수치 텍스트
    public Slider SliderBar; //게임 개발 수치 슬라이더
    void Start()
    {
        GmStatus = 0; //처음 게임이 개발된 양은 0
        StartCoroutine(GameMaking()); //게임 개발 과정
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
            GmNum++; //게임 개수를 하나 늘리고
            GmStatus = 0; //개발 수치는 초기화
        }
        else if(GmStatus <= 10000 && !Abort) //개발 수치가 꽉 차지 않았다면
        {
            GmStatus += GmStatusPlus; //게임 개발 수치를 높임
        }
        StartCoroutine(GameMaking()); //다시 실행
    }
    void GmStatusSlider()
    {
        SliderText.text = $"{GmStatus}/10000"; //계속 개발 수치 텍스트 보여주기
        SliderBar.value = GmStatus; //계속 개발 수치 슬라이더 보여주기
    }
}
