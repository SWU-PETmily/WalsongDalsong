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
        animator.SetTrigger("RightTrigger");    // 이동 트리거
        ChangePosition();
        isMove = true;
        yield return new WaitForSeconds(delayWalk);

        // 앉아있기
        isMove = false;
        animator.ResetTrigger("RightTrigger");    // 이동 트리거
        animator.SetTrigger("SitTrigger");    // 이동 트리거
        yield return new WaitForSeconds(delaySit);

        // pos3-오른쪽 아래로 이동
        animator.ResetTrigger("SitTrigger");    
        animator.SetTrigger("RightDownTrigger");
        ChangePosition();
        isMove = true;
        yield return new WaitForSeconds(delayWalk);

        // 앉아있기
        isMove = false;
        animator.ResetTrigger("RightDownTrigger");   
        animator.SetTrigger("SitTrigger"); 
        yield return new WaitForSeconds(delaySit);

        // pos4-오른쪽 위로 이동
        animator.ResetTrigger("SitTrigger");
        animator.SetTrigger("RightUpTrigger");
        ChangePosition();
        isMove = true;
        yield return new WaitForSeconds(delayWalk);

        // 앉아있기
        isMove = false;
        animator.ResetTrigger("RightUpTrigger");  
        animator.SetTrigger("SitTrigger");  
        yield return new WaitForSeconds(delaySit);

        // pos5-왼쪽으로 이동
        animator.ResetTrigger("SitTrigger");
        animator.SetTrigger("LeftTrigger");
        ChangePosition();
        isMove = true;
        yield return new WaitForSeconds(delayWalk);

        // 앉아있기
        isMove = false;
        animator.ResetTrigger("LeftTrigger");
        animator.SetTrigger("SitTrigger");
        yield return new WaitForSeconds(delaySit);

        // pos6-왼쪽으로 이동
        animator.ResetTrigger("SitTrigger");
        animator.SetTrigger("LeftTrigger");
        ChangePosition();
        isMove = true;
        yield return new WaitForSeconds(delayWalk);

        // 앉아있기
        isMove = false;
        animator.ResetTrigger("LeftTrigger");
        animator.SetTrigger("SitTrigger");
        yield return new WaitForSeconds(delaySit);

        // pos7-왼쪽으로 이동
        animator.ResetTrigger("SitTrigger");
        animator.SetTrigger("LeftTrigger");
        ChangePosition();
        isMove = true;
        yield return new WaitForSeconds(delayWalk);

        // 앉아있기
        isMove = false;
        animator.ResetTrigger("LeftTrigger");
        animator.SetTrigger("SitTrigger");
        yield return new WaitForSeconds(delaySit);

        // pos8-왼쪽 아래로 이동
        animator.ResetTrigger("SitTrigger");
        animator.SetTrigger("LeftDownTrigger");
        ChangePosition();
        isMove = true;
        yield return new WaitForSeconds(delayWalk);

        // 앉아있기
        isMove = false;
        animator.ResetTrigger("LeftDownTrigger");
        animator.SetTrigger("SitTrigger");
        yield return new WaitForSeconds(delaySit);

        // pos9-왼쪽 위로 이동
        animator.ResetTrigger("SitTrigger");
        animator.SetTrigger("LeftUpTrigger");
        ChangePosition();
        isMove = true;
        yield return new WaitForSeconds(delayWalk);

        // 앉아있기
        isMove = false;
        animator.ResetTrigger("LeftUpTrigger");
        animator.SetTrigger("SitTrigger");
        yield return new WaitForSeconds(delaySit);

        // pos10-오른쪽으로 이동
        animator.ResetTrigger("SitTrigger");
        animator.SetTrigger("RightTrigger");
        ChangePosition();
        isMove = true;
        yield return new WaitForSeconds(delayWalk);

        // 앉아있기
        isMove = false;
        animator.ResetTrigger("RightTrigger");
        animator.SetTrigger("SitTrigger");
        yield return new WaitForSeconds(delaySit);

        // pos11-오른쪽으로 이동
        animator.ResetTrigger("SitTrigger");
        animator.SetTrigger("RightTrigger");
        ChangePosition();
        isMove = true;
        yield return new WaitForSeconds(delayWalk);

        // 앉아있기
        isMove = false;
        animator.ResetTrigger("RightTrigger");
        animator.SetTrigger("SitTrigger");
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
        puppyNum++;
        if (puppyNum == puppyPos.Length)
            puppyNum = 0;
        Debug.Log(puppyNum);
    }

}
