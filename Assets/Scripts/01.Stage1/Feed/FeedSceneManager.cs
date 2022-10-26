using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedSceneManager : MonoBehaviour
{
    int exeTime;              // ������ �ð�
    public GameObject bgTable;      // ��� ������Ʈ
    public Sprite imgDayBg;         // �� ��� �̹���
    public Sprite imgNightBg;          // �� ��� �̹���

    // Start is called before the first frame update
    void Start()
    {
        // �Ļ� �޼� �̼� ���� = 0
        PlayerPrefs.SetInt("successFeed", 0);
        // ��/�㿡 ���� ��� �̹��� ����
        ExeDateCheck();
    }

    // ��/�㿡 ���� ��� �̹��� ����
    private void ExeDateCheck()
    {
        exeTime = int.Parse(System.DateTime.Now.ToString("HH"));

        if(exeTime >= 07 && exeTime < 19)
        {
            // ���̶��
            bgTable.GetComponent<SpriteRenderer>().sprite = imgDayBg;
        }
        else
        {
            // ���̶��
            bgTable.GetComponent<SpriteRenderer>().sprite = imgNightBg;
        }

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
