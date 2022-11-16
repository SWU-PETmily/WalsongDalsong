using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class TissueController : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public static Vector2 defaultposition;

    bool left = true;
    int touchNum = 0;       // 드래그 횟수 카운트
    int totalNum = 5;       // 드래그 총 횟수 

    public GameObject water;
    public GameObject stain;
    public GameObject tissueBox;
    public GameObject btnBack;

    public GameObject bgBlack;     // 검정배경
    public GameObject particle;     // 파티클
    public GameObject txtDone;     // 완료 텍스트이미지

    AudioSource audioSource;                                        //오디오소스
    public AudioClip audioErase;                            //닦는 소리 오디오 클립

    Vector3 destination = new Vector3(3500, 900, 0);         // 사료봉투 이동 위치

    void Start()
    {
        audioSource = this.gameObject.GetComponent<AudioSource>();   //오디오소스
    }

    void Update()
    {
        // 충돌 판정
        Vector3 t1 = transform.position;                // 티슈 중심 좌표

        // 왼쪽에 닿으면
        if(t1.x <= 1200.0f && (t1.y >= 476.0f || t1.y <= 1000.0f) && left==true)
        {
            audioSource.clip = audioErase;
            this.audioSource.Play();                                    //오디오 실행
            left = false;
            touchNum++;
        }

        // 오른쪽에 닿으면
        if (t1.x >= 1800.0f && (t1.y >= 476.0f || t1.y <= 1000.0f) && left == false)
        {
            left = true;
            touchNum++;
        }

        if(touchNum >= totalNum)
        {
            // 게임오브젝트 삭제
            //Destroy(gameObject);
            this.transform.position = destination;
            Destroy(water);
            Destroy(stain);
            Destroy(tissueBox);
            Destroy(btnBack);

            // 성공 파티클
            bgBlack.SetActive(true);
            txtDone.SetActive(true);
            particle.SetActive(true);

            // 하루 배변 치우기 횟수 증가
            int num = PlayerPrefs.GetInt("pooCleaningNum")+1;
            PlayerPrefs.SetInt("pooCleaningNum", num);
            // 미션 성공 알림
            PlayerPrefs.SetInt("successPooPeeClean", 1);

            // 씬 전환
            Invoke("ChangeScene", 5.0f);           // 장면 전환
        }

    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        defaultposition = this.transform.position;
        stain.SetActive(true);      // 얼룩 보이기
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

    // 장면 전환
    void ChangeScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Room1Scene");
    }


}
