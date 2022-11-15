using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{

    void Start()
    {
        //22.11.09 임시변수
        //PlayerPrefs.SetString("quitSceneName", "nothing");

        // 게임 클리어 횟수 확인 및 저장
        if (!PlayerPrefs.HasKey("stage"))                               // 스테이지
            PlayerPrefs.SetInt("stage", 1);
        if (!PlayerPrefs.HasKey("gameClearNumber"))                     // 엔딩 횟수
            PlayerPrefs.SetInt("gameClearNumber", 0);
        if (!PlayerPrefs.HasKey("guage"))                               // 게이지
            PlayerPrefs.SetFloat("guage", 0.0f);
        if (!PlayerPrefs.HasKey("name"))                                // 강아지이름
            PlayerPrefs.SetString("name", "");
        if (!PlayerPrefs.HasKey("quitSceneName"))                       // 종료 씬
            PlayerPrefs.SetString("quitSceneName", "nothing");

        // 미션 횟수 저장
        if (!PlayerPrefs.HasKey("feedNum"))                               // 하루 먹이주기 횟수
            PlayerPrefs.SetInt("feedNum", 0);
        if (!PlayerPrefs.HasKey("pooCleaningNum"))                        // 하루 배변치우기 횟수
            PlayerPrefs.SetInt("pooCleaningNum", 0);
        if (!PlayerPrefs.HasKey("peeCleaningNum"))                        // 하루 소변치우기 횟수
            PlayerPrefs.SetInt("peeCleaningNum", 0);
        if (!PlayerPrefs.HasKey("touchingNum"))                           // 하루 쓰다듬기 횟수
            PlayerPrefs.SetInt("touchingNum", 0);
        if (!PlayerPrefs.HasKey("walkNum"))                               // 하루 산책 횟수
            PlayerPrefs.SetInt("walkNum", 0);

        // 미션 성공 저장
        if (!PlayerPrefs.HasKey("successFeed"))                         // 식사급수 미션 성공=1, 미션 실패=0
            PlayerPrefs.SetInt("successFeed", 0);
        if (!PlayerPrefs.HasKey("successPooPeeClean"))                  // 배소변 미션 성공=1, 미션 실패=0
            PlayerPrefs.SetInt("successPooPeeClean", 0);
        if (!PlayerPrefs.HasKey("successWalk"))                         // 산책 미션 성공=1, 미션 실패=0
            PlayerPrefs.SetInt("successWalk", 0);

        // 부모 칭찬 레벨 저장
        if (!PlayerPrefs.HasKey("goodLevel"))                           // 가상 부모 칭찬 레벨
            PlayerPrefs.SetInt("goodLevel", 0);
        if (!PlayerPrefs.HasKey("badLevel"))                            // 가상 부모 경고 레벨
            PlayerPrefs.SetInt("badLevel", 0);


        Debug.Log(PlayerPrefs.GetInt("gameClearNumber"));
    }

    public void Change()
    {
        switch (PlayerPrefs.GetString("quitSceneName"))
        {
            case "nothing":
                UnityEngine.SceneManagement.SceneManager.LoadScene("IntroVideo1");
                break;
            case "CalmingSignal":
                UnityEngine.SceneManagement.SceneManager.LoadScene("CalmingSignal");
                break;
            case "Room1Scene":
                UnityEngine.SceneManagement.SceneManager.LoadScene("Room1Scene");
                break;
            case "Room2Scene":
                UnityEngine.SceneManagement.SceneManager.LoadScene("Room2Scene");
                break;
            default:
                UnityEngine.SceneManagement.SceneManager.LoadScene("IntroVideo1");
                break;
        }
        
    }
}
