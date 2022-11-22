using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Room2Tutorial : MonoBehaviour
{
    public Text dialogText;
    public GameObject dialogBox;
    public int dialogNum;
    string petName;

    void Start()
    {
        SettingNum();                   // 2단계 게이지 전부 세팅
        dialogNum = 0;
    }

    public void ChangeText()
    {
        petName = PlayerPrefs.GetString("name");
        dialogNum = dialogNum + 1;
        switch (dialogNum)
        {
            case 1:
                dialogText.text = petName + "(이)가 우리 집에 온 지 6개월이 넘었어. 그동안 네가 잘 돌봐줘서 우리 집에 적응을 잘 한 거 같아.";
                break;
            case 2:
                dialogText.text = "처음에 불안했던 모습은 찾아볼 수 없으니까 이젠 " + petName + "와(과) 믿음을 쌓아보도록 하자.";
                break;
            case 3:
                dialogText.text = "이제 드디어 " + petName + "(이)랑 산책을 나갈 수 있고, 터치하면 쓰다듬을 수도 있어.";
                break;
            case 4:
                dialogText.text = "믿음 게이지는 식사 챙기기, 쓰다듬기, 산책하기를 통해 올릴 수 있어. 모두 하루에 두 번씩은 해 줘야 한단다.";
                break;
            case 5:
                dialogText.text = "대소변 처리도 전과 마찬가지로 하루에 네 번은 꼭 해줘야 해. 게이지가 상승하지 않는다고 게을리 하면 안된단다.";
                break;
            case 6:
                dialogText.text = "앞으로도 전처럼만 잘 해주면 돼! 엄마는 네가 잘 해낼 거라고 믿어~";
                break;
            case 7:
                dialogBox.SetActive(false);
                UnityEngine.SceneManagement.SceneManager.LoadScene("Room2Scene");
                break;
            default:
                break;
        }
    }

    // 2단계 변수 세팅
    void SettingNum()
    {
        // 하루 미션 횟수 초기화(산책, 쓰다듬기만)
        //PlayerPrefs.SetInt("feedNum", 0);                             // 하루 먹이주기 횟수
        //PlayerPrefs.SetInt("pooCleaningNum", 0);                      // 하루 배변치우기  횟수
        PlayerPrefs.SetInt("touchingNum", 0);                         // 하루 쓰다듬기 횟수
        PlayerPrefs.SetInt("walkNum", 0);                             // 하루 산책 횟수

        // 게임 클리어 횟수 확인 및 저장                            
        PlayerPrefs.SetInt("stage", 2);                             // 스테이지
        PlayerPrefs.SetFloat("guage", 0.0f);                         // 게이지
        PlayerPrefs.SetString("quitSceneName", "Room2Scene");           // 종료 씬
        PlayerPrefs.SetInt("quitTime", -1);                         // 첫 날 종료 저장

        // 미션 성공 저장
        PlayerPrefs.SetInt("successFeed", 0);                        // 식사급수 미션 성공=1, 미션 실패=0
        PlayerPrefs.SetInt("successPooPeeClean", 0);              // 배소변 미션 성공=1, 미션 실패=0
        PlayerPrefs.SetInt("successWalk", 0);                         // 산책 미션 성공=1, 미션 실패=0
        PlayerPrefs.SetInt("successTouch", 0);                         // 쓰다듬기 성공 = 1, 미션 실패=0

        // 부모 칭찬 레벨 저장
        PlayerPrefs.SetInt("goodLevel", 1);                          // 가상 부모 칭찬 레벨
        PlayerPrefs.SetInt("badLevel", 1);                           // 가상 부모 경고 레벨              
            
    }
}
