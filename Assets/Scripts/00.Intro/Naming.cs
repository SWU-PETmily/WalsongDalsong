using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Text.RegularExpressions;

public class Naming : MonoBehaviour
{

    public InputField InputText;
    public Text WarningText;

    public void Change()
    {
        // �Է� ����
        InputText.onValueChanged.AddListener(
            (word) => InputText.text = Regex.Replace(word, @"[^0-9a-zA-Z��-�R]", "")
        );

        if (InputText.text != "")
        {
            // �ؽ�Ʈ�ʵ忡 �Է��� �ִٸ�
            PlayerPrefs.DeleteKey("name");      // ���� �̸� ����
            // �̸� ����
            if (!PlayerPrefs.HasKey("name"))    // name�� ���ٸ� ����
                PlayerPrefs.SetString("name", InputText.text);
            // �������� ����
            if (!PlayerPrefs.HasKey("stage"))
                PlayerPrefs.SetInt("stage", 1);
            Debug.Log(PlayerPrefs.GetInt("stage"));
            // �̸� Ȯ�� �� ����
            SceneManager.LoadScene("NameCheckScene");
        }
        else
        {
            WarningText.text = "�� ���� �̻��� ������ؿ�!";
        }
    }
}