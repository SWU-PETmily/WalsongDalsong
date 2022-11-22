using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemController : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public static Vector2 defaultposition;
    public bool isCollision = false;           // 충돌확인 변수
    public Animator petAnimator;
    public bool isDay;

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
        if (other.CompareTag("pet"))
        {
            Debug.Log("collision");
            //this.audioSource.Play();                                    //오디오 실행
            isCollision = true;
            // 낮밤 확인 후 애니메이션 변경
            Door1TimeManager timeManager = GameObject.Find("TimeManager").GetComponent<Door1TimeManager>();
            isDay = timeManager.isDay;
            if (isDay)
            {
                Destroy(gameObject);
                petAnimator.SetTrigger("isDaySnell");    // 낮 목줄 애니메이션 실행
            }
            else
            {
                Destroy(gameObject);
                petAnimator.SetTrigger("iNightSnell");    // 밤 목줄 애니메이션 실행
            }
            
        }
    }
}
