using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Item2Controller : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public static Vector2 defaultposition;

    public bool isSnell = false;          // 목줄 확인 변수
    public bool isClothes = false;        // 옷 확인 변수

    bool isCollision = false;           // 충돌확인 변수

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

        if (isCollision)
        {
            // 충돌이 있었다면
            this.transform.position = new Vector3(4000, 900, 0);
        }
        else
        {
            // 충돌이 없었다면
            this.transform.position = defaultposition;
        }
        
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
                Debug.Log("목줄 강아지 부딪힘");
                isCollision = true;                            // 아이템 숨기기
                isSnell = true;                         // 목줄 확인
            }
        }
        // 현재 오브젝트가 옷이라면
        else
        {
            // 부딪힌 객체가 강아지라면
            if (other.CompareTag("pet"))
            {
                Debug.Log("옷 강아지 부딪힘");
                isCollision = true;                             // 아이템 숨기기
                isClothes = true;                         // 배변 봉투 확인
            }
        }
        
    }



}
