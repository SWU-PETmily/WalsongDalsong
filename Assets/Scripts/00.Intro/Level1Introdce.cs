using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level1Introdce : MonoBehaviour
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
        dialogNum = dialogNum + 1;
        switch (dialogNum)
        {
            case 1:
                dialogText.text = "하루에 밥주기 2회, 배변 처리 2회, 소변 처리 2회를 완료해야 그 날 할 일을 모두 한거야.";
                break;
            case 2:
                dialogText.text = "밥을 주면 유대감 게이지를 상승시킬 수 있어. 배소변 처리는 꼭 해줘야 하지만 그걸로 게이지가 오르지 않아.";
                break;
            case 3:
                dialogText.text = "게이지가 오르지 않는다고 배소변 처리를 소홀히 해선 안돼.";
                break;
            case 4:
                dialogText.text = "밥은 아침, 저녁에 주면 되고 강아지가 배소변을 누면 그때 치워주면 돼.";
                break;
            case 5:
                dialogText.text = "엄마는 너가 강아지를 잘 돌봐 줄 거라 믿어.";
                break;
            case 6:
                dialogBox.SetActive(false);
                PlayerPrefs.SetInt("quitTime", -1);     // 처음 실행인 지 알기위한 변수 저장
                UnityEngine.SceneManagement.SceneManager.LoadScene("Room1Scene");
                break;
            default:
                break;
        }
    }
}
