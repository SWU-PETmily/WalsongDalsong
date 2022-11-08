using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PooPeeGenerator : MonoBehaviour
{
    //public DateTime nowTime;
    int exeTime;                         // ������ �ð�
    float firstTime = 30.0f;            // ����ð�. 30�� ��
    float waitTime = 60.0f;            // ����ð�. 60�� ��


    // ��Һ� ������
    public GameObject poo1;
    public GameObject poo2;
    public GameObject pee1;
    public GameObject pee2;

    // Start is called before the first frame update
    void Start()
    {
        // ������ �ð� ����
        exeTime = int.Parse(System.DateTime.Now.ToString("HHmm"));
        if (exeTime % 2 == 1)
        {
            // �躯 �ڷ�ƾ ����
            StartCoroutine("PooRoutine");
        }
        else
        {
            // �Һ� �ڷ�ƾ ����
            StartCoroutine("PeeRoutine");
        }
    
    }

    // ���� ���� �� 30�� �� ��Һ�
    IEnumerator PooRoutine()
    {
        yield return new WaitForSeconds(firstTime);              // ù ���� ���
        while (true)
        {
            Instantiate(poo1, transform.position, transform.rotation);          // ��ƾ ���
            yield return new WaitForSeconds(waitTime);
        }
    }

    // ���� ���� �� 30�� �� ��Һ�
    IEnumerator PeeRoutine()
    {
        yield return new WaitForSeconds(firstTime);              // ù ���� ���
        while (true)
        {
            Instantiate(pee1, transform.position, transform.rotation);          // ��ƾ ���
            yield return new WaitForSeconds(waitTime);
        }
    }


    /*
    // ��Һ� �ð� ��� �Լ�
    void PooPeeTimer()
    {
        // ���� �ð� ����
        nowTime = DateTime.Now;
        hh = nowTime.Hour;
        mm = nowTime.Minute;
        ss = nowTime.Second;

        // ��Һ� �߻�
        // 7, 10, 13, 16, 19�� -> �뺯
        // 8, 11, 14, 17, 20�� -> �Һ�
        if ((mm == 25 || mm==26) && (ss == 0))
        {
            switch (hh)
            {
                case 12:
                case 10:
                case 13:
                case 16:
                case 19:
                    Instantiate(poo1, transform.position, transform.rotation);
                    break;
                case 8:
                case 11:
                case 14:
                case 17:
                case 20:
                    Instantiate(pee1, transform.position, transform.rotation);
                    break;
                default:
                    break;
            }
        }
   
    } */
}
