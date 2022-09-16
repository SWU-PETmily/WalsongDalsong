using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Naming : MonoBehaviour
{

    public InputField InputText;
    public Text WarningText;

    public void Change()
    {
        if (InputText.text != "")
        {
            PlayerPrefs.DeleteKey("name");
            if (!PlayerPrefs.HasKey("name"))
                PlayerPrefs.SetString("name", InputText.text);
            SceneManager.LoadScene("NameCheckScene");
        }
        else
        {
            WarningText.text = "한 글자 이상은 적어야해요!";
        }
    }
}