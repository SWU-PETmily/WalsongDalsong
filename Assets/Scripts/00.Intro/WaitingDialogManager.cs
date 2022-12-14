using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WaitingDialogManager : MonoBehaviour
{
    public Text dialogText;
    public GameObject dialogBox;
    public int dialogNum;
    int dt1;

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
                dialogText.text = "전에 엄마랑 약속했던 거 기억나지? 이 애의 주된 양육자는 너인 거야. 책임감을 갖고 대해줘야 해.";
                break;
            case 2:
                dialogText.text = "강아지가 갑자기 환경이 변해 무서워 하는 것 같으니까 혼자 적응할 시간을 줘야 해.";
                break;
            case 3:
                dialogText.text = "우리를 반기지 않는다고 성급히 다가가거나 쓰다듬으려고 하면 사람을 더 무서워할 수 있으니 30분만 기다려보자!";
                break;
            case 4:
                dialogText.text = "30분 동안 게임을 종료하고 기다려주면 돼.";
                break;
            case 5:
                dialogBox.SetActive(false);
                LetsCheck();
                PlayerPrefs.SetString("quitSceneName", "CalmingSignal");   // 종료씬 저장
                UnityEngine.SceneManagement.SceneManager.LoadScene("CalmingSignal");
                break;
            default:
                break;
        }
    }

    private void LetsCheck()
    {
        Debug.Log("종료 시간 : " + System.DateTime.Now.ToString());
        dt1 = int.Parse(System.DateTime.Now.ToString("HHmm"));
        PlayerPrefs.SetInt("lasttime", dt1);

    }
}
