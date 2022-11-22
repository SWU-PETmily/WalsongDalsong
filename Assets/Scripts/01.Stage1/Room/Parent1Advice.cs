using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


// ���� �ʱ�ȭ && ����θ� Ī��/���
public class Parent1Advice : MonoBehaviour
{
    public Text dialogText;
    public GameObject dialogBox;
    public GameObject mom;

    int dialogNum =0;       // ��� ��ȣ
    public bool good = true;    // Ī��/���
    public int level;           // Ī��/��� �ܰ�
    string petName;      // ���̸�

    // �ٲ� �̹���
    public Sprite momSmile;     // ���� ����
    public Sprite momAngry;     // ȭ�� ����

    void Start()
    {
        petName = PlayerPrefs.GetString("name");

        GoodOrBad();    // Ī�� or ��� �з�
        showDialog();   // ù ��° ���� �����ֱ�    
        QuitDateCheck();    // ���� �ð� �缳��
       
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
                UnityEngine.SceneManagement.SceneManager.LoadScene("Card1Scene");
            }
        }
        else
        {
            if (level == 1)
            {
                Bad1();
            }
            else
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("Room1Scene");
            }
        }
    }

    // Ī�� ���
    void Good1()
    {
        dialogNum = dialogNum + 1;
        switch (dialogNum)
        {
            case 1:
                dialogText.text = "�ؾ��� ���� ��� �������� ������ �ٰ�! �������� �ǻ� ���� ��ȣ�� �ľ��� �� �ִ� ī�ֽñ׳��� Ȯ���� �� �ִ� ī���.";
                break;
            case 2:
                dialogText.text = "������ �Ϸ� �� ���� ��� ������ ������ �� �徿 �ٰ�. �װ� �� ī��� �� �� "+ petName+"(��)�� ������ �� ������ ���ھ�.";
                break;
            case 3:
                UnityEngine.SceneManagement.SceneManager.LoadScene("Card1Scene");
                break;
            default:
                UnityEngine.SceneManagement.SceneManager.LoadScene("Card1Scene");
                break;
        }
    }

     // ��� ���
    void Bad1()
    {
        dialogNum = dialogNum + 1;
        switch (dialogNum)
        {
            case 1:
                dialogText.text = "������ ����� �򰥸��� �� ������ �ٽ� ������ٰ�.";
                break;
            case 2:
                dialogText.text = "�Ϸ翡 �Ļ縦 2ȸ, ��Һ� ó�� 4ȸ ���־�� �Ѵܴ�!";
                break;
            case 3:
                UnityEngine.SceneManagement.SceneManager.LoadScene("Room1Scene");
                break;
            default:
                UnityEngine.SceneManagement.SceneManager.LoadScene("Room1Scene");
                break;
        }
    }

    // Ī�� or ��� �з�
    void GoodOrBad()
    {
        int feedNum = PlayerPrefs.GetInt("feedNum");
        int pooCleaningNum = PlayerPrefs.GetInt("pooCleaningNum");

        // Ī�� ������ �����Ѵٸ�
        if (feedNum>=1 && pooCleaningNum >=1)
        {
            mom.GetComponent<Image>().sprite = this.momSmile;  // ���� �̹����� ����
            good = true;
        }
        else
        {
            mom.GetComponent<Image>().sprite = this.momAngry;  // ȭ�� �̹����� ����
            good = false;
        }
    }

    // ù��° ���� �����ֱ�
    void showDialog()
    {
        // Ī���̶��
        if(good == true)
        {
            level = PlayerPrefs.GetInt("goodLevel");
            if(level == 1)
            {
                dialogText.text = "��~ ���� ��û �����ϳ�? " + petName + "(��)�� �� �����ᱸ��. ���� �����.";
            }
            else if (level == 2)
            {
                dialogText.text = "���� " + petName + "(��)�� �� �׸��� ���ϱ� �� ������ִ���? �� �װ� �� �����༭��. ���߾�!";
            }
            else
            {
                dialogText.text = "���� ���� ���� " + petName + "(��)�� �� �����ᱸ��? ���� ���߾�~";
            }
            PlayerPrefs.SetInt("goodLevel", level + 1);
        }
        else if(good == false)
        {
            // �����
            level = PlayerPrefs.GetInt("badLevel");
            if (level == 1)
            {
                dialogText.text = " �������� ���� ���� ������ ������ �ʿ���. �� �� �������ַ�!";
            }
            else if (level == 2)
            {
                dialogText.text = "�������ʹ� " + petName + "(��)�� ����� ���� �� ì����";
            }
            else
            {
                dialogText.text = "���� ���� �ٻڰ� ���³� ������. �׷��� " + petName + "(��)�� �Ű���ַ�!";
            }
            PlayerPrefs.SetInt("badLevel", level + 1);
        }
        ResetNum();     // �Ϸ� ���� �ʱ�ȭ
    }

    // �Ϸ� �����ֱ�, ��Һ�����, ���ٵ�� Ƚ�� ����
    void ResetNum()
    {
        PlayerPrefs.SetInt("feedNum", 0);
        PlayerPrefs.SetInt("pooCleaningNum", 0);
        PlayerPrefs.SetInt("peeCleaningNum", 0);
        PlayerPrefs.SetInt("touchingNum", 0);
    }

    // ���� �ð� �缳��
    private void QuitDateCheck()
    {
        int quitDate = int.Parse(System.DateTime.Now.ToString("yyyyMMdd"));
        int quitTime = int.Parse(System.DateTime.Now.ToString("HHmm"));

        Debug.Log("���� ��¥ : " + quitDate);
        Debug.Log("���� �ð� : " + quitTime);

        PlayerPrefs.SetInt("quitDate", quitDate);
        PlayerPrefs.SetInt("quitTime", quitTime);
    }

}
