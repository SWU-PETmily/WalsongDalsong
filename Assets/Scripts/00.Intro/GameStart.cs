using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{

    void Start()
    {
        // ���� Ŭ���� Ƚ�� Ȯ�� �� ����
        if (!PlayerPrefs.HasKey("gameClearNumber"))
            PlayerPrefs.SetInt("gameClearNumber", 0);
        Debug.Log(PlayerPrefs.GetInt("gameClearNumber"));
    }

    public void Change()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("CalmingSignal");
    }
}
