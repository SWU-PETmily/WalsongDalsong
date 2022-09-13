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
        TalkText.text = "����! " + PlayerPrefs.GetString("name") + "(��)��� �θ���ͱ���. �̸��� �� �� ���ϸ� �ٲ� �� ����. �̴�� ���ص� ������?";

    }

    public void Action(GameObject scanObj)
    {
        scanObject = scanObj;
        TalkText.text = "����! "+ PlayerPrefs.GetString("name") + "(��)��� �θ���ͱ���. �̸��� �� �� ���ϸ� �ٲ� �� ����. �̴�� ���ص� ������?";
    }

    public void Change()
    {
        TalkText.text = "good";
    }
}
