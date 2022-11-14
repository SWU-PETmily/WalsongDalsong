using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class SceneManager : MonoBehaviour
{
    public GameObject spray;
    public GameObject tissueBox;
    public GameObject water;
    public GameObject tissue;

    // Start is called before the first frame update
    void Start()
    {
        spray.SetActive(false);
        tissueBox.SetActive(false);
        water.SetActive(false);
        tissue.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BtnBack()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("PooNoScene");
        PlayerPrefs.SetInt("successPooPeeClean", 0);     // ��Һ� �̼� ����
    }

    // ����� ����
    private void OnApplicationPause()
    {
        PlayerPrefs.SetString("quitSceneName", "Room1Scene");   // ����� ����
        QuitDateCheck(); //���ᳯ¥�ð� üũ
        PlayerPrefs.SetInt("successPooPeeClean", 0);     // ��Һ� �̼� ����
    }

    // ���� ��¥ �ð� üũ
    private void QuitDateCheck()
    {
        int quitDate = int.Parse(System.DateTime.Now.ToString("yyyyMMdd"));
        int quitTime = int.Parse(System.DateTime.Now.ToString("HHmm"));

        Debug.Log("���� ��¥ : " + quitDate);
        Debug.Log("���� �ð� : " + quitTime);

        PlayerPrefs.SetInt("quitDate", quitDate);
        PlayerPrefs.SetInt("quitTime", quitTime);

    }
}
