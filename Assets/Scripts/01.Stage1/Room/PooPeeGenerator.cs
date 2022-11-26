using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PooPeeGenerator : MonoBehaviour
{
    //public DateTime nowTime;
    int exeTime;                         // ������ �ð�
    float firstTime = 15.0f;            // ����ð�. 30�� ��
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
            StartCoroutine("PooRoutine");
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
}
