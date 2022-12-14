using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PadController : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public static Vector2 defaultposition;
    public GameObject trashCan;
    public GameObject padBox;
    AudioSource audioSource;                                        //오디오소스

    // 바꿀 이미지
    public Sprite img_garbage_open;
    public Sprite img_garbage;

    void Start()
    {
        padBox.SetActive(false);
        audioSource = this.gameObject.GetComponent<AudioSource>();   //오디오소스
    }

    void Update()
    {
        // 충돌 판정
        Vector2 p1 = transform.position;                // 배변 중심 좌표
        Vector2 p2 = trashCan.transform.position;  // 쓰레기통 중심 좌표
        Vector2 dir = p1 - p2;
        float d = dir.magnitude;
        float r1 = 1.0f;                                // 배변 반경
        float r2 = 1.2f;                                // 쓰레기통 중심 반경


        if (d < r1 + r2 + 500.0f)
        {
            // 쓰레기통 열기
            StartCoroutine(StartAudio());
            this.trashCan.GetComponent<Image>().sprite = this.img_garbage_open;
        }
        else
        {
            // 쓰레기통 닫기
            this.trashCan.GetComponent<Image>().sprite = this.img_garbage;
        }

        if (d < r1 + r2 + 170.0f)
        {
            // 충돌 시 패드 삭제
            this.audioSource.Play();                                    //오디오 실행
            Destroy(gameObject);
            this.trashCan.GetComponent<Image>().sprite = this.img_garbage;
            Destroy(this.trashCan.GetComponent<Image>());
            padBox.SetActive(true);
        }

    }

    IEnumerator StartAudio()
    {
        this.audioSource.Play();                                    //오디오 실행
        yield return new WaitForSeconds(3);
    }

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
}
