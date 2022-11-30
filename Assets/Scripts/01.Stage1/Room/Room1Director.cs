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
        Debug.Log(PlayerPrefs.GetFloat("guage"));
        gauge.fillAmount = PlayerPrefs.GetFloat("guage");       // ���� ������ �̹��� ä���
        currentFill = PlayerPrefs.GetFloat("guage");            // ���� ������

        ExeDateCheck();       //���� ��¥�ð� üũ
        TimeSpans();
    }

    void Update()
    {
        controlGauge();     // ������ ����
 

        gauge.fillAmount = Mathf.Lerp(gauge.fillAmount, currentFill, Time.deltaTime);

        // �������� 100�� �����ϸ�
        if (gauge.fillAmount >= 1.0f)
        {
            //�������� ����� ���� �ʱ�ȭ
            ChangeStage();
            // ���� �ִϸ��̼� �����ֱ�
            UnityEngine.SceneManagement.SceneManager.LoadScene("ChangeStoW");
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

        // ��Һ� �Ϸ����� ��,
        if (PlayerPrefs.GetInt("successPooPeeClean") == 1)
        {
            PlayerPrefs.SetInt("successPooPeeClean", 0);             // �̼ǿϷ� �ʱ�ȭ
            int i = PlayerPrefs.GetInt("pooCleaningNum") + 1;      // ��Һ� Ƚ�� ��������
            PlayerPrefs.SetInt("pooCleaningNum", i);               // ��Һ� Ƚ�� �����ϱ�
        }

        // ���ٵ�⸦ �Ϸ����� ��,
        if (PlayerPrefs.GetInt("successTouch") == 1)
        {
            decreaseGaugeByTouch();
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

    // ���ٵ�� ������ �ϰ�
    void decreaseGaugeByTouch()
    {
        currentFill = gauge.fillAmount - 0.1f;           // ������ ä���
        float f = PlayerPrefs.GetFloat("guage") - 0.1f;  // �������� ��������
        PlayerPrefs.SetFloat("guage", f);                 // �������� �����ϱ�

        PlayerPrefs.SetInt("successTouch", 0);             // �̼ǿϷ� �ʱ�ȭ
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

    // ����� ���� �ʱ�ȭ
    void Ending1Reset()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetString("quitSceneName", "nothing");           // ���� ��
    }
}