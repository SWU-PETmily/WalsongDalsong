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
    private Animator WateringAnimator;
    public Animator BowlWaterAnimatior;

    Vector3 destination = new Vector3(1800, 1000, 0);         // 물병 이동 위치

    bool isFeeding = false;             // 사료 완료 확인 변수
    bool isCollision = false;           // 충돌확인 변수

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (isFeeding)
        {
            // 사료 지급을 완료했다면
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

    }

    public void OnDrag(PointerEventData eventData)
    {
        if (isFeeding)
        {
            // 사료 지급을 완료했다면
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
       
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (isFeeding)
        {
            // 사료 지급을 완료했다면
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
    }

    // 밥 그릇과 충돌 시
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("bowl"))
        {
            Debug.Log("collision!!!");
            isCollision = true;
            WateringAnimator.SetBool("isWater", true);    // 물병 애니메이터 실행
            BowlWaterAnimatior.SetBool("isBowlWater", true);      // 물그릇 애니메이터 실행

            Invoke("ButtonActive", 4.0f);           // 버튼 활성화
            Destroy(gameObject, 4);                 // 물병 삭제
        }
    }

    // 강아지 버튼 활성화
    void ButtonActive()
    {
        btnDog.SetActive(true);
        PlayerPrefs.SetInt("feedLevel", 3);
    }

    // Start is called before the first frame update
    void Start()
    {
        WateringAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // 사료 지급과 그릇 치우기를 완료했다면
        if (PlayerPrefs.GetInt("feedLevel") == 2)
        {
            isFeeding = true;
        }
    }
}
