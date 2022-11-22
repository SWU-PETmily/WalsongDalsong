using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class ParentFeedAdvice : MonoBehaviour
{
    public GameObject bg;           // ���
    public Sprite bgSummer;         // ���� ��� �̹���
    public Sprite bgWinter;         // �ܿ� ��� �̹���
    int stage = 0;                  // �ܰ� ���� ����

    void Start()
    {
        stage = PlayerPrefs.GetInt("stage");
        if (stage == 2)
        {
            // �ܿ�
            bg.GetComponent<SpriteRenderer>().sprite = bgWinter;
        }
        else
        {
            // ����
            bg.GetComponent<SpriteRenderer>().sprite = bgSummer;
        }
    }

    public void ClickBtn()
    {
        if (stage == 2)
        {
            // �ܿ�
            UnityEngine.SceneManagement.SceneManager.LoadScene("Room2Scene");
        }
        else
        {
            // ����
            UnityEngine.SceneManagement.SceneManager.LoadScene("Room1Scene");
        }

    }
}
