using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ParentEnding1 : MonoBehaviour
{
    public Text dialogText;
    public GameObject dialogBox;
    public int dialogNum;
    string petName;

    void Start()
    {
        dialogNum = 0;
        petName = PlayerPrefs.GetString("name"); 
    }

    public void ChangeText()
    {
        petName = PlayerPrefs.GetString("name");
        dialogNum = dialogNum + 1;
        switch (dialogNum)
        {
            case 1:
                dialogText.text = "���� �ƺ� ���ǵ� ���� �װ� "+ petName + "��(��) �����Ծ �������ְ� ����������� �ʵ� ����ϴ� ����� ���������... �װ� ����� ��ų �Ŷ� �����ߴµ� �̷��� ��å���� ����� ���̴ٴ� ���� ���� �Ǹ��߾�.";
                break;
            case 2:
                dialogText.text = "������ "+ petName + "��(��) ������ �� ������ϱ� �ٸ� ������ �����ž�.";
                break;
            case 3:
                UnityEngine.SceneManagement.SceneManager.LoadScene("EndingDisplay1");
                break;
            default:
                break;
        }
    }
}
