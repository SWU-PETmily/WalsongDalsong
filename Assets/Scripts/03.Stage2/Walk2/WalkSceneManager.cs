using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkSceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // ����� ����
    private void OnApplicationPause()
    {
        PlayerPrefs.SetString("quitSceneName", "Room2Scene");   // ����� ����
        QuitDateCheck(); //���ᳯ¥�ð� üũ
        PlayerPrefs.SetInt("successWalk", 0);     // �Ļ� �޼� �̼� ����
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
