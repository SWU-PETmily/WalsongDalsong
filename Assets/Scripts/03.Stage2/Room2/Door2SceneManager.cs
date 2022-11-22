using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Door2SceneManager : MonoBehaviour
{
    int quitDate;             // ������ ��¥
    int quitTime;             // ������ �ð�

    public GameObject bgBlack;          // �������
    public GameObject dialogBox;        // ����θ� ��ȭâ
    public Text dialogText;             // ����θ� ��ȭâ �ؽ�Ʈ

    public GameObject btnBack;          // �ڷΰ��� ��ư
    public GameObject btnGrip;          // ������ ��ư
    public GameObject snell;            // ����
    public GameObject footbag;          // �躯����

    public bool isSnell = false;          // ���� Ȯ�� ����
    public bool isClothes = false;          // �躯 ���� Ȯ�� ����

    // Start is called before the first frame update
    void Start()
    {
        // ����θ� ��ȭâ �����
        bgBlack.SetActive(false);
        dialogBox.SetActive(false);
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
        UnityEngine.SceneManagement.SceneManager.LoadScene("Room2Scene");
    }

    // �� ��ư
    public void BtnGrip()
    {
        // ���� Ȯ�� �� �̹��� ����
        Item2Controller item2Controller1 = GameObject.Find("snell").GetComponent<Item2Controller>();
        Item2Controller item2Controller2 = GameObject.Find("clothes").GetComponent<Item2Controller>();
        isSnell = item2Controller1.isSnell;
        isClothes = item2Controller2.isClothes;

        // ���ٰ� �躯���� �� �� ì��ٸ�
        if (isSnell == true && isClothes == true)
        {
            Debug.Log("��å�ϱ�");
            UnityEngine.SceneManagement.SceneManager.LoadScene("WalkOutsideScene");
        }
        // ì���� �ʾҴٸ�
        else
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
            dialogText.text = "��å�� �Ϸ��� ���ٰ� �躯������ ��� ì�ܾ���.";
        }
    }

}
