using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class Room2Director : MonoBehaviour
{
    public Image gauge;

    int quitDate;             // 종료한 날짜
    int exeDate;              // 실행한 날짜
    int quitTime;             // 종료한 시간
    int exeTime;              // 실행한 시간

    private float currentFill;           // 현재 게이지 

    void Start()
    {
        Debug.Log(PlayerPrefs.GetFloat("guage"));
        gauge.fillAmount = PlayerPrefs.GetFloat("guage");       // 현재 게이지 이미지 채우기
        currentFill = PlayerPrefs.GetFloat("guage");            // 현재 게이지

        ExeDateCheck();       //시작 날짜시간 체크
        TimeSpans();
    }

    void Update()
    {
        controlGauge();     // 게이지 조정
        Debug.Log( gauge.fillAmount);

        if (gauge.fillAmount < currentFill)
        {
            gauge.fillAmount = Mathf.Lerp(gauge.fillAmount, currentFill, Time.deltaTime);
        }

        // 게이지가 100에 도달하면
        if (gauge.fillAmount >= 1.0f)
        {
            // 현재 경고레벨 확인
            int badLevel = PlayerPrefs.GetInt("badLevel");

            // 엔딩용 변수 초기화
            EndingReset();               // 사용자 변수 초기화

            // 한 번이라도 경고를 받았다면
            if (badLevel >= 2)
            {
                // 실종 엔딩
                UnityEngine.SceneManagement.SceneManager.LoadScene("EndingDisplay2");
            }
            // 한 번도 경고를 안 받았다면
            else
            {
                // 꿈 엔딩
                UnityEngine.SceneManagement.SceneManager.LoadScene("EndingDisplay3");
            }
        }
    }

    // btn
    public void btn()
    {
        currentFill = gauge.fillAmount + 0.15f;           // 게이지 채우기
        float f = PlayerPrefs.GetFloat("guage") + 0.15f;  // 게이지값 가져오기
        PlayerPrefs.SetFloat("guage", f);                 // 게이지값 저장하기
    }

    // 게이지 변동
    void controlGauge()
    {
        // 식사급수 완료했을 시, 완료 횟수가 2 이하라면
        if (PlayerPrefs.GetInt("successFeed") == 1 && PlayerPrefs.GetInt("feedNum") < 2)
        {
            increaseGaugeByFeed();
        }

        // 산책 완료했을 시, 완료 횟수가 2 이하라면
        if (PlayerPrefs.GetInt("successWalk") == 1 && PlayerPrefs.GetInt("walkNum") < 2)
        {
            increaseGaugeByWalk();
        }

        // 대소변 완료했을 시,
        if (PlayerPrefs.GetInt("successPooPeeClean") == 1)
        {
            PlayerPrefs.SetInt("successPooPeeClean", 0);             // 미션완료 초기화
            int i = PlayerPrefs.GetInt("pooCleaningNum") + 1;      // 대소변 횟수 가져오기
            PlayerPrefs.SetInt("pooCleaningNum", i);               // 대소변 횟수 저장하기
        }

        // 쓰다듬기 완료했을 시, 완료 횟수가 2 이하라면
        if (PlayerPrefs.GetInt("successTouch") == 1 && PlayerPrefs.GetInt("touchingNum") < 2)
        {
            increaseGaugeByTouch();
        }
    }

    // 식사급수 게이지 상승
    void increaseGaugeByFeed()
    {
        currentFill = gauge.fillAmount + 0.05f;           // 게이지 채우기
        float f = PlayerPrefs.GetFloat("guage") + 0.05f;  // 게이지값 가져오기
        PlayerPrefs.SetFloat("guage", f);                 // 게이지값 저장하기

        PlayerPrefs.SetInt("successFeed", 0);             // 미션완료 초기화

        int i = PlayerPrefs.GetInt("feedNum") + 1;      // 식사급수 횟수 가져오기
        PlayerPrefs.SetInt("feedNum", i);               // 식사급수 횟수 저장하기
    }

    // 산책 게이지 상승
    void increaseGaugeByWalk()
    {
        currentFill = gauge.fillAmount + 0.05f;           // 게이지 채우기
        float f = PlayerPrefs.GetFloat("guage") + 0.05f;  // 게이지값 가져오기
        PlayerPrefs.SetFloat("guage", f);                 // 게이지값 저장하기

        PlayerPrefs.SetInt("successWalk", 0);             // 미션완료 초기화

        int i = PlayerPrefs.GetInt("walkNum") + 1;      // 산책 횟수 가져오기
        PlayerPrefs.SetInt("walkNum", i);               // 산책 횟수 저장하기
    }

    // 쓰다듬기 게이지 상승
    void increaseGaugeByTouch()
    {
        currentFill = gauge.fillAmount + 0.05f;           // 게이지 채우기
        float f = PlayerPrefs.GetFloat("guage") + 0.05f;  // 게이지값 가져오기
        PlayerPrefs.SetFloat("guage", f);                 // 게이지값 저장하기

        PlayerPrefs.SetInt("successTouch", 0);             // 미션완료 초기화

        int i = PlayerPrefs.GetInt("touchingNum") + 1;      // 산책 횟수 가져오기
        PlayerPrefs.SetInt("touchingNum", i);               // 산책 횟수 저장하기
    }

    // 시작 날짜 시간 체크
    private void ExeDateCheck()
    {
        exeDate = int.Parse(System.DateTime.Now.ToString("yyyyMMdd"));
        exeTime = int.Parse(System.DateTime.Now.ToString("HHmm"));

        Debug.Log("시작 날짜 : " + exeDate);
        Debug.Log("시작 시간 : " + exeTime);
    }

    // 시간 간격
    private void TimeSpans()
    {
        quitDate = PlayerPrefs.GetInt("quitDate");
        quitTime = PlayerPrefs.GetInt("quitTime");
        int dateSpan = exeDate - quitDate;          // 날짜 차이

        // 첫 시작이 아니라면
        if (quitTime != -1)
        {
            // 날이 바뀌었다면
            if (quitDate != exeDate)
            {
                // 24시간 이상 미접속 했다면
                if ((dateSpan == 1 && (exeTime > quitTime)) || dateSpan >= 2)
                {
                    // 엔딩 1 실행
                    Debug.Log("엔딩 1로 이동.");
                    EndingReset();             // 사용자 변수 초기화
                    UnityEngine.SceneManagement.SceneManager.LoadScene("ParentEnding1");
                }
                else
                {
                    // 경고를 3회 초과했다면
                    int level = PlayerPrefs.GetInt("badLevel");
                    if(level == 4)
                    {
                        // 엔딩 2 실행
                        Debug.Log("엔딩 2로 이동.");
                        EndingReset();             // 사용자 변수 초기화
                        UnityEngine.SceneManagement.SceneManager.LoadScene("EndingDisplay2");
                    }
                    else
                    {
                        // 가상 부모 평가로 이동
                        Debug.Log("가상 부모 평가로 이동.");
                        UnityEngine.SceneManagement.SceneManager.LoadScene("Parent2Scene");
                    }
                }
            }
        } 
    }

    // 엔딩1. 사용자 변수 초기화
    void EndingReset()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetString("quitSceneName", "nothing");           // 종료 씬
       
    }
}
