using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuppyController : MonoBehaviour
{
    [SerializeField] Transform[] puppyPos;  // 강아지 위치
    [SerializeField] float speed = 0.5f;    // 속도
    int puppyNum = 0;   // 위치 순서

    public bool isDelay;
    public float delayTime = 5.0f;  //딜레이 시간

    // Start is called before the first frame update
    void Start()
    {
        transform.position = puppyPos[puppyNum].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();     // 움직이기

        if (isDelay == false)
        {
            isDelay = true;
            ChangePosition();       // 좌표 위치 바꾸기
            StartCoroutine(WaitForIt());    // 코루틴 실행
        }

    }

    // 강아지 위치 이동
    void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, puppyPos[puppyNum].transform.position, speed * Time.deltaTime);

    }

    // 강아지 목표 좌표 변경
    void ChangePosition()
    {

        if (transform.position == puppyPos[puppyNum].transform.position)
            puppyNum++;

        if (puppyNum == puppyPos.Length)
            puppyNum = 0;
    }

    // 대기 코루틴 선언
    IEnumerator WaitForIt()
    {
        yield return new WaitForSeconds(delayTime);
        isDelay = false;
    }
}
