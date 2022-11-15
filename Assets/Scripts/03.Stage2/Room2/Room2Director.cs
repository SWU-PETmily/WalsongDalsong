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
        // 임시 변수
        /*
        PlayerPrefs.SetInt("feedNum", 0);
        PlayerPrefs.SetInt("pooCleaningNum", 0);
        PlayerPrefs.SetInt("peeCleaningNum", 0);
        PlayerPrefs.SetFloat("guage", 0.1f);
        PlayerPrefs.SetInt("stage", 2);
        */

        Debug.Log(PlayerPrefs.GetFloat("guage"));
        gauge.fillAmount = PlayerPrefs.GetFloat("guage");       // 현재 게이지 이미지 채우기
        currentFill = PlayerPrefs.GetFloat("guage");            // 현재 게이지

        ExeDateCheck();       //시작 날짜시간 체크
        TimeSpans();
    }

    void Update()
    {
        controlGauge();     // 게이지 조정
        if (gauge.fillAmount < currentFill)
        {
            gauge.fillAmount = Mathf.Lerp(gauge.fillAmount, currentFill, Time.deltaTime);
        }

        // 게이지가 100에 도달하면
        if (gauge.fillAmount >= 1.0f)
        {
            //스테이지 변경용 변수 초기화
            ChangeStage();
            // 가을 애니메이션 보여주기
            UnityEngine.SceneManagement.SceneManager.LoadScene("SummerToWinterScene");
        }

    }

    // btn
    public void btn()
    {
        increaseGaugeByFeed();
    }


    // 게이지 변동
    void controlGauge()
    {
        // 식사급수 완료했을 시, 완료 횟수가 2 이하라면
        if (PlayerPrefs.GetInt("successFeed") == 1 && PlayerPrefs.GetInt("feedNum") <= 2)
        {
            increaseGaugeByFeed();
        }
        // 산책 완료했을 시, 완료 횟수가 2 이하라면
        else if (PlayerPrefs.GetInt("successWalk") == 1 && PlayerPrefs.GetInt("walkNum") <= 2)
        {
            increaseGaugeByWalk();
        }

        /*
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
        */
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

    // 종료시 실행
    private void OnApplicationPause()
    {
        PlayerPrefs.SetString("quitSceneName", "Room2Scene");   // 종료씬 저장
        QuitDateCheck(); //종료날짜시간 체크
    }

    // 종료 날짜 시간 체크
    private void QuitDateCheck()
    {
        quitDate = int.Parse(System.DateTime.Now.ToString("yyyyMMdd"));
        quitTime = int.Parse(System.DateTime.Now.ToString("HHmm"));

        Debug.Log("종료 날짜 : " + quitDate);
        Debug.Log("종료 시간 : " + quitTime);

        PlayerPrefs.SetInt("quitDate", quitDate);
        PlayerPrefs.SetInt("quitTime", quitTime);

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

        // 날이 바뀌었다면
        if (quitDate != exeDate)
        {
            // 24시간 이상 미접속 했다면
            if ((dateSpan == 1 && (exeTime > quitTime)) || dateSpan >= 2)
            {
                // 엔딩 1 실행
                Debug.Log("엔딩 1로 이동.");
                UnityEngine.SceneManagement.SceneManager.LoadScene("Ending1");
            }
            else
            {
                // 가상 부모 평가로 이동
                Debug.Log("가상 부모 평가로 이동.");
                UnityEngine.SceneManagement.SceneManager.LoadScene("Parent1Scene");
            }
        }
    }

    // 스테이지 변동
    private void ChangeStage()
    {
        PlayerPrefs.SetInt("stage", 2);
        Debug.Log(PlayerPrefs.GetInt("stage"));
        PlayerPrefs.SetInt("successFeed", 0);
        PlayerPrefs.SetInt("successPooPeeClean", 0);
        PlayerPrefs.SetFloat("guage", 0.0f);
        PlayerPrefs.SetInt("goodLevel", 0);
        PlayerPrefs.SetInt("badLevel", 0);
        PlayerPrefs.SetInt("feedLevel", 0);
    }
}
