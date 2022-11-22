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
        Debug.Log(PlayerPrefs.GetFloat("guage"));
        gauge.fillAmount = PlayerPrefs.GetFloat("guage");       // ���� ������ �̹��� ä���
        currentFill = PlayerPrefs.GetFloat("guage");            // ���� ������

        ExeDateCheck();       //���� ��¥�ð� üũ
        TimeSpans();
    }

    void Update()
    {
        controlGauge();     // ������ ����
        Debug.Log( gauge.fillAmount);

        if (gauge.fillAmount < currentFill)
        {
            gauge.fillAmount = Mathf.Lerp(gauge.fillAmount, currentFill, Time.deltaTime);
        }

        // �������� 100�� �����ϸ�
        if (gauge.fillAmount >= 1.0f)
        {
            // ���� ����� Ȯ��
            int badLevel = PlayerPrefs.GetInt("badLevel");

            // ������ ���� �ʱ�ȭ
            EndingReset();               // ����� ���� �ʱ�ȭ

            // �� ���̶� ��� �޾Ҵٸ�
            if (badLevel >= 2)
            {
                // ���� ����
                UnityEngine.SceneManagement.SceneManager.LoadScene("Ending2");
            }
            // �� ���� ��� �� �޾Ҵٸ�
            else
            {
                // �� ����
                UnityEngine.SceneManagement.SceneManager.LoadScene("Ending3");
            }
        }
    }

    // btn
    public void btn()
    {
        currentFill = gauge.fillAmount + 0.15f;           // ������ ä���
        float f = PlayerPrefs.GetFloat("guage") + 0.15f;  // �������� ��������
        PlayerPrefs.SetFloat("guage", f);                 // �������� �����ϱ�
    }

    // ������ ����
    void controlGauge()
    {
        // �Ļ�޼� �Ϸ����� ��, �Ϸ� Ƚ���� 2 ���϶��
        if (PlayerPrefs.GetInt("successFeed") == 1 && PlayerPrefs.GetInt("feedNum") < 2)
        {
            increaseGaugeByFeed();
        }

        // ��å �Ϸ����� ��, �Ϸ� Ƚ���� 2 ���϶��
        if (PlayerPrefs.GetInt("successWalk") == 1 && PlayerPrefs.GetInt("walkNum") < 2)
        {
            increaseGaugeByWalk();
        }

        // ��Һ� �Ϸ����� ��,
        if (PlayerPrefs.GetInt("successPooPeeClean") == 1)
        {
            PlayerPrefs.SetInt("successPooPeeClean", 0);             // �̼ǿϷ� �ʱ�ȭ
            int i = PlayerPrefs.GetInt("pooCleaningNum") + 1;      // ��Һ� Ƚ�� ��������
            PlayerPrefs.SetInt("pooCleaningNum", i);               // ��Һ� Ƚ�� �����ϱ�
        }

        // ���ٵ�� �Ϸ����� ��, �Ϸ� Ƚ���� 2 ���϶��
        if (PlayerPrefs.GetInt("successTouch") == 1 && PlayerPrefs.GetInt("touchingNum") < 2)
        {
            increaseGaugeByTouch();
        }
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

    // ���ٵ�� ������ ���
    void increaseGaugeByTouch()
    {
        currentFill = gauge.fillAmount + 0.05f;           // ������ ä���
        float f = PlayerPrefs.GetFloat("guage") + 0.05f;  // �������� ��������
        PlayerPrefs.SetFloat("guage", f);                 // �������� �����ϱ�

        PlayerPrefs.SetInt("successTouch", 0);             // �̼ǿϷ� �ʱ�ȭ

        int i = PlayerPrefs.GetInt("touchingNum") + 1;      // ��å Ƚ�� ��������
        PlayerPrefs.SetInt("touchingNum", i);               // ��å Ƚ�� �����ϱ�
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
        if (quitTime != -1)
        {
            // ���� �ٲ���ٸ�
            if (quitDate != exeDate)
            {
                // 24�ð� �̻� ������ �ߴٸ�
                if ((dateSpan == 1 && (exeTime > quitTime)) || dateSpan >= 2)
                {
                    // ���� 1 ����
                    Debug.Log("���� 1�� �̵�.");
                    EndingReset();             // ����� ���� �ʱ�ȭ
                    UnityEngine.SceneManagement.SceneManager.LoadScene("ParentEnding1");
                }
                else
                {
                    // ��� 3ȸ �ʰ��ߴٸ�
                    int level = PlayerPrefs.GetInt("badLevel");
                    if(level == 4)
                    {
                        // ���� 2 ����
                        Debug.Log("���� 2�� �̵�.");
                        EndingReset();             // ����� ���� �ʱ�ȭ
                        UnityEngine.SceneManagement.SceneManager.LoadScene("Ending2");
                    }
                    else
                    {
                        // ���� �θ� �򰡷� �̵�
                        Debug.Log("���� �θ� �򰡷� �̵�.");
                        UnityEngine.SceneManagement.SceneManager.LoadScene("Parent2Scene");
                    }
                }
            }
        } 
    }

    // ����1. ����� ���� �ʱ�ȭ
    void EndingReset()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetString("quitSceneName", "nothing");           // ���� ��
       
    }
}
