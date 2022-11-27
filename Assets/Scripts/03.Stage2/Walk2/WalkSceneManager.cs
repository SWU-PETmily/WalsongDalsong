using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class WalkSceneManager : MonoBehaviour
{
    public DateTime nowTime;
    public int hh;      // 시
    public int ss;      // 초
    public bool isDay;                   // 낮 확인 변수
    public GameObject snowman;           // 눈강아지
    public GameObject posSnowman1;       // 눈강아지 생성 위치1
    public GameObject posSnowman2;       // 눈강아지 생성 위치2

    // 낮밤 바뀔 배경 요소
    public GameObject background;
    public GameObject dayPet;
    public GameObject nightPet;

    // 바꿀 이미지
    public Sprite img_day_bg;
    public Sprite img_night_bg;

    void Start()
    {
        nowTime = DateTime.Now;
        CreateRandomSnownman();     // 눈 강아지 랜덤 위치 생성
        ChangeDayNighte();          // 낮밤 변경
    }

    // 눈강아지 랜덤 위치 생성
    public void CreateRandomSnownman()
    {
        ss = nowTime.Second;        // 현재 초
        if (ss % 2 == 0)
        {
            // 짝수 초라면
            snowman.transform.position = posSnowman1.transform.position;      // 왼쪽에 위치
        }
        else
        {
            // 홀수 초라면
            snowman.transform.position = posSnowman2.transform.position;      // 오른쪽에 위치
        }
    }

    // 낮밤 배경 이미지 변경 함수
    public void ChangeDayNighte()
    {
        hh = nowTime.Hour;          // 현재 시각

        if (7 <= hh && hh < 19)

        {
            // 낮이라면
            this.background.GetComponent<SpriteRenderer>().sprite = this.img_day_bg;
            dayPet.SetActive(true);
            nightPet.SetActive(false);
            isDay = true;
        }
        else
        {
            // 밤이라면
            this.background.GetComponent<SpriteRenderer>().sprite = this.img_night_bg;
            dayPet.SetActive(false);
            nightPet.SetActive(true);
            isDay = false;
        }

    }
}
