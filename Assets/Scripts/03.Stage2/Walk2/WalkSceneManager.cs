using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class WalkSceneManager : MonoBehaviour
{
    public DateTime nowTime;
    public int hh;      // ��
    public int ss;      // ��
    public bool isDay;                   // �� Ȯ�� ����
    public GameObject snowman;           // ��������
    public GameObject posSnowman1;       // �������� ���� ��ġ1
    public GameObject posSnowman2;       // �������� ���� ��ġ2

    // ���� �ٲ� ��� ���
    public GameObject background;
    public GameObject dayPet;
    public GameObject nightPet;

    // �ٲ� �̹���
    public Sprite img_day_bg;
    public Sprite img_night_bg;

    void Start()
    {
        nowTime = DateTime.Now;
        CreateRandomSnownman();     // �� ������ ���� ��ġ ����
        ChangeDayNighte();          // ���� ����
    }

    // �������� ���� ��ġ ����
    public void CreateRandomSnownman()
    {
        ss = nowTime.Second;        // ���� ��
        if (ss % 2 == 0)
        {
            // ¦�� �ʶ��
            snowman.transform.position = posSnowman1.transform.position;      // ���ʿ� ��ġ
        }
        else
        {
            // Ȧ�� �ʶ��
            snowman.transform.position = posSnowman2.transform.position;      // �����ʿ� ��ġ
        }
    }

    // ���� ��� �̹��� ���� �Լ�
    public void ChangeDayNighte()
    {
        hh = nowTime.Hour;          // ���� �ð�

        if (7 <= hh && hh < 19)

        {
            // ���̶��
            this.background.GetComponent<SpriteRenderer>().sprite = this.img_day_bg;
            dayPet.SetActive(true);
            nightPet.SetActive(false);
            isDay = true;
        }
        else
        {
            // ���̶��
            this.background.GetComponent<SpriteRenderer>().sprite = this.img_night_bg;
            dayPet.SetActive(false);
            nightPet.SetActive(true);
            isDay = false;
        }

    }
}
