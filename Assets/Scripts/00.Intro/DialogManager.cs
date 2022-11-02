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
        // 이름 짓기 후 게이지 증가
        PlayerPrefs.SetFloat("guage", 0.2f);
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level1IntroduceScene");
    }

    //btn no
    public void StartNaming()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("NamingScene");
    }
}
