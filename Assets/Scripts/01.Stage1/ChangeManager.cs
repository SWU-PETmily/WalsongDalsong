using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class ChangeManager : MonoBehaviour
{
    public void Change()
    {
        string name = EventSystem.current.currentSelectedGameObject.name;

        switch (name)
        {
            // 먹이주기
            case "btn_feed":
                SceneManager.LoadScene("FeedingScene");
                break;
            // 배변패드
            case "btn_pad":
                SceneManager.LoadScene("Toilet1Scene");
                break;
            // 현관
            case "btn_harness":
                SceneManager.LoadScene("Door1Scene");
                break;
            // 쓰다듬기
            case "btn_touch":
                SceneManager.LoadScene("Touch1Scene");
                break;
            // 저장
            case "btn_save":
                //SceneManager.LoadScene("Door1Scene");
                break;
            // 타이틀화면
            case "btn_home":
                //SceneManager.LoadScene("Door1Scene");
                break;
            default:
                break;
        }
    }
        
}
