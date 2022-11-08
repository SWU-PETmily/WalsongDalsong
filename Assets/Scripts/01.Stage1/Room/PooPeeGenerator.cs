using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PooPeeGenerator : MonoBehaviour
{
    //public DateTime nowTime;
    int exeTime;                         // 실행한 시간
    float firstTime = 30.0f;            // 경과시간. 30초 후
    float waitTime = 60.0f;            // 경과시간. 60초 후


    // 배소변 프리팹
    public GameObject poo1;
    public GameObject poo2;
    public GameObject pee1;
    public GameObject pee2;

    // Start is called before the first frame update
    void Start()
    {
        // 실행한 시간 저장
        exeTime = int.Parse(System.DateTime.Now.ToString("HHmm"));
        if (exeTime % 2 == 1)
        {
            // 배변 코루틴 시작
            StartCoroutine("PooRoutine");
        }
        else
        {
            // 소변 코루틴 시작
            StartCoroutine("PeeRoutine");
        }
    
    }

    // 게임 시작 후 30초 뒤 배소변
    IEnumerator PooRoutine()
    {
        yield return new WaitForSeconds(firstTime);              // 첫 시작 대기
        while (true)
        {
            Instantiate(poo1, transform.position, transform.rotation);          // 루틴 대기
            yield return new WaitForSeconds(waitTime);
        }
    }

    // 게임 시작 후 30초 뒤 배소변
    IEnumerator PeeRoutine()
    {
        yield return new WaitForSeconds(firstTime);              // 첫 시작 대기
        while (true)
        {
            Instantiate(pee1, transform.position, transform.rotation);          // 루틴 대기
            yield return new WaitForSeconds(waitTime);
        }
    }


    /*
    // 배소변 시간 계산 함수
    void PooPeeTimer()
    {
        // 현재 시간 저장
        nowTime = DateTime.Now;
        hh = nowTime.Hour;
        mm = nowTime.Minute;
        ss = nowTime.Second;

        // 대소변 발생
        // 7, 10, 13, 16, 19시 -> 대변
        // 8, 11, 14, 17, 20시 -> 소변
        if ((mm == 25 || mm==26) && (ss == 0))
        {
            switch (hh)
            {
                case 12:
                case 10:
                case 13:
                case 16:
                case 19:
                    Instantiate(poo1, transform.position, transform.rotation);
                    break;
                case 8:
                case 11:
                case 14:
                case 17:
                case 20:
                    Instantiate(pee1, transform.position, transform.rotation);
                    break;
                default:
                    break;
            }
        }
   
    } */
}
