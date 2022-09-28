using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class RoomBtnManager : MonoBehaviour
{
    // 버튼 클릭 이벤트
    public void BtnClick()
    {
        string name = EventSystem.current.currentSelectedGameObject.name;

        switch (name)
        {
            // 먹이주기
            case "btn_feed":
                UnityEngine.SceneManagement.SceneManager.LoadScene("FeedingScene");
                break;
            // 배변패드
            case "btn_pad":
                UnityEngine.SceneManagement.SceneManager.LoadScene("Toilet1Scene");
                break;
            // 현관
            case "btn_harness":
                UnityEngine.SceneManagement.SceneManager.LoadScene("Door1Scene");
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

