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
        // 입력 제한
        InputText.onValueChanged.AddListener(
            (word) => InputText.text = Regex.Replace(word, @"[^0-9a-zA-Z가-힣]", "")
        );

        if (InputText.text != "")
        {
            // 텍스트필드에 입력이 있다면
            PlayerPrefs.DeleteKey("name");      // 기존 이름 삭제
            // 이름 저장
            if (!PlayerPrefs.HasKey("name"))    // name이 없다면
                PlayerPrefs.SetString("name", InputText.text);
            // 스테이지 저장
            if (!PlayerPrefs.HasKey("stage"))
                PlayerPrefs.SetInt("stage", 1);
            // 이름 확인 씬 시작
            UnityEngine.SceneManagement.SceneManager.LoadScene("NameCheckScene");
        }
        else
        {
            WarningText.text = "한 글자 이상은 적어야해요!";
        }
    }
}