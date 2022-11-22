using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level1Introdce : MonoBehaviour
{
    public Text dialogText;
    public GameObject dialogBox;
    public int dialogNum;

    void Start()
    {
        dialogNum = 0;
        SettingNum();                   // 1단계 게이지 전부 세팅
    }

    public void ChangeText()
    {
        dialogNum = dialogNum + 1;
        switch (dialogNum)
        {
            case 1:
                dialogText.text = "하루에 밥 주기 2회, 대소변 처리 4회를 완료해야 그 날 할 일을 모두 한거야.";
                break;
            case 2:
                dialogText.text = "밥을 주면 유대감 게이지를 상승시킬 수 있어. 배소변 처리는 꼭 해줘야 하지만 그걸로 게이지가 오르지 않아.";
                break;
            case 3:
                dialogText.text = "게이지가 오르지 않는다고 배소변 처리를 소홀히 해선 안돼.";
                break;
            case 4:
                dialogText.text = "밥은 아침, 저녁에 주면 되고 강아지가 배소변을 누면 그때 치워주면 돼.";
                break;
            case 5:
                dialogText.text = "엄마는 너가 강아지를 잘 돌봐 줄 거라 믿어.";
                break;
            case 6:
                dialogBox.SetActive(false);
                PlayerPrefs.SetInt("quitTime", -1);     // 처음 실행인 지 알기위한 변수 저장
                UnityEngine.SceneManagement.SceneManager.LoadScene("Room1Scene");
                break;
            default:
                break;
        }
    }

    // 1단계 변수 세팅
    void SettingNum()
    {
        // 게임 클리어 횟수 확인 및 저장                            
        PlayerPrefs.SetInt("stage", 1);                             // 스테이지
        PlayerPrefs.SetFloat("guage", 0.2f);                         // 게이지
        PlayerPrefs.SetString("quitSceneName", "Room1Scene");           // 종료 씬

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

        // 식사급수 내 변수
        PlayerPrefs.SetInt("feedLevel", 0);                        // 0=아무것도 안 함. 1=식사지급완료, 2=식사 치우기. 3=물지급완료

        // 부모 칭찬 레벨 저장
        PlayerPrefs.SetInt("goodLevel", 1);                          // 가상 부모 칭찬 레벨
        PlayerPrefs.SetInt("badLevel", 1);                           // 가상 부모 경고 레벨              

    }
}
