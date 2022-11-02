using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PuppyDayNightController : MonoBehaviour
{

    private Animator puppyDayWalk;
    public DateTime nowTime;
    public int hh;

    // Start is called before the first frame update
    void Start()
    {
        puppyDayWalk = GetComponent<Animator>();
        ChangeDayNighte();          // 낮밤 강아지 이미지 변경
    }

    // 낮밤 배경 이미지 변경 함수
    public void ChangeDayNighte()
    {
        nowTime = DateTime.Now;
        hh = nowTime.Hour;

        if (7 <= hh && hh < 19)

        {
            // 낮이라면
            puppyDayWalk.SetTrigger("DayTrigger");    // 낮 강아지 애니메이터 실행
        }
        else
        {
            // 밤이라면
            puppyDayWalk.SetTrigger("NightTrigger");    // 밤 강아지 애니메이터 실행
        }

    }
}
