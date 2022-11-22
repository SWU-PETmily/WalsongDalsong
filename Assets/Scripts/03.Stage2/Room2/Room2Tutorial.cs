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
        SettingNum();                   // 2�ܰ� ������ ���� ����
        dialogNum = 0;
    }

    public void ChangeText()
    {
        petName = PlayerPrefs.GetString("name");
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
                dialogText.text = "���� ���� " + petName + "(��)�� ��å�� ���� �� �ְ�, ��ġ�ϸ� ���ٵ��� ���� �־�.";
                break;
            case 4:
                dialogText.text = "���� �������� �Ļ� ì���, ���ٵ��, ��å�ϱ⸦ ���� �ø� �� �־�. ��� �Ϸ翡 �� ������ �� ��� �Ѵܴ�.";
                break;
            case 5:
                dialogText.text = "��Һ� ó���� ���� ���������� �Ϸ翡 �� ���� �� ����� ��. �������� ������� �ʴ´ٰ� ������ �ϸ� �ȵȴܴ�.";
                break;
            case 6:
                dialogText.text = "�����ε� ��ó���� �� ���ָ� ��! ������ �װ� �� �س� �Ŷ�� �Ͼ�~";
                break;
            case 7:
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
        // �Ϸ� �̼� Ƚ�� �ʱ�ȭ(��å, ���ٵ�⸸)
        //PlayerPrefs.SetInt("feedNum", 0);                             // �Ϸ� �����ֱ� Ƚ��
        //PlayerPrefs.SetInt("pooCleaningNum", 0);                      // �Ϸ� �躯ġ���  Ƚ��
        PlayerPrefs.SetInt("touchingNum", 0);                         // �Ϸ� ���ٵ�� Ƚ��
        PlayerPrefs.SetInt("walkNum", 0);                             // �Ϸ� ��å Ƚ��

        // ���� Ŭ���� Ƚ�� Ȯ�� �� ����                            
        PlayerPrefs.SetInt("stage", 2);                             // ��������
        PlayerPrefs.SetFloat("guage", 0.0f);                         // ������
        PlayerPrefs.SetString("quitSceneName", "Room2Scene");           // ���� ��
        PlayerPrefs.SetInt("quitTime", -1);                         // ù �� ���� ����

        // �̼� ���� ����
        PlayerPrefs.SetInt("successFeed", 0);                        // �Ļ�޼� �̼� ����=1, �̼� ����=0
        PlayerPrefs.SetInt("successPooPeeClean", 0);              // ��Һ� �̼� ����=1, �̼� ����=0
        PlayerPrefs.SetInt("successWalk", 0);                         // ��å �̼� ����=1, �̼� ����=0
        PlayerPrefs.SetInt("successTouch", 0);                         // ���ٵ�� ���� = 1, �̼� ����=0

        // �θ� Ī�� ���� ����
        PlayerPrefs.SetInt("goodLevel", 1);                          // ���� �θ� Ī�� ����
        PlayerPrefs.SetInt("badLevel", 1);                           // ���� �θ� ��� ����              
            
    }
}
