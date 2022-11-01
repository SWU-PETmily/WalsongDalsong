using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Door1TimeManager : MonoBehaviour
{
    public DateTime nowTime;
    public int hh;

    // ���� �ٲ� ��� ���
    public GameObject background;
    public GameObject pet;

    // �ٲ� �̹���
    public Sprite img_day_bg;
    public Sprite img_night_bg;

    // Start is called before the first frame update
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
        }
        else
        {
            // ���̶��
            this.background.GetComponent<SpriteRenderer>().sprite = this.img_night_bg;
        }

    }
}
