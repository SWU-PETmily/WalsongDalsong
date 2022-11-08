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
        // 임시 변수
        PlayerPrefs.SetInt("feedNum", 0);
        PlayerPrefs.SetInt("pooCleaningNum", 0);
        PlayerPrefs.SetInt("peeCleaningNum", 0);
        PlayerPrefs.SetFloat("guage", 0.1f);


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
        if(gauge.fillAmount >= 1.0f)
        {
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
        //this.gauge.GetComponent<Image>().fillAmount += 0.15f;
        currentFill = gauge.fillAmount + 0.15f;
        PlayerPrefs.SetInt("successFeed", 0);             // 미션완료 초기화
        float f = PlayerPrefs.GetFloat("guage") + 0.15f;
        PlayerPrefs.SetFloat("guage", f);

    }

    // 배소변 게이지 상승
    void increaseGaugeByPooPee()
    {
        this.gauge.GetComponent<Image>().fillAmount += 0.05f;
        PlayerPrefs.SetInt("successPooPeeClean", 0);             // 미션완료 초기화
        float f = PlayerPrefs.GetFloat("guage") + 0.1f;
        PlayerPrefs.SetFloat("guage", f);
    }

    // 종료시 실행
    private void OnApplicationQuit()
    {
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
}