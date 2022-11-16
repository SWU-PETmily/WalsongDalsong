using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class WaterController : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public GameObject bg;           // 배경
    public GameObject btnDog;        // 강아지버튼
    public static Vector2 defaultposition;
    public Sprite closeWater;         // 닫은 물병 이미지
    public Sprite openWater;          // 열린 물병 이미지
    public Sprite imgDayShadowY;         // 배경 그림자 있는 낮 이미지(물)
    public Sprite imgDayShadowN;         // 배경 그림자 없는 낮 이미지(물)
    public Sprite imgNightShadowY;         // 배경 그림자 있는 밤 이미지(물)
    public Sprite imgNightShadowN;         // 배경 그림자 없는 밤 이미지(물)
    public bool isDay;
    private Animator WateringAnimator;
    public Animator BowlWaterAnimatior;
    AudioSource audioSource;                                        //오디오소스

    Vector3 destination = new Vector3(1800, 970, 0);         // 물병 이동 위치

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
                if (isDay == true)
                {
                    bg.GetComponent<SpriteRenderer>().sprite = imgDayShadowN;         // 배경 그림자 없애기 - 낮
                }
                else
                {
                    bg.GetComponent<SpriteRenderer>().sprite = imgNightShadowN;       // 배경 그림자 없애기 - 밤
                }
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
                if (isDay == true)
                {
                    bg.GetComponent<SpriteRenderer>().sprite = imgDayShadowN;         // 배경 그림자 없애기 - 낮
                }
                else
                {
                    bg.GetComponent<SpriteRenderer>().sprite = imgNightShadowN;       // 배경 그림자 없애기 - 밤
                }

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
                if (isDay == true)
                {
                    bg.GetComponent<SpriteRenderer>().sprite = imgDayShadowY;         // 배경 그림자 생기기 - 낮
                }
                else
                {
                    bg.GetComponent<SpriteRenderer>().sprite = imgNightShadowY;        // 배경 그림자 생기기 - 밤
                }
            }
        }
    }

    // 밥 그릇과 충돌 시
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("bowl"))
        {
            Debug.Log("collision!!!");
            this.audioSource.Play();                                    //오디오 실행
            isCollision = true;
            WateringAnimator.SetBool("isWater", true);    // 물병 애니메이터 실행
            BowlWaterAnimatior.SetBool("isBowlWater", true);      // 물그릇 애니메이터 실행  
            if (isDay == true)
            {
                bg.GetComponent<SpriteRenderer>().sprite = imgDayShadowN;         // 배경 그림자 없애기 - 낮
            }
            else
            {
                bg.GetComponent<SpriteRenderer>().sprite = imgNightShadowN;       // 배경 그림자 없애기 - 밤
            }
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
        audioSource = this.gameObject.GetComponent<AudioSource>();   //오디오소스
        WateringAnimator = GetComponent<Animator>();
        // 낮밤 확인 후 배경 변경
        FeedSceneManager feedSceneManager = GameObject.Find("SceneManager").GetComponent<FeedSceneManager>();
        isDay = feedSceneManager.isDay;
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
