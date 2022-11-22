using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btnDogController : MonoBehaviour
{
    public GameObject bg;              // 배경
    public Sprite imgDayBg;         // 낮 배경 이미지
    public Sprite imgNightBg;          // 밤 배경 이미지
    public bool isDay = true;          // 낮 확인 변수
    public GameObject bowlFeed;     // 사료그릇
    public GameObject bowlWater;     // 물그릇
    public GameObject btnDog;     // 강아지 버튼
    public GameObject btnBack;     // 뒤로가기 버튼
    public GameObject bgBlack;     // 검정배경
    public GameObject txtDone;     // 완료 텍스트이미지
    public Sprite imgShadowN;         // 배경 그림자 없는 이미지(그릇)

    public void btnDogClick()
    {
        if (PlayerPrefs.GetInt("feedLevel") == 1)
        {
            bowlFeed.SetActive(false);
            bowlWater.SetActive(true);
            btnDog.SetActive(false);
            PlayerPrefs.SetInt("feedLevel", 2);         // 식사 급수 내 단계 저장. 0=아무것도 안 함. 1=식사지급완료, 2=식사 치우기. 3=물지급완료

        }
        else if (PlayerPrefs.GetInt("feedLevel") == 3)
        {
            bowlWater.SetActive(false);
            btnDog.SetActive(false);
            btnBack.SetActive(false);
            bgBlack.SetActive(true);
            txtDone.SetActive(true);
         
            // 낮밤 확인 후 배경 변경
            FeedSceneManager feedSceneManager = GameObject.Find("SceneManager").GetComponent<FeedSceneManager>();
            isDay = feedSceneManager.isDay;
            if (isDay == true)
            {
                bg.GetComponent<SpriteRenderer>().sprite = imgDayBg;         // 배경 그림자 생기기 - 낮
            }
            else
            {
                bg.GetComponent<SpriteRenderer>().sprite = imgNightBg;         // 배경 그림자 생기기 - 밤
            }

            PlayerPrefs.SetInt("feedLevel", 0);     // 식사 급수 내 단계 초기화. 0=아무것도 안 함. 1=식사지급완료, 2=식사 치우기. 3=물지급완료
            PlayerPrefs.SetInt("successFeed", 1);     // 식사 급수 미션 성공

            Invoke("ChangeScene", 5.0f);           // 장면 전환
        }
    }

    // 장면 전환
    void ChangeScene()
    {

        // 스테이지 2라면
        if (PlayerPrefs.GetInt("stage") == 2)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Room2Scene");
        }
        else
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Room1Scene");

        }
    }

    public void btnBackClick()
    {
        PlayerPrefs.SetInt("feedLevel", 0);     // 식사 급수 내 단계 저장. 0=아무것도 안 함. 1=식사지급완료, 2=식사 치우기. 3=물지급완료
        PlayerPrefs.SetInt("successFeed", 0);     // 식사 급수 미션 실패
        // 스테이지 2라면
        if (PlayerPrefs.GetInt("stage") == 2)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Room2Scene");
        }
        else
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Room1Scene");

        }
    }
}
