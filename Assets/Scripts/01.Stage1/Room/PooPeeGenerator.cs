using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PooPeeGenerator : MonoBehaviour
{

    public DateTime nowTime;
    public int hh;
    public int mm;
    public int ss;

    // 배소변 프리팹
    public GameObject poo1;
    public GameObject poo2;
    public GameObject pee1;
    public GameObject pee2;

    // 코루틴
    public bool isDelay;
    public float delayTime = 3300.0f;   // 55분 동안 딜레이
    public float accumTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PooPeeTimer(); 
    }

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
        if (mm == 38 && ss == 0)
        {
            switch (hh)
            {
                case 23:
                case 10:
                case 13:
                case 16:
                case 19:
                    // 배변 코루틴 생성
                    if (isDelay == false)
                    {
                        isDelay = true;
                        StartCoroutine(PooGenerator(hh));
                    }
                    break;
                case 8:
                case 11:
                case 14:
                case 17:
                case 20:
                    // 소변 코루틴 생성
                    if (isDelay == false)
                    {
                        isDelay = true;
                        StartCoroutine(PeeGenerator(hh));
                    }
                    break;
                default:
                    break;
            }
        }
    }

    // 배변 생성 함수
    IEnumerator PooGenerator(int hour)
    {
        if (hour % 2 == 1)
        {
            // 홀수
           //  Instantiate(poo1, transform.position, transform.rotation);
            GameObject newPoo = Instantiate(poo1, transform.position, transform.rotation) as GameObject;
            newPoo.transform.SetParent(GameObject.FindGameObjectWithTag("PooPee").transform, false);
        }
        else
        {
            // 짝수
            //Instantiate(poo1, transform.position, transform.rotation);
            GameObject newPoo = Instantiate(poo1, transform.position, transform.rotation) as GameObject;
            newPoo.transform.SetParent(GameObject.FindGameObjectWithTag("PooPee").transform, false);
        }
        yield return new WaitForSecondsRealtime(delayTime);     //Time.timeScale 영향 받지 않는 절대적인 시간
        isDelay = false;
    }

    // 소변 생성 함수
    IEnumerator PeeGenerator(int hour)
    {
        if (hour % 2 == 1)
        {
            // 홀수
            Instantiate(pee1, transform.position, transform.rotation);
        }
        else
        {
            // 짝수
            Instantiate(pee2, transform.position, transform.rotation);
        }
        yield return new WaitForSecondsRealtime(delayTime);
        isDelay = false;
    }
}
