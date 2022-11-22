using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TouchPetController : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Animator animator;              // 애니메이터
    int touchCount = 0;                     // 터치 횟수 저장 변수
    AudioSource audioSource;                //오디오소스
    public GameObject doneBg;                   // 완료 배경
    public GameObject doneTxt;              // 완료 텍스트

    void Start()
    {
        doneBg.SetActive(false);
        doneTxt.SetActive(false);
        animator = GetComponent<Animator>();                         // 애니메이터
        audioSource = this.gameObject.GetComponent<AudioSource>();   //오디오소스
    }

    void Update()
    {
        
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");
        this.audioSource.Play();                                    //오디오 실행
    }

    public void OnDrag(PointerEventData eventData)
    {
        animator.SetBool("isTouch", true);    // 터치 애니메이터 실행
        Debug.Log("OnDrag");
        touchCount = touchCount + 1;          // 드래그 횟수 추가
        if (touchCount >= 150)
        {
            // 미션 완료창 띄우기
            doneBg.SetActive(true);
            doneTxt.SetActive(true);
            // 미션 성공 알림
            PlayerPrefs.SetInt("successTouch", 1);
            // 거실로 이동
            Invoke("RetunRoom", 4.0f);         
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        animator.SetBool("isTouch", false);    // 터치 애니메이터 종료
        Debug.Log("OnEndDrag");
    }

    // 거실로 이동
    void RetunRoom()
    {
        // 거실로 이동
        UnityEngine.SceneManagement.SceneManager.LoadScene("Room2Scene");
    }
}
