using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PadBoxController : MonoBehaviour
{
    public GameObject newPad;           // �е� �� ��
    public GameObject bgBlack;     // �������
    public GameObject txtDone;     // �Ϸ� �ؽ�Ʈ�̹���

    public void ClickPadBox()
    {
        // �е�ڽ��� ��ġ�ߴٸ�
        newPad.SetActive(true);              // �� �е� ����              
        // �̼� ���� �˸�
        PlayerPrefs.SetInt("successPooPeeClean", 1);
        Invoke("DoneTxtActive", 1.0f);        // �Ϸ� ���� ����
        Invoke("ChangeScene", 4.0f);        // �ŽǷ� ���ư���
    }

    // �Ϸ� ���� ����
    void DoneTxtActive()
    {
        bgBlack.SetActive(true);
        txtDone.SetActive(true);
    }

    // ��� ��ȯ
    void ChangeScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Room2Scene");
    }
}
