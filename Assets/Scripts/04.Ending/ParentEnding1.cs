using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ParentEnding1 : MonoBehaviour
{
    public Text dialogText;
    public GameObject dialogBox;
    public int dialogNum;
    string petName;

    void Start()
    {
        dialogNum = 0;
        petName = PlayerPrefs.GetString("name"); 
    }

    public void ChangeText()
    {
        petName = PlayerPrefs.GetString("name");
        dialogNum = dialogNum + 1;
        switch (dialogNum)
        {
            case 1:
                dialogText.text = "엄마 아빠 동의도 없이 네가 "+ petName + "을(를) 데려왔어도 이해해주고 허락해줬으면 너도 노력하는 모습을 보여줘야지... 네가 약속을 지킬 거라 생각했는데 이렇게 무책임한 모습을 보이다니 엄만 많이 실망했어.";
                break;
            case 2:
                dialogText.text = "도저히 "+ petName + "을(를) 데리고 못 살겠으니까 다른 집으로 보낼거야.";
                break;
            case 3:
                UnityEngine.SceneManagement.SceneManager.LoadScene("EndingDisplay1");
                break;
            default:
                break;
        }
    }
}
