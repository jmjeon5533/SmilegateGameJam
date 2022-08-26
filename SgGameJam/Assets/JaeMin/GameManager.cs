using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static int GmStatus; //게임 개발 수치

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
        GmStatus += 10; //게임 개발 수치를 10 높임
        StartCoroutine(GameMaking()); //다시 실행
    }
    void GmStatusSlider()
    {
        SliderText.text = $"{GmStatus}/10000"; //계속 개발 수치 텍스트 보여주기
        SliderBar.value = GmStatus; //계속 개발 수치 슬라이더 보여주기
    }
}
