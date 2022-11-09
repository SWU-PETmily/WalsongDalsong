using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level1Introdce : MonoBehaviour
{
    public Text dialogText;
    public GameObject dialogBox;
    public int dialogNum;

    void Start()
    {
        dialogNum = 0;
    }

    public void ChangeText()
    {
        dialogNum = dialogNum + 1;
        switch (dialogNum)
        {
            case 1:
                dialogText.text = "�Ϸ翡 ���ֱ� 2ȸ, �躯 ó�� 2ȸ, �Һ� ó�� 2ȸ�� �Ϸ��ؾ� �� �� �� ���� ��� �Ѱž�.";
                break;
            case 2:
                dialogText.text = "���� �ָ� ���밨 �������� ��½�ų �� �־�. ��Һ� ó���� �� ����� ������ �װɷ� �������� ������ �ʾ�.";
                break;
            case 3:
                dialogText.text = "�������� ������ �ʴ´ٰ� ��Һ� ó���� ��Ȧ�� �ؼ� �ȵ�.";
                break;
            case 4:
                dialogText.text = "���� ��ħ, ���ῡ �ָ� �ǰ� �������� ��Һ��� ���� �׶� ġ���ָ� ��.";
                break;
            case 5:
                dialogText.text = "������ �ʰ� �������� �� ���� �� �Ŷ� �Ͼ�.";
                break;
            case 6:
                dialogBox.SetActive(false);
                PlayerPrefs.SetInt("quitTime", -1);     // ó�� ������ �� �˱����� ���� ����
                UnityEngine.SceneManagement.SceneManager.LoadScene("Room1Scene");
                break;
            default:
                break;
        }
    }
}
