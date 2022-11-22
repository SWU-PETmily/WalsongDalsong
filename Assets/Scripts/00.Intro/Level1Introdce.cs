using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level1Introdce : MonoBehaviour
{
    public Text dialogText;
    public GameObject dialogBox;
    public int dialogNum;

    void Start()
    {
        dialogNum = 0;
        SettingNum();                   // 1�ܰ� ������ ���� ����
    }

    public void ChangeText()
    {
        dialogNum = dialogNum + 1;
        switch (dialogNum)
        {
            case 1:
                dialogText.text = "�Ϸ翡 �� �ֱ� 2ȸ, ��Һ� ó�� 4ȸ�� �Ϸ��ؾ� �� �� �� ���� ��� �Ѱž�.";
                break;
            case 2:
                dialogText.text = "���� �ָ� ���밨 �������� ��½�ų �� �־�. ��Һ� ó���� �� ����� ������ �װɷ� �������� ������ �ʾ�.";
                break;
            case 3:
                dialogText.text = "�������� ������ �ʴ´ٰ� ��Һ� ó���� ��Ȧ�� �ؼ� �ȵ�.";
                break;
            case 4:
                dialogText.text = "���� ��ħ, ���ῡ �ָ� �ǰ� �������� ��Һ��� ���� �׶� ġ���ָ� ��.";
                break;
            case 5:
                dialogText.text = "������ �ʰ� �������� �� ���� �� �Ŷ� �Ͼ�.";
                break;
            case 6:
                dialogBox.SetActive(false);
                PlayerPrefs.SetInt("quitTime", -1);     // ó�� ������ �� �˱����� ���� ����
                UnityEngine.SceneManagement.SceneManager.LoadScene("Room1Scene");
                break;
            default:
                break;
        }
    }

    // 1�ܰ� ���� ����
    void SettingNum()
    {
        // ���� Ŭ���� Ƚ�� Ȯ�� �� ����                            
        PlayerPrefs.SetInt("stage", 1);                             // ��������
        PlayerPrefs.SetFloat("guage", 0.2f);                         // ������
        PlayerPrefs.SetString("quitSceneName", "Room1Scene");           // ���� ��

        // �̼� Ƚ�� ����
        PlayerPrefs.SetInt("feedNum", 0);                        // �Ϸ� �����ֱ� Ƚ��
        PlayerPrefs.SetInt("pooCleaningNum", 0);                 // �Ϸ� �뺯ġ��� Ƚ��
        PlayerPrefs.SetInt("peeCleaningNum", 0);                 // �Ϸ� �Һ�ġ��� Ƚ��  
        PlayerPrefs.SetInt("touchingNum", 0);                    // �Ϸ� ���ٵ�� Ƚ�� 
        PlayerPrefs.SetInt("walkNum", 0);                        // �Ϸ� ��å Ƚ��

        // �̼� ���� ����
        PlayerPrefs.SetInt("successFeed", 0);                        // �Ļ�޼� �̼� ����=1, �̼� ����=0
        PlayerPrefs.SetInt("successPooPeeClean", 0);              // ��Һ� �̼� ����=1, �̼� ����=0
        PlayerPrefs.SetInt("successWalk", 0);                         // ��å �̼� ����=1, �̼� ����=0

        // �Ļ�޼� �� ����
        PlayerPrefs.SetInt("feedLevel", 0);                        // 0=�ƹ��͵� �� ��. 1=�Ļ����޿Ϸ�, 2=�Ļ� ġ���. 3=�����޿Ϸ�

        // �θ� Ī�� ���� ����
        PlayerPrefs.SetInt("goodLevel", 1);                          // ���� �θ� Ī�� ����
        PlayerPrefs.SetInt("badLevel", 1);                           // ���� �θ� ��� ����              

    }
}
