using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

// 게이지 관리 && 자정 지나고 접속 시 엔딩/가상부모씬으로 이동
public class Room1Director : MonoBehaviour
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
 

        gauge.fillAmount = Mathf.Lerp(gauge.fillAmount, currentFill, Time.deltaTime);

        // 게이지가 100에 도달하면
        if (gauge.fillAmount >= 1.0f)
        {
            //스테이지 변경용 변수 초기화
            ChangeStage();
            // 가을 애니메이션 보여주기
            UnityEngine.SceneManagement.SceneManager.LoadScene("ChangeStoW");
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

        // 대소변 완료했을 시,
        if (PlayerPrefs.GetInt("successPooPeeClean") == 1)
        {
            PlayerPrefs.SetInt("successPooPeeClean", 0);             // 미션완료 초기화
            int i = PlayerPrefs.GetInt("pooCleaningNum") + 1;      // 대소변 횟수 가져오기
            PlayerPrefs.SetInt("pooCleaningNum", i);               // 대소변 횟수 저장하기
        }

        // 쓰다듬기를 완료했을 시,
        if (PlayerPrefs.GetInt("successTouch") == 1)
        {
            decreaseGaugeByTouch();
        }
    }

    // 식사급수 게이지 상승
    void increaseGaugeByFeed()
    {
        currentFill = gauge.fillAmount + 0.15f;           // 게이지 채우기
        float f = PlayerPrefs.GetFloat("guage") + 0.15f;  // 게이지값 가져오기
        PlayerPrefs.SetFloat("guage", f);                 // 게이지값 저장하기

        PlayerPrefs.SetInt("successFeed", 0);             // 미션완료 초기화

        int i = PlayerPrefs.GetInt("feedNum") + 1;      // 식사급수 횟수 가져오기
        PlayerPrefs.SetInt("feedNum", i);               // 식사급수 횟수 저장하기
    }

    // 쓰다듬기 게이지 하강
    void decreaseGaugeByTouch()
    {
        currentFill = gauge.fillAmount - 0.1f;           // 게이지 채우기
        float f = PlayerPrefs.GetFloat("guage") - 0.1f;  // 게이지값 가져오기
        PlayerPrefs.SetFloat("guage", f);                 // 게이지값 저장하기

        PlayerPrefs.SetInt("successTouch", 0);             // 미션완료 초기화
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
        if(quitTime != -1)
        {
            // 날이 바뀌었다면
            if (quitDate != exeDate)
            {
                // 24시간 이상 미접속 했다면
                if ((dateSpan == 1 && (exeTime > quitTime)) || dateSpan >= 2)
                {
                    // 엔딩 1 실행
                    Ending1Reset();             // 사용자 변수 초기화
                    UnityEngine.SceneManagement.SceneManager.LoadScene("ParentEnding1");
                }
                else
                {
                    // 가상 부모 평가로 이동
                    Debug.Log("가상 부모 평가로 이동.");
                    UnityEngine.SceneManagement.SceneManager.LoadScene("Parent1Scene");
                }
            }
        }
        
    }

    // 스테이지 변동
    private void ChangeStage()
    {
        PlayerPrefs.SetInt("stage", 2);
        PlayerPrefs.SetString("quitSceneName", "Room2Tutorial");           // 종료 씬
    }

    // 사용자 변수 초기화
    void Ending1Reset()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetString("quitSceneName", "nothing");           // 종료 씬
    }
}