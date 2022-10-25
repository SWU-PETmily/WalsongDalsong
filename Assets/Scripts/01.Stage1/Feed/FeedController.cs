using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FeedController : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public static Vector2 defaultposition;
    public Sprite closeBag;
    public Sprite openBag;
    private Animator FeedingAnimator;
    Vector3 destination = new Vector3(1000, 900, 0);         // 사료봉투 이동 위치
    Vector3 rotationStop = new Vector3(0, 0, 0);         // 0도
    Vector3 rotationMove = new Vector3(0, 0, -40);         // 40도

    bool isCollision = false;

    void Start()
    {
        FeedingAnimator = GetComponent<Animator>();
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

    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("bowl"))
        {
            Debug.Log("collision!!!");
            isCollision = true;
            FeedingAnimator.SetBool("isFeed", true);
            //waterup.SetActive(true);
        }
    }
    

}
