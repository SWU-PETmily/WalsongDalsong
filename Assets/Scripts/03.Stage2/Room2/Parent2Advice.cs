using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// ���� �ʱ�ȭ && ����θ� Ī��/���
public class Parent2Advice : MonoBehaviour
{
    public Text dialogText;
    public GameObject dialogBox;
    public GameObject mom;

    public int dialogNum;       // ��� ��ȣ
    public bool good = true;    // Ī��/���
    public int level;           // Ī��/��� �ܰ�
    string petName;             // ���̸�

    // �ٲ� �̹���
    public Sprite momSmile;     // ���� ����
    public Sprite momAngry;     // ȭ�� ����

    // Start is called before the first frame update
    void Start()
    {
        // �ӽ� ����
        PlayerPrefs.SetInt("goodLevel", 1);
        PlayerPrefs.SetInt("badLevel", 1);
        PlayerPrefs.SetInt("feedNum", 2);
        PlayerPrefs.SetInt("pooCleaningNum", 4);
        PlayerPrefs.SetInt("walkNum", 2);
        PlayerPrefs.SetInt("stage", 2);


        petName = PlayerPrefs.GetString("name");
        dialogNum = 0;

        GoodOrBad();    // Ī�� or ��� �з�
        showDialog();   // ù ��° ���� �����ֱ�    
        ResetNum();     // �Ϸ� ���� �ʱ�ȭ
        QuitDateCheck();    // ���� �ð� �缳��
    }

    // ��ư Ŭ�� �Լ�
    public void ClickBtn()
    {
        if (good == true)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Card2Scene");
        }
        else
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Room2Scene");
        }
    }

    // Ī�� or ��� �з�
    void GoodOrBad()
    {
        int feedNum = PlayerPrefs.GetInt("feedNum");
        int pooCleaningNum = PlayerPrefs.GetInt("pooCleaningNum");
        // int peeCleaningNum = PlayerPrefs.GetInt("peeCleaningNum");
        int walkNum = PlayerPrefs.GetInt("walkNum");

        // Ī�� ������ �����Ѵٸ�
        if (feedNum >= 2 && pooCleaningNum >= 4 && walkNum >= 2)
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
        if (good == true)
        {
            level = PlayerPrefs.GetInt("goodLevel");
            if (level == 1)
            {
                dialogText.text = "������ ó���� �װ� " + petName + "��(��) �� ���� �� ������ �����ߴµ�... ���� �����̾�����! ���� �����~";
            }
            else if (level == 2)
            {
                dialogText.text = "���� ���� �������� �׷��� �� Ī���� �ϴ���. ������ ���� ���� " + petName + " ��å�� �� ��Ų�ٰ�. �ʹ� ��Ư��!";
            }
            else
            {
                dialogText.text = "���� ��� ��ô �װ� �ڶ�������. " + petName + "��(��) �������� å�Ӱ� �ִ� ��� �����༭ ����~";
            }
            PlayerPrefs.SetInt("goodLevel", level + 1);
        }
        // �����
        else
        {
            level = PlayerPrefs.GetInt("badLevel");
            if (level == 1)
            {
                dialogText.text = petName+"��(��) ������ �� �ؾ�����... �Ϸ翡 �Ļ縦 2ȸ, ��Һ� ó�� 4ȸ, ��å 2ȸ�� �� ���־�� �Ѵܴ�!";
            }
            else if (level == 2)
            {
                dialogText.text = "�ʴ� ������ ģ������ ������ " + petName + "(��)���Դ� �츮 ���� �ۿ� ���ܴ�. �׷��� �츮�� å���� ������ ������� ��.";
            }
            else
            {
                dialogText.text = "�̷��� ����� ������ �� �� �Ÿ� �츰 �� �̻� " + petName + "��(��) �⸣�� �����.";
            }
            PlayerPrefs.SetInt("badLevel", level + 1);
        }
    }

    // �Ϸ� �����ֱ�, ��Һ�����, ���ٵ�� Ƚ�� ����
    void ResetNum()
    {
        PlayerPrefs.SetInt("feedNum", 0);
        PlayerPrefs.SetInt("pooCleaningNum", 0);
        PlayerPrefs.SetInt("peeCleaningNum", 0);
        PlayerPrefs.SetInt("touchingNum", 0);
        PlayerPrefs.SetInt("walkNum", 0);
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
