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
                dialogText.text = "���� ������ ����ߴ� �� ��ﳪ��? �� ���� �ֵ� �����ڴ� ���� �ž�. å�Ӱ��� ���� ������� ��.";
                break;
            case 2:
                dialogText.text = "�������� ���ڱ� ȯ���� ���� ������ �ϴ� �� �����ϱ� ȥ�� ������ �ð��� ��� ��.";
                break;
            case 3:
                dialogText.text = "�츮�� �ݱ��� �ʴ´ٰ� ������ �ٰ����ų� ���ٵ������� �ϸ� ����� �� �������� �� ������ 30�и� ��ٷ�����!";
                break;
            case 4:
                dialogText.text = "30�� ���� ������ �����ϰ� ��ٷ��ָ� ��.";
                break;
            case 5:
                dialogBox.SetActive(false);
                LetsCheck();
                PlayerPrefs.SetString("quitSceneName", "CalmingSignal");   // ����� ����
                UnityEngine.SceneManagement.SceneManager.LoadScene("CalmingSignal");
                break;
            default:
                break;
        }
    }

    private void LetsCheck()
    {
        Debug.Log("���� �ð� : " + System.DateTime.Now.ToString());
        dt1 = int.Parse(System.DateTime.Now.ToString("HHmm"));
        PlayerPrefs.SetInt("lasttime", dt1);

    }
}
