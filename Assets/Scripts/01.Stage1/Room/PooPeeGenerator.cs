using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PooPeeGenerator : MonoBehaviour
{
    //public DateTime nowTime;
    int exeTime;                         // 실행한 시간
    float firstTime = 15.0f;            // 경과시간. 30초 후
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
            StartCoroutine("PooRoutine");
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
}
