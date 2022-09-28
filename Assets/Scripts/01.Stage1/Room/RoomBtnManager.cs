using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class RoomBtnManager : MonoBehaviour
{
    // ��ư Ŭ�� �̺�Ʈ
    public void BtnClick()
    {
        string name = EventSystem.current.currentSelectedGameObject.name;

        switch (name)
        {
            // �����ֱ�
            case "btn_feed":
                UnityEngine.SceneManagement.SceneManager.LoadScene("FeedingScene");
                break;
            // �躯�е�
            case "btn_pad":
                UnityEngine.SceneManagement.SceneManager.LoadScene("Toilet1Scene");
                break;
            // ����
            case "btn_harness":
                UnityEngine.SceneManagement.SceneManager.LoadScene("Door1Scene");
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

