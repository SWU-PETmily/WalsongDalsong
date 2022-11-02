using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btnDogController : MonoBehaviour
{
    public GameObject bowlFeed;     // 사료그릇
    public GameObject bowlWater;     // 물그릇
    public GameObject btnDog;     // 강아지 버튼
    public GameObject btnBack;     // 뒤로가기 버튼
    public GameObject bgBlack;     // 검정배경
    public GameObject particle;     // 파티클


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
            particle.SetActive(true);

            PlayerPrefs.SetInt("feedLevel", 0);     // 식사 급수 내 단계 초기화. 0=아무것도 안 함. 1=식사지급완료, 2=식사 치우기. 3=물지급완료
            PlayerPrefs.SetInt("successFeed", 1);     // 식사 급수 미션 성공
            int num = PlayerPrefs.GetInt("feedNum") + 1; // 하루 배변 치우기 횟수 증가
            PlayerPrefs.SetInt("feedNum", num);

            Invoke("ChangeScene", 5.0f);           // 장면 전환
        }
    }

    // 장면 전환
    void ChangeScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Room1Scene");

    }

    public void btnBackClick()
    {
        PlayerPrefs.SetInt("feedLevel", 0);     // 식사 급수 내 단계 저장. 0=아무것도 안 함. 1=식사지급완료, 2=식사 치우기. 3=물지급완료
        PlayerPrefs.SetInt("successFeed", 0);     // 식사 급수 미션 실패
        UnityEngine.SceneManagement.SceneManager.LoadScene("Room1Scene");
    }
}
