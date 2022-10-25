using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class WaterController : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public GameObject btnDog;        // 강아지버튼
    public static Vector2 defaultposition;
    public Sprite closeWater;         // 닫은 물병 이미지
    public Sprite openWater;          // 열린 물병 이미지
    private Animator FeedingAnimator;
    public Animator BowlWaterAnimatior;

    Vector3 destination = new Vector3(518, 900, 0);         // 물병 이동 위치


    bool isCollision = false;           // 충돌확인 변수

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (isCollision)
        {
            // 충돌이 있었다면
            this.transform.position = destination;      // 물병 위치 고정
        }
        else
        {
            // 충돌이 없었다면
            defaultposition = this.transform.position;
            this.GetComponent<Image>().sprite = openWater;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (isCollision)
        {
            // 충돌이 있었다면
            this.transform.position = destination;      // 물병 위치 고정
        }
        else
        {
            // 충돌이 없었다면
            Vector2 currentPos = Input.mousePosition;
            this.transform.position = currentPos;
            this.GetComponent<Image>().sprite = openWater;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (isCollision)
        {
            // 충돌이 있었다면
            this.transform.position = destination;      // 물병 위치 고정
        }
        else
        {
            // 충돌이 없었다면
            this.transform.position = defaultposition;
            this.GetComponent<Image>().sprite = closeWater;
        }
    }

    // 밥 그릇과 충돌 시
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("bowl"))
        {
            Debug.Log("collision!!!");
            isCollision = true;
            //FeedingAnimator.SetBool("isWater", true);    // 사료봉투 애니메이터 실행
            //feed1.SetActive(true);      // 사료1 떨어지기
            //feed2.SetActive(true);      // 사료2 떨어지기
            //BowlAnimatior.SetBool("isBowlWater", true);      // 밥그릇 애니메이터 실행

            //Invoke("ButtonActive", 4.0f);           // 버튼 활성화
            //Destroy(gameObject, 4);                 // 사료 봉투 삭제
            //Destroy(feed1, 4);                      // 사료1 삭제
            //Destroy(feed2, 4);                      // 사료2 삭제
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
