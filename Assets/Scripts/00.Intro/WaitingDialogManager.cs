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

    void Start()
    {
        dialogNum = 0;
    }

    public void ChangeText()
    {
        Debug.Log("touch");
        dialogNum = dialogNum + 1;
        switch (dialogNum)
        {
            case 1:
                dialogText.text = "우리를 반기지 않는다고 성급히 다가가거나 쓰다듬으려고 하면 사람을 더 무서워할 수 있으니 30분만 기다려보자!";
                break;
            case 2:
                dialogBox.SetActive(false);
                UnityEngine.SceneManagement.SceneManager.LoadScene("CalmingSignal");
                break;
            default:
                break;
        }


    }
}
