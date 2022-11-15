using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuppyNewController : MonoBehaviour
{
    [SerializeField] Transform[] puppyPos;  // 강아지 위치
    [SerializeField] float speed = 20.0f;    // 속도
    int puppyNum = 0;   // 위치 순서

    public bool isDelay;
    public float delaySit = 5.0f;  //딜레이 시간
    public float delayWalk = 7.0f;  //딜레이 시간


    private Animator animator;

    bool isMove = false;
    bool isChangePos = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(MoveStart());    // 코루틴 실행


    }

    void Update()
    {
        /*
        Move();     // 움직이기

        if (isDelay == false)
        {
            isDelay = true;
            ChangePosition();       // 좌표 위치 바꾸기
            StartCoroutine(WaitForIt());    // 코루틴 실행
        }
        */
        if(isChangePos == true)
        {
            ChangePosition();
            isChangePos = false;

        }
        if (isMove == true)
        {
            Move();
        }


    }

    // 게임 시작 후 30초 뒤 배소변
    IEnumerator MoveStart()
    {
        // 앉아있기
        animator.SetTrigger("SitTrigger");    // 이동 트리거
        yield return new WaitForSeconds(delaySit);              // 첫 시작 대기

        // pos2-오른쪽으로 이동
        animator.ResetTrigger("SitTrigger");    // 이동 트리거
        animator.SetTrigger("RightDayTrigger");    // 이동 트리거
        isChangePos = true;
        isMove = true;
        yield return new WaitForSeconds(delayWalk);

        // 앉아있기
        isMove = false;
        animator.ResetTrigger("RightDayTrigger");    // 이동 트리거
        animator.SetTrigger("SitTrigger");    // 이동 트리거
        yield return new WaitForSeconds(delaySit);

        // pos3-오른쪽 아래로 이동
        animator.ResetTrigger("SitTrigger");    
        animator.SetTrigger("RightDownDayTrigger");    
        isChangePos = true;
        isMove = true;
        yield return new WaitForSeconds(delayWalk);

        // 앉아있기
        isMove = false;
        animator.ResetTrigger("RightDownDayTrigger");    // 이동 트리거
        animator.SetTrigger("SitTrigger");    // 이동 트리거
        yield return new WaitForSeconds(delaySit);
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
        //animator.SetTrigger("RightDayTrigger");    // 이동 트리거
        Debug.Log("RightTrigger");
        yield return new WaitForSeconds(delayWalk);
        //animator.SetTrigger("SitTrigger");    // 이동 트리거
        Debug.Log("SitTrigger");
        isDelay = false;
    }

}
