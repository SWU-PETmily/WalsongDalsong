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
        petName = PlayerPrefs.GetString("name");
        dialogNum = 0;
        SettingNum();                   // 2�ܰ� ������ ���� ����
    }

    public void ChangeText()
    {
        dialogNum = dialogNum + 1;
        switch (dialogNum)
        {
            case 1:
                dialogText.text = petName + "(��)�� �츮 ���� �� �� 6������ �Ѿ���. �׵��� �װ� �� �����༭ �츮 ���� ������ �� �� �� ����.";
                break;
            case 2:
                dialogText.text = "ó���� �Ҿ��ߴ� ����� ã�ƺ� �� �����ϱ� ���� " + petName + "��(��) ������ �׾ƺ����� ����.";
                break;
            case 3:
                dialogText.text = "���� ���� " + petName + "(��)�� ��å�� ���� �� �ְ�, ���ٵ��� ���� �־�.";
                break;
            case 4:
                dialogText.text = "���� �������� �Ļ� ì���, ���ٵ��, ��å�ϱ⸦ ���� �ø� �� �־�. ��� �Ϸ翡 �� ������ �� ��� �Ѵܴ�.";
                break;
            case 5:
                dialogText.text = "�����ε� ��ó���� �� ���ָ� ��! ������ �װ� �� �س� �Ŷ�� �Ͼ�~";
                break;
            case 6:
                dialogBox.SetActive(false);
                UnityEngine.SceneManagement.SceneManager.LoadScene("Room2Scene");
                break;
            default:
                break;
        }
    }

    // 2�ܰ� ���� ����
    void SettingNum()
    {
        // ���� Ŭ���� Ƚ�� Ȯ�� �� ����                            
        PlayerPrefs.SetInt("stage", 2);                             // ��������
        PlayerPrefs.SetFloat("guage", 0.0f);                         // ������
        PlayerPrefs.SetString("quitSceneName", "Room2Scene");           // ���� ��

        // �̼� ���� ����
        PlayerPrefs.SetInt("successFeed", 0);                        // �Ļ�޼� �̼� ����=1, �̼� ����=0
        PlayerPrefs.SetInt("successPooPeeClean", 0);              // ��Һ� �̼� ����=1, �̼� ����=0
        PlayerPrefs.SetInt("successWalk", 0);                         // ��å �̼� ����=1, �̼� ����=0               

        // �θ� Ī�� ���� ����
        PlayerPrefs.SetInt("goodLevel", 0);                          // ���� �θ� Ī�� ����
        PlayerPrefs.SetInt("badLevel", 0);                           // ���� �θ� ��� ����              
            
    }
}
