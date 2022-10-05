using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

// ������ ���� && ���� ������ ���� �� ���� �ʱ�ȭ
public class Room1Director : MonoBehaviour
{
    public GameObject gauge;

    public DateTime nowTime;

    void Start()
    {
        
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
    }

    // ��Һ� ������ ���
    void increaseGaugeByPooPee()
    {
        this.gauge.GetComponent<Image>().fillAmount += 0.05f;
        PlayerPrefs.SetInt("successPooPeeClean", 0);             // �̼ǿϷ� �ʱ�ȭ
    }
}
