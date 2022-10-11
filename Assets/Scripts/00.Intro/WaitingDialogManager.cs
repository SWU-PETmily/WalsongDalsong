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
                dialogText.text = "�츮�� �ݱ��� �ʴ´ٰ� ������ �ٰ����ų� ���ٵ������� �ϸ� ����� �� �������� �� ������ 30�и� ��ٷ�����!";
                break;
            case 2:
                dialogText.text = "30�� ���� ������ �����ϰ� ��ٷ��ָ� ��. �߰��� ������ �����ϸ� �������� �� �Ծ ó������ �ٽ� ��ٷ��� �ϴ� ��������!";
                break;
            case 3:
                dialogBox.SetActive(false);
                UnityEngine.SceneManagement.SceneManager.LoadScene("CalmingSignal");
                break;
            default:
                break;
        }


    }
}
