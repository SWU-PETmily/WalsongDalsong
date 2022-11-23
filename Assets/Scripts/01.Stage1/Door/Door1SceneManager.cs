using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Door1SceneManager : MonoBehaviour
{
    int quitDate;             // ������ ��¥
    int quitTime;             // ������ �ð�
    string petName;           // ���̸�

    public GameObject bgBlack;          // �������
    public GameObject dialogBox;        // ����θ� ��ȭâ
    public Text dialogText;             // ����θ� ��ȭâ �ؽ�Ʈ

    public GameObject btnBack;          // �ڷΰ��� ��ư
    public GameObject btnGrip;          // ������ ��ư
    public GameObject snell;            // ����

    // Start is called before the first frame update
    void Start()
    {
        // ����θ� ��ȭâ �����
        bgBlack.SetActive(false);
        dialogBox.SetActive(false);
        // ������ �̸� ��������
        petName = PlayerPrefs.GetString("name");
        Debug.Log(petName);
    }


    // ��ȭ �ѱ�� ��ư
    public void BtnNextDialog()
    {
        // ����θ� ��ȭâ �����
        bgBlack.SetActive(false);
        dialogBox.SetActive(false);

        // UI ���̱�
        btnBack.SetActive(true);
        btnGrip.SetActive(true);
        snell.SetActive(true);
    }

    // �ڷΰ��� ��ư
    public void BtnBack()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Room1Scene");
    }

    // �� ��ư
    public void BtnGrip()
    {
        // ��ȭâ �ؽ�Ʈ ����
        dialogText.text = "������ ù ��å�� 3������ ������ ���� �ϴ� �� ���ٰ� ������ " + petName + "(��)�� �������ϴϱ� ���� �ð��� ����.";
        // ����θ� ��ȭâ ���̱�
        bgBlack.SetActive(true);
        dialogBox.SetActive(true);

        // UI �����
        btnBack.SetActive(false);
        //btnGrip.SetActive(false);
        //snell.SetActive(false);
    }

}
