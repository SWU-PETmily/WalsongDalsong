using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puppy2Controller : MonoBehaviour
{
    [SerializeField] Transform[] puppyPos;  // 강아지 위치
    [SerializeField] float speed = 0.5f;    // 속도
    int puppyNum = 0;   // 위치 순서

    public bool isDelay;
    public float delaySit = 5.0f;  // 딜레이 시간
    public float delayWalk = 7.0f;  // 딜레이 시간

    AudioSource audioSource;        // 오디오소스
    private Animator animator;      // 애니메이터

    bool isMove = false;            // 움직임 여부 저장 변수
    public GameObject posPoo;       // 배변 생성 위치
    public GameObject prefabPoo;         // 배소변 프리팹

    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = this.gameObject.GetComponent<AudioSource>();   //오디오소스
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
        this.audioSource.Play();              //오디오 실행
        animator.SetTrigger("SitTrigger");    // 이동 트리거
        yield return new WaitForSeconds(delaySit);              // 첫 시작 대기

        while (true)
        {
            // pos2-오른쪽으로 이동
            animator.ResetTrigger("SitTrigger");    // 이동 트리거
            animator.SetTrigger("RightTrigger");    // 이동 트리거
            ChangePosition();
            isMove = true;
            yield return new WaitForSeconds(4.5f);

            // pos3-오른쪽 아래로 이동
            animator.ResetTrigger("RightTrigger");
            animator.SetTrigger("RightDownTrigger");
            ChangePosition();
            yield return new WaitForSeconds(delayWalk);


            // pos4-오른쪽 위로 이동
            animator.ResetTrigger("RightDownTrigger");
            animator.SetTrigger("RightUpTrigger");
            ChangePosition();
            yield return new WaitForSeconds(5.0f);

            // 앉아있기 (배변 지점)
            isMove = false;
            Instantiate(prefabPoo, posPoo.transform.position, posPoo.transform.rotation);    // 배변 프리팹 생성
            this.audioSource.Play();              //오디오 실행
            animator.ResetTrigger("RightUpTrigger");
            animator.SetTrigger("SitTrigger");
            yield return new WaitForSeconds(delaySit);

            // pos5-왼쪽으로 이동
            animator.ResetTrigger("SitTrigger");
            animator.SetTrigger("LeftTrigger");
            ChangePosition();
            isMove = true;
            yield return new WaitForSeconds(18.0f);

            // pos6-왼쪽 아래로 이동
            animator.ResetTrigger("LeftTrigger");
            animator.SetTrigger("LeftDownTrigger");
            ChangePosition();
            yield return new WaitForSeconds(delayWalk);

            // pos7-왼쪽 위로 이동
            animator.ResetTrigger("LeftDownTrigger");
            animator.SetTrigger("LeftUpTrigger");
            ChangePosition();
            yield return new WaitForSeconds(6.0f);

            // pos8-오른쪽으로 이동
            animator.ResetTrigger("LeftUpTrigger");
            animator.SetTrigger("RightTrigger");
            ChangePosition();
            yield return new WaitForSeconds(14.0f);

            // 앉아있기
            isMove = false;
            this.audioSource.Play();              //오디오 실행
            animator.ResetTrigger("RightTrigger");
            animator.SetTrigger("SitTrigger");
            ChangePosition();
            yield return new WaitForSeconds(delaySit);
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
        puppyNum++;
        if (puppyNum == puppyPos.Length)
            puppyNum = 0;
        Debug.Log(puppyNum);
    }
}