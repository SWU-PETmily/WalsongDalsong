using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{

    void Start()
    {
        // 게임 클리어 횟수 확인 및 저장
        if (!PlayerPrefs.HasKey("gameClearNumber"))
            PlayerPrefs.SetInt("gameClearNumber", 0);
        if (!PlayerPrefs.HasKey("guage"))
            PlayerPrefs.SetFloat("guage", 0.0f);
        Debug.Log(PlayerPrefs.GetInt("gameClearNumber"));
    }

    public void Change()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MomWaitingTutorialScene");
    }
}
