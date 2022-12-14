using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class WalkPetController : MonoBehaviour
{
    Animator animator;
    public bool LeftMove = false;
    public bool RightMove = false;
    Vector3 moveVelocity = Vector3.zero;
    float moveSpeed = 4;    // 버튼 누르는 동안의 오브젝트 속도

    bool wasLeft = true;

    // 성공 오브젝트
    public GameObject btnBack;     // 뒤로가기 버튼
    public GameObject btnRight;     // 오른쪽 버튼
    public GameObject btnLeft;     // 왼쪽 버튼
    public GameObject bgBlack;     // 검정배경
    public GameObject txtDone;     // 완료 텍스트이미지
    public GameObject snow;     // 눈 파티클
    public GameObject leftCollider;     // 왼쪽 배경 콜라이더
    public GameObject rightCollider;     // 오른쪽 배경 콜라이더
    bool isDone = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        bgBlack.SetActive(false);
        txtDone.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (LeftMove)
        {
            animator.SetInteger("Direction", 2);
            moveVelocity = new Vector3(-0.5f, 0, 0);
            transform.position += moveVelocity * moveSpeed * Time.deltaTime;
            wasLeft = true;
        }

        if (RightMove)
        {
            animator.SetInteger("Direction", 4);
            moveVelocity = new Vector3(+0.5f, 0, 0);
            transform.position += moveVelocity * moveSpeed * Time.deltaTime;
            wasLeft = false;
        }

        if(RightMove == false && LeftMove == false)
        {
            if (wasLeft)
            {
                animator.SetInteger("Direction", 1);
            }
            else
            {
                animator.SetInteger("Direction", 3);
            }
        }

        if (isDone)
        {
            if (this.transform.position.x > 0)
            {
                // 우측에 있었다면
                moveVelocity = new Vector3(1.0f, 0, 0);
                transform.position += moveVelocity * moveSpeed * Time.deltaTime;
            }
            else
            {
                // 좌측에 있었다면
                moveVelocity = new Vector3(-1.0f, 0, 0);
                transform.position += moveVelocity * moveSpeed * Time.deltaTime;
            }
        }
    }

    // 눈 강아지와 충돌 시
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("goal");
        btnLeft.SetActive(false);
        btnRight.SetActive(false);
        btnBack.SetActive(false);
        bgBlack.SetActive(true);
        txtDone.SetActive(true);
        snow.SetActive(false);
        leftCollider.SetActive(false);
        rightCollider.SetActive(false);
        isDone = true;
        PlayerPrefs.SetInt("successWalk", 1);     //  미션 성공
        Invoke("ChangeScene", 5.0f);           // 장면 전환
    }

    // 장면 전환
    void ChangeScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Room2Scene");
    }
}
