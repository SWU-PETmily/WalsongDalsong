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
        // ÀÔ·Â Á¦ÇÑ
        InputText.onValueChanged.AddListener(
            (word) => InputText.text = Regex.Replace(word, @"[^0-9a-zA-Z°¡-ÆR]", "")
        );

        if (InputText.text != "")
        {
            // ÅØ½ºÆ®ÇÊµå¿¡ ÀÔ·ÂÀÌ ÀÖ´Ù¸é
            PlayerPrefs.DeleteKey("name");      // ±âÁ¸ ÀÌ¸§ »èÁ¦
            // ÀÌ¸§ ÀúÀå
            if (!PlayerPrefs.HasKey("name"))    // nameÀÌ ¾ø´Ù¸é »ı¼º
                PlayerPrefs.SetString("name", InputText.text);
            // ½ºÅ×ÀÌÁö ÀúÀå
            if (!PlayerPrefs.HasKey("stage"))
                PlayerPrefs.SetInt("stage", 1);
            Debug.Log(PlayerPrefs.GetInt("stage"));
            // ÀÌ¸§ È®ÀÎ ¾À ½ÃÀÛ
            SceneManager.LoadScene("NameCheckScene");
        }
        else
        {
            WarningText.text = "ÇÑ ±ÛÀÚ ÀÌ»óÀº Àû¾î¾ßÇØ¿ä!";
        }
    }
}