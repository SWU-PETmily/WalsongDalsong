using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public Text TalkText;
    public GameObject scanObject;

    void Start()
    {
        TalkText.text = "좋아! " + PlayerPrefs.GetString("name") + "(이)라고 부르고싶구나. 이름은 한 번 정하면 바꿀 수 없어. 이대로 정해도 괜찮니?";

    }

    public void Action(GameObject scanObj)
    {
        scanObject = scanObj;
        TalkText.text = "좋아! "+ PlayerPrefs.GetString("name") + "(이)라고 부르고싶구나. 이름은 한 번 정하면 바꿀 수 없어. 이대로 정해도 괜찮니?";
    }

    public void Change()
    {
        TalkText.text = "good";
    }
}
