using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PooPeeGenerator : MonoBehaviour
{

    public DateTime nowTime;
    public int hh;
    public int mm;
    public int ss;

    // ��Һ� ������
    public GameObject poo1;
    public GameObject poo2;
    public GameObject pee1;
    public GameObject pee2;

    // �ڷ�ƾ
    public bool isDelay;
    public float delayTime = 10.0f;
    public float accumTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        PooPeeTimer(); 

    }

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
        if (mm == 55 && ss == 0)
        {
            switch (hh)
            {
                case 4:
                case 10:
                case 13:
                case 16:
                case 19:
                    // �躯 �ڷ�ƾ ����
                    if (isDelay == false)
                    {
                        isDelay = true;
                        StartCoroutine(PooGenerator(hh));
                    }
                    break;
                case 8:
                case 11:
                case 14:
                case 17:
                case 20:
                    // �Һ� �ڷ�ƾ ����
                    if (isDelay == false)
                    {
                        isDelay = true;
                        StartCoroutine(PeeGenerator(hh));
                    }
                    break;
                default:
                    break;
            }
        }
    }

    // �躯 ���� �Լ�
    IEnumerator PooGenerator(int hour)
    {
        if (hour % 2 == 1)
        {
            // Ȧ��
            //GameObject newPoo = Instantiate(poo1, spawnPoint.position, Quaternion.identity) as GameObject;
            Instantiate(poo1, transform.position, transform.rotation);
        }
        else
        {
            // ¦��
            //GameObject newPoo = Instantiate(poo2, spawnPoint.position, Quaternion.identity) as GameObject;
            Instantiate(poo2, transform.position, transform.rotation);
        }
        yield return new WaitForSeconds(delayTime);
        isDelay = false;
    }

    // �Һ� ���� �Լ�
    IEnumerator PeeGenerator(int hour)
    {
        if (hour % 2 == 1)
        {
            // Ȧ��
            //GameObject newPee = Instantiate(pee1, spawnPoint.position, Quaternion.identity) as GameObject;
            Instantiate(pee1, transform.position, transform.rotation);
        }
        else
        {
            // ¦��
            //GameObject newPee = Instantiate(pee2, spawnPoint.position, Quaternion.identity) as GameObject;
            Instantiate(pee2, transform.position, transform.rotation);
        }
        yield return new WaitForSeconds(delayTime);
        isDelay = false;
    }
}
