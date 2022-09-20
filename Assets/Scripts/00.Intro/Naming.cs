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
        InputText.onValueChanged.AddListener(
            (word) => InputText.text = Regex.Replace(word, @"[^0-9a-zA-Z��-�R]", "")
        );

        if (InputText.text != "")
        {
            PlayerPrefs.DeleteKey("name");
            if (!PlayerPrefs.HasKey("name"))
                PlayerPrefs.SetString("name", InputText.text);
            SceneManager.LoadScene("NameCheckScene");
        }
        else
        {
            WarningText.text = "�� ���� �̻��� ������ؿ�!";
        }
    }
}