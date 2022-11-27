using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Room2BtnManager : MonoBehaviour
{
    int exeTime;              // 실행한 시간
    int feedNum;              // 식사 횟수

    // 버튼 클릭 이벤트
    public void BtnClick()
    {
        string name = EventSystem.current.currentSelectedGameObject.name;

        switch (name)
        {
            // 먹이주기
            case "btn_feed":
                // 07~12시, 18~22시에만 식사 급수 가능
                if (ExeDateCheck())
                {
                    UnityEngine.SceneManagement.SceneManager.LoadScene("Feed2Scene");
                }
                else
                {
                    UnityEngine.SceneManagement.SceneManager.LoadScene("FeedNoScene");
                }
                break;
            // 배변패드
            case "btn_pad":
                UnityEngine.SceneManagement.SceneManager.LoadScene("Toilet1Scene");
                break;
            // 현관
            case "btn_harness":
                UnityEngine.SceneManagement.SceneManager.LoadScene("Door2Scene");
                break;
            // 쓰다듬기
            case "btn_touch":
                UnityEngine.SceneManagement.SceneManager.LoadScene("Touch1Scene");
                break;
            // 저장
            case "btn_save":
                GameSave();
                break;
            // 타이틀화면
            case "btn_home":
                //SceneManager.LoadScene("Door1Scene");
                break;
            default:
                break;
        }
    }

    // 시간 체크 & 식사 횟수 체크
    private bool ExeDateCheck()
    {
        exeTime = int.Parse(System.DateTime.Now.ToString("HH"));
        feedNum = PlayerPrefs.GetInt("feedNum");

        // 07~12시, 18~22시에만 1회씩 식사 급수 가능
        if (exeTime >= 07 && exeTime < 12 && feedNum == 0)
        {
            // 07~12시
            return true;
        }
        else if (exeTime >= 18 && exeTime < 22 && (feedNum == 0 || feedNum == 1))
        {
            // 18~22시
            if (feedNum == 0)
            {
                PlayerPrefs.SetInt("feedNum", 1);
            }
            return true;
        }
        return false;
    }

    // 게임 저장
    public void GameSave()
    {
        // 저장사항
        // 식사/배변/산책 여부
    }

    // 게임 로드
    public void GameLoad()
    {

    }
}
