using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class PuppyNewDayNight : MonoBehaviour
{
    public DateTime nowTime;
    public int hh;
    public GameObject dayPuppy;
    public GameObject nightPuppy;

    void Start()
    {
        ChangeDayNighte();          // ���� ������ ����
    }

    // ���� ��� �̹��� ���� �Լ�
    public void ChangeDayNighte()
    {
        nowTime = DateTime.Now;
        hh = nowTime.Hour;

        if (7 <= hh && hh < 19)

        {
            // ���̶��
            dayPuppy.SetActive(true);         // �� ������ ���̱�
            nightPuppy.SetActive(false);      // �� ������ �����
        }
        else
        {
            // ���̶��
            dayPuppy.SetActive(false);         // �� ������ �����
            nightPuppy.SetActive(true);        // �� ������ ���̱�
        }

    }
}
