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
        TalkText.text = "좋아! " + PlayerPrefs.GetString("name") + "(이)라고 부르고싶구나. 이름은 한 번 정하면 바꿀 수 없어. 이대로 정해도 괜찮니?";

    }

    //btn next
    public void Change()
    {
        dialogBox.SetActive(false);
        boxChecking.SetActive(true);
        txtChecking.text = PlayerPrefs.GetString("name") + "(으)로 이름을 확정할까요?";
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
