using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{

    void Start()
    {
        //22.11.09 �ӽú���
        //PlayerPrefs.SetString("quitSceneName", "nothing");

        // ���� Ŭ���� Ƚ�� Ȯ�� �� ����
        if (!PlayerPrefs.HasKey("stage"))                               // ��������
            PlayerPrefs.SetInt("stage", 1);
        if (!PlayerPrefs.HasKey("gameClearNumber"))                     // ���� Ƚ��
            PlayerPrefs.SetInt("gameClearNumber", 0);
        if (!PlayerPrefs.HasKey("guage"))                               // ������
            PlayerPrefs.SetFloat("guage", 0.0f);
        if (!PlayerPrefs.HasKey("name"))                                // �������̸�
            PlayerPrefs.SetString("name", "");
        if (!PlayerPrefs.HasKey("quitSceneName"))                       // ���� ��
            PlayerPrefs.SetString("quitSceneName", "nothing");

        // �̼� Ƚ�� ����
        if (!PlayerPrefs.HasKey("feedNum"))                               // �Ϸ� �����ֱ� Ƚ��
            PlayerPrefs.SetInt("feedNum", 0);
        if (!PlayerPrefs.HasKey("pooCleaningNum"))                        // �Ϸ� �躯ġ��� Ƚ��
            PlayerPrefs.SetInt("pooCleaningNum", 0);
        if (!PlayerPrefs.HasKey("peeCleaningNum"))                        // �Ϸ� �Һ�ġ��� Ƚ��
            PlayerPrefs.SetInt("peeCleaningNum", 0);
        if (!PlayerPrefs.HasKey("touchingNum"))                           // �Ϸ� ���ٵ�� Ƚ��
            PlayerPrefs.SetInt("touchingNum", 0);
        if (!PlayerPrefs.HasKey("walkNum"))                               // �Ϸ� ��å Ƚ��
            PlayerPrefs.SetInt("walkNum", 0);

        // �̼� ���� ����
        if (!PlayerPrefs.HasKey("successFeed"))                         // �Ļ�޼� �̼� ����=1, �̼� ����=0
            PlayerPrefs.SetInt("successFeed", 0);
        if (!PlayerPrefs.HasKey("successPooPeeClean"))                  // ��Һ� �̼� ����=1, �̼� ����=0
            PlayerPrefs.SetInt("successPooPeeClean", 0);
        if (!PlayerPrefs.HasKey("successWalk"))                         // ��å �̼� ����=1, �̼� ����=0
            PlayerPrefs.SetInt("successWalk", 0);

        // �θ� Ī�� ���� ����
        if (!PlayerPrefs.HasKey("goodLevel"))                           // ���� �θ� Ī�� ����
            PlayerPrefs.SetInt("goodLevel", 0);
        if (!PlayerPrefs.HasKey("badLevel"))                            // ���� �θ� ��� ����
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
