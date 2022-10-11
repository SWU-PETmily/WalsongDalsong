using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

// ������ ���� && ���� ������ ���� �� ���� �ʱ�ȭ
public class Room1Director : MonoBehaviour
{
    public Image gauge;

    int quitDate;             // ������ ��¥
    int exeDate;              // ������ ��¥
    int quitTime;             // ������ �ð�
    int exeTime;              // ������ �ð�

    void Start()
    {
        Debug.Log(PlayerPrefs.GetFloat("guage"));
        gauge.fillAmount = PlayerPrefs.GetFloat("guage");

        ExeDateCheck();       //���� ��¥�ð� üũ
        TimeSpans();
    }

    void Update()
    {
        controlGauge();     // ������ ����
    }

    // ������ ����
    void controlGauge()
    {
        // �Ļ�޼� �Ϸ����� ��, �Ϸ� Ƚ���� 2 ���϶��
        if (PlayerPrefs.GetInt("successFeed") == 1 && PlayerPrefs.GetInt("feedNum") <= 2)
        {
            increaseGaugeByFeed();
        }
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
    }

    // �Ļ�޼� ������ ���
    void increaseGaugeByFeed()
    {
        this.gauge.GetComponent<Image>().fillAmount += 0.1f;
        PlayerPrefs.SetInt("successFeed", 0);                   // �̼ǿϷ� �ʱ�ȭ
        float f = PlayerPrefs.GetFloat("guage") + 0.1f;
        PlayerPrefs.SetFloat("guage", f);
    }

    // ��Һ� ������ ���
    void increaseGaugeByPooPee()
    {
        this.gauge.GetComponent<Image>().fillAmount += 0.05f;
        PlayerPrefs.SetInt("successPooPeeClean", 0);             // �̼ǿϷ� �ʱ�ȭ
        float f = PlayerPrefs.GetFloat("guage") + 0.1f;
        PlayerPrefs.SetFloat("guage", f);
    }

    // ����� ����
    private void OnApplicationQuit()
    {
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
            if ((dateSpan==1 && (exeTime > quitTime)) || dateSpan>=2)
            {
                // ���� 1 ����
                Debug.Log("���� 1�� �̵�.");
            }
            else
            {
                // ���� �θ� �򰡷� �̵�
                Debug.Log("���� �θ� �򰡷� �̵�.");
            }


        }
    }
}
