using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class Room2Director : MonoBehaviour
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
        PlayerPrefs.SetInt("stage", 2);
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
        if (gauge.fillAmount >= 1.0f)
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
        // ��å �Ϸ����� ��, �Ϸ� Ƚ���� 2 ���϶��
        else if (PlayerPrefs.GetInt("successWalk") == 1 && PlayerPrefs.GetInt("walkNum") <= 2)
        {
            increaseGaugeByWalk();
        }

        /*
        // �躯 �Ϸ����� ��, �Ϸ� Ƚ���� 5 ���϶��
        else if (PlayerPrefs.GetInt("successPooPeeClean") == 1 && PlayerPrefs.GetInt("pooCleaningNum") <= 5)
        {
            increaseGaugeByPooPee();
        }
        // �Һ� �Ϸ����� ��, �Ϸ� Ƚ���� 5 ���϶��
        else if (PlayerPrefs.GetInt("successPooPeeClean") == 1 && PlayerPrefs.GetInt("peeCleaningNum") <= 5)
        {
            increaseGaugeByPooPee();
        }
        */
    }

    // �Ļ�޼� ������ ���
    void increaseGaugeByFeed()
    {
        currentFill = gauge.fillAmount + 0.05f;           // ������ ä���
        float f = PlayerPrefs.GetFloat("guage") + 0.05f;  // �������� ��������
        PlayerPrefs.SetFloat("guage", f);                 // �������� �����ϱ�

        PlayerPrefs.SetInt("successFeed", 0);             // �̼ǿϷ� �ʱ�ȭ

        int i = PlayerPrefs.GetInt("feedNum") + 1;      // �Ļ�޼� Ƚ�� ��������
        PlayerPrefs.SetInt("feedNum", i);               // �Ļ�޼� Ƚ�� �����ϱ�
    }

    // ��å ������ ���
    void increaseGaugeByWalk()
    {
        currentFill = gauge.fillAmount + 0.05f;           // ������ ä���
        float f = PlayerPrefs.GetFloat("guage") + 0.05f;  // �������� ��������
        PlayerPrefs.SetFloat("guage", f);                 // �������� �����ϱ�

        PlayerPrefs.SetInt("successWalk", 0);             // �̼ǿϷ� �ʱ�ȭ

        int i = PlayerPrefs.GetInt("walkNum") + 1;      // ��å Ƚ�� ��������
        PlayerPrefs.SetInt("walkNum", i);               // ��å Ƚ�� �����ϱ�
    }

    // ����� ����
    private void OnApplicationPause()
    {
        PlayerPrefs.SetString("quitSceneName", "Room2Scene");   // ����� ����
        QuitDateCheck(); //���ᳯ¥�ð� üũ
    }

    // ���� ��¥ �ð� üũ
    private void QuitDateCheck()
    {
        quitDate = int.Parse(System.DateTime.Now.ToString("yyyyMMdd"));
        quitTime = int.Parse(System.DateTime.Now.ToString("HHmm"));

        Debug.Log("���� ��¥ : " + quitDate);
        Debug.Log("���� �ð� : " + quitTime);

        PlayerPrefs.SetInt("quitDate", quitDate);
        PlayerPrefs.SetInt("quitTime", quitTime);

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

        // ���� �ٲ���ٸ�
        if (quitDate != exeDate)
        {
            // 24�ð� �̻� ������ �ߴٸ�
            if ((dateSpan == 1 && (exeTime > quitTime)) || dateSpan >= 2)
            {
                // ���� 1 ����
                Debug.Log("���� 1�� �̵�.");
                UnityEngine.SceneManagement.SceneManager.LoadScene("Ending1");
            }
            else
            {
                // ���� �θ� �򰡷� �̵�
                Debug.Log("���� �θ� �򰡷� �̵�.");
                UnityEngine.SceneManagement.SceneManager.LoadScene("Parent1Scene");
            }
        }
    }

    // �������� ����
    private void ChangeStage()
    {
        PlayerPrefs.SetInt("stage", 2);
        Debug.Log(PlayerPrefs.GetInt("stage"));
        PlayerPrefs.SetInt("successFeed", 0);
        PlayerPrefs.SetInt("successPooPeeClean", 0);
        PlayerPrefs.SetFloat("guage", 0.0f);
        PlayerPrefs.SetInt("goodLevel", 0);
        PlayerPrefs.SetInt("badLevel", 0);
        PlayerPrefs.SetInt("feedLevel", 0);
    }
}
