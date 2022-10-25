using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FeedController : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public GameObject feed1;        // 사료알1
    public GameObject feed2;        // 사료알2
    public GameObject btnDog;        // 강아지버튼
    public GameObject bowlWater;     // 물그릇
    public static Vector2 defaultposition;
    public Sprite closeBag;         // 닫은 사료봉투 이미지
    public Sprite openBag;          // 열린 사료봉투 이미지
    private Animator FeedingAnimator;
    public Animator BowlAnimatior;
    Vector3 destination = new Vector3(1000, 900, 0);         // 사료봉투 이동 위치
    Vector3 rotationStop = new Vector3(0, 0, 0);         // 0도
    Vector3 rotationMove = new Vector3(0, 0, -40);         // 40도

    bool isCollision = false;           // 충돌확인 변수

    void Start()
    {
        FeedingAnimator = GetComponent<Animator>();
        feed1.SetActive(false);
        feed2.SetActive(false);
        btnDog.SetActive(false);
        bowlWater.SetActive(false);
        PlayerPrefs.SetInt("feedLevel", 0);     // 식사 급수 내 단계 저장. 0=아무것도 안 함. 1=식사지급완료, 2=물지급완료.
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (isCollision)
        {
            // 충돌이 있었다면
            this.transform.position = destination;      // 봉투 위치 고정
        }
        else
        {
            // 충돌이 없었다면
            defaultposition = this.transform.position;
            this.GetComponent<Image>().sprite = openBag;
            this.transform.localEulerAngles = rotationMove;     // 봉투 기울이기
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (isCollision)
        {
            // 충돌이 있었다면
            this.transform.position = destination;      // 봉투 위치 고정
        }
        else
        {
            // 충돌이 없었다면
            Vector2 currentPos = Input.mousePosition;
            this.transform.position = currentPos;
            this.GetComponent<Image>().sprite = openBag;
            this.transform.localEulerAngles = rotationMove;    // 봉투 기울이기
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (isCollision)
        {
            // 충돌이 있었다면
            this.transform.position = destination;      // 봉투 위치 고정
        }
        else
        {
            // 충돌이 없었다면
            this.transform.position = defaultposition;
            this.GetComponent<Image>().sprite = closeBag;
            this.transform.localEulerAngles = rotationStop;     // 봉투 바로 세우기
        }
    }

    // 밥 그릇과 충돌 시
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("bowl"))
        {
            Debug.Log("collision!!!");
            isCollision = true;
            FeedingAnimator.SetBool("isFeed", true);    // 사료봉투 애니메이터 실행
            feed1.SetActive(true);      // 사료1 떨어지기
            feed2.SetActive(true);      // 사료2 떨어지기
            BowlAnimatior.SetBool("isBowl", true);      // 밥그릇 애니메이터 실행

            Invoke("ButtonActive", 4.0f);           // 버튼 활성화
            Destroy(gameObject, 4);                 // 사료 봉투 삭제
            Destroy(feed1, 4);                      // 사료1 삭제
            Destroy(feed2, 4);                      // 사료2 삭제
        }
    }

    // 강아지 버튼 활성화
    void ButtonActive()
    {
        btnDog.SetActive(true);
        PlayerPrefs.SetInt("feedLevel", 1);
    }


}
