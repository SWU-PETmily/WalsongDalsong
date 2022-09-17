using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogManager : MonoBehaviour
{
    public Text TalkText;
    public GameObject dialogBox;
    public Button btnNext;

    public GameObject boxChecking;
    public Text txtChecking;
    public Button btnYes;
    public Button btnNo;

    void Start()
    {
        dialogBox.SetActive(true);
        boxChecking.SetActive(false);
        TalkText.text = "����! " + PlayerPrefs.GetString("name") + "(��)��� �θ���ͱ���. �̸��� �� �� ���ϸ� �ٲ� �� ����. �̴�� ���ص� ������?";

    }

    //btn next
    public void Change()
    {
        dialogBox.SetActive(false);
        boxChecking.SetActive(true);
        txtChecking.text = PlayerPrefs.GetString("name") + "(��)�� �̸��� Ȯ���ұ��?";
    }

    //btn yes
    public void StartTutorial()
    {
        SceneManager.LoadScene("Room1Scene");
    }

    //btn no
    public void StartNaming()
    {
        SceneManager.LoadScene("NamingScene");
    }
}
