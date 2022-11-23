using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class WalkSceneManager : MonoBehaviour
{
    public DateTime nowTime;
    public int hh;
    public bool isDay;          // �� Ȯ�� ����

    // ���� �ٲ� ��� ���
    public GameObject background;
    public GameObject dayPet;
    public GameObject nightPet;

    // �ٲ� �̹���
    public Sprite img_day_bg;
    public Sprite img_night_bg;

    void Start()
    {
        ChangeDayNighte();          // ���� ����
    }

    // ���� ��� �̹��� ���� �Լ�
    public void ChangeDayNighte()
    {
        nowTime = DateTime.Now;
        hh = nowTime.Hour;

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
