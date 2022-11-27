using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialSkip : MonoBehaviour
{
    public void SkipBtnClick()
    {
        // 게임 클리어 횟수 확인 및 저장                            
        PlayerPrefs.SetInt("stage", 1);                          // 스테이지
        PlayerPrefs.SetFloat("guage", 0.2f);                     // 게이지
        PlayerPrefs.SetString("quitSceneName", "Room1Scene");    // 종료 씬
        PlayerPrefs.SetString("name", "쫑이");                   // 강아지 이름
        PlayerPrefs.SetInt("quitTime", -1);     // 처음 실행인 지 알기위한 변수 저장

        // 미션 횟수 저장
        PlayerPrefs.SetInt("feedNum", 0);                        // 하루 먹이주기 횟수
        PlayerPrefs.SetInt("pooCleaningNum", 0);                 // 하루 대변치우기 횟수
        PlayerPrefs.SetInt("peeCleaningNum", 0);                 // 하루 소변치우기 횟수  
        PlayerPrefs.SetInt("touchingNum", 0);                    // 하루 쓰다듬기 횟수 
        PlayerPrefs.SetInt("walkNum", 0);                        // 하루 산책 횟수

        // 미션 성공 저장
        PlayerPrefs.SetInt("successFeed", 0);                        // 식사급수 미션 성공=1, 미션 실패=0
        PlayerPrefs.SetInt("successPooPeeClean", 0);              // 배소변 미션 성공=1, 미션 실패=0
        PlayerPrefs.SetInt("successWalk", 0);                         // 산책 미션 성공=1, 미션 실패=0
        PlayerPrefs.SetInt("successTouch", 0);                         // 쓰다듬기 성공 = 1, 미션 실패=0

        // 식사급수 내 변수
        PlayerPrefs.SetInt("feedLevel", 0);                        // 0=아무것도 안 함. 1=식사지급완료, 2=식사 치우기. 3=물지급완료

        // 부모 칭찬 레벨 저장
        PlayerPrefs.SetInt("goodLevel", 1);                          // 가상 부모 칭찬 레벨
        PlayerPrefs.SetInt("badLevel", 1);                           // 가상 부모 경고 레벨      

        UnityEngine.SceneManagement.SceneManager.LoadScene("Room1Scene");
    }
}
