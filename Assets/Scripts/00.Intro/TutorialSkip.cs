using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialSkip : MonoBehaviour
{
    public void SkipBtnClick()
    {
        // ���� Ŭ���� Ƚ�� Ȯ�� �� ����                            
        PlayerPrefs.SetInt("stage", 1);                          // ��������
        PlayerPrefs.SetFloat("guage", 0.2f);                     // ������
        PlayerPrefs.SetString("quitSceneName", "Room1Scene");    // ���� ��
        PlayerPrefs.SetString("name", "����");                   // ������ �̸�
        PlayerPrefs.SetInt("quitTime", -1);     // ó�� ������ �� �˱����� ���� ����

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
        PlayerPrefs.SetInt("successTouch", 0);                         // ���ٵ�� ���� = 1, �̼� ����=0

        // �Ļ�޼� �� ����
        PlayerPrefs.SetInt("feedLevel", 0);                        // 0=�ƹ��͵� �� ��. 1=�Ļ����޿Ϸ�, 2=�Ļ� ġ���. 3=�����޿Ϸ�

        // �θ� Ī�� ���� ����
        PlayerPrefs.SetInt("goodLevel", 1);                          // ���� �θ� Ī�� ����
        PlayerPrefs.SetInt("badLevel", 1);                           // ���� �θ� ��� ����      

        UnityEngine.SceneManagement.SceneManager.LoadScene("Room1Scene");
    }
}
