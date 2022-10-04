using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PooController : MonoBehaviour
{

    GameObject trashCan;
    public GameObject spray;

    // 바꿀 이미지
    public Sprite img_garbage_open;
    public Sprite img_garbage;

    void Start()
    {
        this.trashCan = GameObject.Find("trashCan");
        spray.SetActive(false);
    }

    void Update()
    {
        // 충돌 판정
        Vector2 p1 = transform.position;                // 배변 중심 좌표
        Vector2 p2 = this.trashCan.transform.position;  // 쓰레기통 중심 좌표
        Vector2 dir = p1 - p2;
        float d = dir.magnitude;
        float r1 = 0.8f;                                // 배변 반경
        float r2 = 1.2f;                                // 쓰레기통 중심 반경


        if (d < r1 + r2 + 1.9f)
        {
            // 쓰레기통 열기
            this.trashCan.GetComponent<SpriteRenderer>().sprite = this.img_garbage_open;
        }
        else
        {
            // 쓰레기통 닫기
            this.trashCan.GetComponent<SpriteRenderer>().sprite = this.img_garbage;
        }

        if (d < r1 + r2)
        {
            // 충돌 시 배변 삭제
            Destroy(gameObject);
            this.trashCan.GetComponent<SpriteRenderer>().sprite = this.img_garbage;
            Destroy(this.trashCan.GetComponent<SpriteRenderer>());
            spray.SetActive(true);

        }

    }
}
