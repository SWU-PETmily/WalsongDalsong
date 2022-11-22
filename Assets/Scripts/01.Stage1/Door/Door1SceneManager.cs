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
    public GameObject footbag;          // �躯����

    // Start is called before the first frame update
    void Start()
    {
        // ����θ� ��ȭâ �����
        bgBlack.SetActive(false);
        dialogBox.SetActive(false);
        // ������ �̸� ��������
        petName = PlayerPrefs.GetString("name");
    }

    // Update is called once per frame
    void Update()
    {

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
        footbag.SetActive(true);
    }

    // �ڷΰ��� ��ư
    public void BtnBack()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Room1Scene");
    }

    // �� ��ư
    public void BtnGrip()
    {
        // ����θ� ��ȭâ ���̱�
        bgBlack.SetActive(true);
        dialogBox.SetActive(true);

        // UI �����
        btnBack.SetActive(false);
        btnGrip.SetActive(false);
        snell.SetActive(false);
        footbag.SetActive(false);

        // ��ȭâ �ؽ�Ʈ ����
        dialogText.text = "������ ù ��å�� 3������ ������ ���� �ϴ� �� ���ٰ� ������ " + petName + "(��)�� �������ϴϱ� ���� �ð��� ����.";
    }

}
