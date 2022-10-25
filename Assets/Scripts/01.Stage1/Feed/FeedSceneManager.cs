using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedSceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // �Ļ� �޼� �̼� ���� = 0
        PlayerPrefs.SetInt("successFeed", 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // ����� ����
    private void OnApplicationQuit()
    {
        QuitDateCheck(); //���ᳯ¥�ð� üũ
        PlayerPrefs.SetInt("feedLevel", 0);     // �Ļ� �޼� �� �ܰ� ����. 0=�ƹ��͵� �� ��. 1=�Ļ����޿Ϸ�, 2=�����޿Ϸ�.
        PlayerPrefs.SetInt("successFeed", 0);     // �Ļ� �޼� �̼� ����
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
