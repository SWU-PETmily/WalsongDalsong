using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Door1TimeManager : MonoBehaviour
{
    public DateTime nowTime;
    public int hh;
    public Animator DoorDayNightAnimator;
    public bool isDay;

    // 낮밤 바뀔 배경 요소
    public GameObject background;
    public GameObject pet;

    // 바꿀 이미지
    public Sprite img_day_bg;
    public Sprite img_night_bg;

    // Start is called before the first frame update
    void Start()
    {
        ChangeDayNighte();          // 낮밤 변경
    }

    // 낮밤 배경 이미지 변경 함수
    public void ChangeDayNighte()
    {
        nowTime = DateTime.Now;
        hh = nowTime.Hour;

        if (7 <= hh && hh < 19)

        {
            // 낮이라면
            this.background.GetComponent<SpriteRenderer>().sprite = this.img_day_bg;
            DoorDayNightAnimator.SetBool("isDay", true);    // 낮 강아지 애니메이터 실행
            isDay = true;
        }
        else
        {
            // 밤이라면
            this.background.GetComponent<SpriteRenderer>().sprite = this.img_night_bg;
            DoorDayNightAnimator.SetBool("isNight", true);    // 밤 강아지 애니메이터 실행
            isDay = false;
        }

    }
}
