using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Door1SceneManager : MonoBehaviour
{
    int quitDate;             // ������ ��¥
    int quitTime;             // ������ �ð�

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // �ڷΰ��� ��ư
    public void BtnBack()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Room1Scene");
    }

    // �� ��ư
    public void BtnGrip()
    {
        Debug.Log("����θ� ����");
    }

    // ����� ����
    private void OnApplicationQuit()
    {
        QuitDateCheck(); //���ᳯ¥�ð� üũ
    }

    // ���� ��¥ �ð� üũ
    private void QuitDateCheck()
    {
        quitDate = int.Parse(System.DateTime.Now.ToString("yyyyMMdd"));
        quitTime = int.Parse(System.DateTime.Now.ToString("HHmm"));

        Debug.Log("���� ��¥ : " + quitDate);
        Debug.Log("���� �ð� : " + quitTime);

        PlayerPrefs.SetInt("quitDate", quitDate);
        PlayerPrefs.SetInt("quitTime", quitTime);

    }
}
