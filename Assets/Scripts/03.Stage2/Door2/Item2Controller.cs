using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Item2Controller : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public static Vector2 defaultposition;
    public GameObject pet;               // 강아지
    public Sprite imgDaySnell;           // 강아지 목줄 낮
    public Sprite imgNightSnell;         // 강아지 목줄 밤

    public bool isDay;                    // 낮밤 확인 변수
    public bool isSnell = false;          // 목줄 확인 변수
    public bool isBag = false;          // 배변 봉투 확인 변수

    public void OnBeginDrag(PointerEventData eventData)
    {
        defaultposition = this.transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 currentPos = Input.mousePosition;
        this.transform.position = currentPos;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        this.transform.position = defaultposition;
    }

    // 강아지와 충돌 시
    void OnTriggerEnter2D(Collider2D other)
    {
        // 현재 오브젝트가 목줄이라면
        if (this.CompareTag("snell"))
        {
            // 부딪힌 객체가 강아지라면
            if (other.CompareTag("pet"))
            {
                Debug.Log("목줄과 강아지 부딪힘");
                // 낮밤 확인 후 이미지 변경
                Door2TimeManager door2TimeManager = GameObject.Find("TimeManager").GetComponent<Door2TimeManager>();
                isDay = door2TimeManager.isDay;

                // 낮이라면
                if (isDay == true)
                {
                    pet.GetComponent<Image>().sprite = imgDaySnell;       // 강아지 이미지 변경

                }
                // 밤이라면
                else
                {
                    pet.GetComponent<Image>().sprite = imgNightSnell;       // 강아지 이미지 변경
                }
                gameObject.SetActive(false);                     // 아이템 삭제
                isSnell = true;                         // 목줄 확인
            }
        }
        // 현재 오브젝트가 배변 봉투라면
        else
        {
            // 부딪힌 객체가 강아지라면
            if (other.CompareTag("pet"))
            {
                Debug.Log("배변봉투와 강아지 부딪힘");
                gameObject.SetActive(false);                      // 아이템 삭제
                isBag = true;                         // 배변 봉투 확인
            }
        }
        
    }
}
