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
        if (!PlayerPrefs.HasKey("gameClearNumber"))
            PlayerPrefs.SetInt("gameClearNumber", 0);
        if (!PlayerPrefs.HasKey("guage"))
            PlayerPrefs.SetFloat("guage", 0.0f);
        if (!PlayerPrefs.HasKey("quitSceneName"))
            PlayerPrefs.SetString("quitSceneName", "nothing");

        Debug.Log(PlayerPrefs.GetInt("gameClearNumber"));
    }

    public void Change()
    {
        switch (PlayerPrefs.GetString("quitSceneName"))
        {
            case "nothing":
                UnityEngine.SceneManagement.SceneManager.LoadScene("MomWaitingTutorialScene");
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
                UnityEngine.SceneManagement.SceneManager.LoadScene("MomWaitingTutorialScene");
                break;
        }
        
    }
}
