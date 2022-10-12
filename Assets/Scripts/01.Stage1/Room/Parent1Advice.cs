using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Parent1Advice : MonoBehaviour
{
    public Text dialogText;
    public GameObject dialogBox;

    public int dialogNum;
    public bool good = true;
    public int level;

    void Start()
    {
        dialogNum = 0;

        // ���� �θ� Ī�� ���� ���ٸ�
        if (!PlayerPrefs.HasKey("goodLevel"))
            PlayerPrefs.SetInt("goodLevel", 1);
        // ���� �θ� ��� ���� ���ٸ�
        if (!PlayerPrefs.HasKey("badLevel"))
            PlayerPrefs.SetInt("badLevel", 1);

        GoodOrBad();    // Ī�� or ��� �з�
        showDialog();   // ù ��° ���� �����ֱ�    
        ResetNum();     // �Ϸ� ���� �ʱ�ȭ
    }

    // ��ư Ŭ�� �Լ�
    public void ClickBtn()
    {
        if (good == true)
        {
            if (level == 1)
            {
                Good1();
            }
            else
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("Room1Scene");
            }
        }
        else
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Room1Scene");
        }
    }

    public void Good1()
    {
        dialogNum = dialogNum + 1;
        switch (dialogNum)
        {
            case 1:
                dialogText.text = "�ؾ��� ���� ��� �������� ������ �ٰ�! �������� �ǻ� ���� ��ȣ�� �ľ��� �� �ִ� ī�ֽñ׳��� Ȯ���� �� �ִ� ī���.";
                break;
            case 2:
                dialogText.text = "������ �Ϸ� �� ���� ��� ������ ������ �� �徿 �ٰ�. �װ� �� ī��� �� �� OO�̸� ������ �� ������ ���ھ�.";
                break;
            case 3:
                UnityEngine.SceneManagement.SceneManager.LoadScene("Room1Scene");
                break;
            default:
                break;
        }


    }

    // Ī�� or ��� �з�
    public void GoodOrBad()
    {
        int feedNum = PlayerPrefs.GetInt("feedNum");
        int pooCleaningNum = PlayerPrefs.GetInt("pooCleaningNum");
        int peeCleaningNum = PlayerPrefs.GetInt("peeCleaningNum");
        
        // Ī�� ������ �����Ѵٸ�
        if(feedNum>=2 && pooCleaningNum >=2 && peeCleaningNum >= 2)
        {
            good = true;
        }
        else
        {
            good = false;
        }
    }

    // ù��° ���� �����ֱ�
    public void showDialog()
    {
        // Ī���̶��
        if(good == true)
        {
            level = PlayerPrefs.GetInt("goodLevel");
            if(level == 1)
            {
                dialogText.text = "��~ ���� ��û �����ϳ�? OO�� �� �����ᱸ��. ���� �����.";
            }else if (level == 2)
            {
                dialogText.text = "���� OO�� �� �׸��� ���ϱ� �� ������ִ���? �� �װ� �� �����༭��. ���߾�!";
            }
            else
            {
                dialogText.text = "���� ���� ���� OO�� �� �����ᱸ��? ���� ���߾�~";
            }
            PlayerPrefs.SetInt("goodLevel", level++);
        }
        // �����
        else
        {
            level = PlayerPrefs.GetInt("badLevel");
            if (level == 1)
            {
                dialogText.text = " �������� ���� ���� ������ ������ �ʿ���. �� �� �������ַ�!";
            }
            else if (level == 2)
            {
                dialogText.text = "�������ʹ� OO �̸� ����� ���� �� ì����";
            }
            else
            {
                dialogText.text = "���� ���� �ٻڰ� ���³� ������. �׷��� OO �̵� �Ű���ַ�!";
            }
            PlayerPrefs.SetInt("badLevel", level++);
        }
    }

    // �Ϸ� �����ֱ�, ��Һ�����, ���ٵ�� Ƚ�� ����
    public void ResetNum()
    {
        PlayerPrefs.SetInt("feedNum", 0);
        PlayerPrefs.SetInt("pooCleaningNum", 0);
        PlayerPrefs.SetInt("peeCleaningNum", 0);
        PlayerPrefs.SetInt("touchingNum", 0);
    }
}
