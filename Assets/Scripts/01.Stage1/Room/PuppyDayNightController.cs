using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PuppyDayNightController : MonoBehaviour
{

    private Animator puppyDayWalk;
    public DateTime nowTime;
    public int hh;

    // Start is called before the first frame update
    void Start()
    {
        puppyDayWalk = GetComponent<Animator>();
        ChangeDayNighte();          // ���� ������ �̹��� ����
    }

    // ���� ��� �̹��� ���� �Լ�
    public void ChangeDayNighte()
    {
        nowTime = DateTime.Now;
        hh = nowTime.Hour;

        if (7 <= hh && hh < 19)

        {
            // ���̶��
            puppyDayWalk.SetTrigger("DayTrigger");    // �� ������ �ִϸ����� ����
        }
        else
        {
            // ���̶��
            puppyDayWalk.SetTrigger("NightTrigger");    // �� ������ �ִϸ����� ����
        }

    }
}
