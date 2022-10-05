using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

// 게이지 관리 && 자정 지나고 접속 시 변수 초기화
public class Room1Director : MonoBehaviour
{
    public GameObject gauge;

    public DateTime nowTime;

    void Start()
    {
        
    }

    void Update()
    {
        controlGauge();     // 게이지 조정
    }

    // 게이지 변동
    void controlGauge()
    {
        // 식사급수 완료했을 시, 완료 횟수가 2 이하라면
        if (PlayerPrefs.GetInt("successFeed") == 1 && PlayerPrefs.GetInt("feedNum") <= 2)
        {
            increaseGaugeByFeed();
        }
        // 배변 완료했을 시, 완료 횟수가 5 이하라면
        else if (PlayerPrefs.GetInt("successPooPeeClean") == 1 && PlayerPrefs.GetInt("pooCleaningNum") <= 5)
        {
            increaseGaugeByPooPee();
        }
        // 소변 완료했을 시, 완료 횟수가 5 이하라면
        else if (PlayerPrefs.GetInt("successPooPeeClean") == 1 && PlayerPrefs.GetInt("peeCleaningNum") <= 5)
        {
            increaseGaugeByPooPee();
        }
    }

    // 식사급수 게이지 상승
    void increaseGaugeByFeed()
    {
        this.gauge.GetComponent<Image>().fillAmount += 0.1f;
        PlayerPrefs.SetInt("successFeed", 0);                   // 미션완료 초기화
    }

    // 배소변 게이지 상승
    void increaseGaugeByPooPee()
    {
        this.gauge.GetComponent<Image>().fillAmount += 0.05f;
        PlayerPrefs.SetInt("successPooPeeClean", 0);             // 미션완료 초기화
    }
}
