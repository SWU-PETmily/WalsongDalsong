using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Room2BtnManager : MonoBehaviour
{
    int exeTime;              // ������ �ð�
    int feedNum;              // �Ļ� Ƚ��

    // ��ư Ŭ�� �̺�Ʈ
    public void BtnClick()
    {
        string name = EventSystem.current.currentSelectedGameObject.name;

        switch (name)
        {
            // �����ֱ�
            case "btn_feed":
                // 07~12��, 18~22�ÿ��� �Ļ� �޼� ����
                if (ExeDateCheck())
                {
                    UnityEngine.SceneManagement.SceneManager.LoadScene("Feed2Scene");
                }
                else
                {
                    UnityEngine.SceneManagement.SceneManager.LoadScene("FeedNoScene");
                }
                break;
            // �躯�е�
            case "btn_pad":
                UnityEngine.SceneManagement.SceneManager.LoadScene("Toilet1Scene");
                break;
            // ����
            case "btn_harness":
                UnityEngine.SceneManagement.SceneManager.LoadScene("Door2Scene");
                break;
            // ���ٵ��
            case "btn_touch":
                UnityEngine.SceneManagement.SceneManager.LoadScene("Touch1Scene");
                break;
            // ����
            case "btn_save":
                GameSave();
                break;
            // Ÿ��Ʋȭ��
            case "btn_home":
                //SceneManager.LoadScene("Door1Scene");
                break;
            default:
                break;
        }
    }

    // �ð� üũ & �Ļ� Ƚ�� üũ
    private bool ExeDateCheck()
    {
        exeTime = int.Parse(System.DateTime.Now.ToString("HH"));
        feedNum = PlayerPrefs.GetInt("feedNum");

        // 07~12��, 18~22�ÿ��� 1ȸ�� �Ļ� �޼� ����
        if (exeTime >= 07 && exeTime < 12 && feedNum == 0)
        {
            // 07~12��
            return true;
        }
        else if (exeTime >= 18 && exeTime < 22 && (feedNum == 0 || feedNum == 1))
        {
            // 18~22��
            if (feedNum == 0)
            {
                PlayerPrefs.SetInt("feedNum", 1);
            }
            return true;
        }
        return false;
    }

    // ���� ����
    public void GameSave()
    {
        // �������
        // �Ļ�/�躯/��å ����
    }

    // ���� �ε�
    public void GameLoad()
    {

    }
}
