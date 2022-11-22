using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

// ������ ���� && ���� ������ ���� �� ����/����θ������ �̵�
public class Room1Director : MonoBehaviour
{
    public Image gauge;

    int quitDate;             // ������ ��¥
    int exeDate;              // ������ ��¥
    int quitTime;             // ������ �ð�
    int exeTime;              // ������ �ð�

    private float currentFill;           // ���� ������ 

    void Start()
    {
        // �ӽ� ����
        /*
        PlayerPrefs.SetInt("feedNum", 0);
        PlayerPrefs.SetInt("pooCleaningNum", 0);
        PlayerPrefs.SetInt("peeCleaningNum", 0);
        PlayerPrefs.SetFloat("guage", 0.1f);
        PlayerPrefs.SetInt("stage", 1);
        */

        Debug.Log(PlayerPrefs.GetFloat("guage"));
        gauge.fillAmount = PlayerPrefs.GetFloat("guage");       // ���� ������ �̹��� ä���
        currentFill = PlayerPrefs.GetFloat("guage");            // ���� ������

        ExeDateCheck();       //���� ��¥�ð� üũ
        TimeSpans();
    }

    void Update()
    {
        controlGauge();     // ������ ����
 
        if (gauge.fillAmount < currentFill)
        {
            gauge.fillAmount = Mathf.Lerp(gauge.fillAmount, currentFill, Time.deltaTime);
        }

        // �������� 100�� �����ϸ�
        if(gauge.fillAmount >= 1.0f)
        {
            //�������� ����� ���� �ʱ�ȭ
            ChangeStage();
            // ���� �ִϸ��̼� �����ֱ�
            UnityEngine.SceneManagement.SceneManager.LoadScene("SummerToWinterScene");
        }

    }

    // btn
    public void btn()
    {
        increaseGaugeByFeed();
    }


    // ������ ����
    void controlGauge()
    {
        // �Ļ�޼� �Ϸ����� ��, �Ϸ� Ƚ���� 2 ���϶��
        if (PlayerPrefs.GetInt("successFeed") == 1 && PlayerPrefs.GetInt("feedNum") <= 2)
        {
            increaseGaugeByFeed();
        }

        // ��Һ� �Ϸ����� ��,
        if (PlayerPrefs.GetInt("successPooPeeClean") == 1)
        {
            PlayerPrefs.SetInt("successPooPeeClean", 0);             // �̼ǿϷ� �ʱ�ȭ
            int i = PlayerPrefs.GetInt("pooCleaningNum") + 1;      // ��Һ� Ƚ�� ��������
            PlayerPrefs.SetInt("pooCleaningNum", i);               // ��Һ� Ƚ�� �����ϱ�
        }
    }

    // �Ļ�޼� ������ ���
    void increaseGaugeByFeed()
    {
        currentFill = gauge.fillAmount + 0.15f;           // ������ ä���
        float f = PlayerPrefs.GetFloat("guage") + 0.15f;  // �������� ��������
        PlayerPrefs.SetFloat("guage", f);                 // �������� �����ϱ�

        PlayerPrefs.SetInt("successFeed", 0);             // �̼ǿϷ� �ʱ�ȭ

        int i = PlayerPrefs.GetInt("feedNum") + 1;      // �Ļ�޼� Ƚ�� ��������
        PlayerPrefs.SetInt("feedNum", i);               // �Ļ�޼� Ƚ�� �����ϱ�
    }

   

    // ���� ��¥ �ð� üũ
    private void ExeDateCheck()
    {
        exeDate = int.Parse(System.DateTime.Now.ToString("yyyyMMdd"));
        exeTime = int.Parse(System.DateTime.Now.ToString("HHmm"));

        Debug.Log("���� ��¥ : " + exeDate);
        Debug.Log("���� �ð� : " + exeTime);
    }

    // �ð� ����
    private void TimeSpans()
    {
        quitDate = PlayerPrefs.GetInt("quitDate");
        quitTime = PlayerPrefs.GetInt("quitTime");
        int dateSpan = exeDate - quitDate;          // ��¥ ����

        // ù ������ �ƴ϶��
        if(quitTime != -1)
        {
            // ���� �ٲ���ٸ�
            if (quitDate != exeDate)
            {
                // 24�ð� �̻� ������ �ߴٸ�
                if ((dateSpan == 1 && (exeTime > quitTime)) || dateSpan >= 2)
                {
                    // ���� 1 ����
                    Ending1Reset();             // ����� ���� �ʱ�ȭ
                    UnityEngine.SceneManagement.SceneManager.LoadScene("ParentEnding1");
                }
                else
                {
                    // ���� �θ� �򰡷� �̵�
                    Debug.Log("���� �θ� �򰡷� �̵�.");
                    UnityEngine.SceneManagement.SceneManager.LoadScene("Parent1Scene");
                }
            }
        }
        
    }

    // �������� ����
    private void ChangeStage()
    {
        PlayerPrefs.SetInt("stage", 2);
        PlayerPrefs.SetString("quitSceneName", "Room2Tutorial");           // ���� ��
    }

    // ����1. ����� ���� �ʱ�ȭ
    void Ending1Reset()
    {
        // ���� Ŭ���� Ƚ�� Ȯ�� �� ����                            
        PlayerPrefs.SetInt("stage", 1);                             // ��������
        PlayerPrefs.SetFloat("guage", 0.0f);                         // ������
        PlayerPrefs.SetString("quitSceneName", "nothing");           // ���� ��

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

        PlayerPrefs.SetInt("quitTime", -1);                         // ó�� ������ �� �˱����� ���� ����

        // �θ� Ī�� ���� ����
        PlayerPrefs.SetInt("goodLevel", 1);                          // ���� �θ� Ī�� ����
        PlayerPrefs.SetInt("badLevel", 1);                           // ���� �θ� ��� ����         
    }
}