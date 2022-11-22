using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class FeedSceneManager : MonoBehaviour
{
    int exeTime;              // ������ �ð�
    public GameObject bgTable;      // ��� ������Ʈ
    public Sprite imgDayBg;         // �� ��� �̹���
    public Sprite imgNightBg;          // �� ��� �̹���
    public bool isDay = true;          // �� Ȯ�� ����

    // Start is called before the first frame update
    void Start()
    {

        // 0=�ƹ��͵� �� ��. 1=�Ļ����޿Ϸ�, 2=�Ļ� ġ���. 3=�����޿Ϸ�
        PlayerPrefs.SetInt("feedLevel", 0);
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
            isDay = true;
        }
        else
        {
            // ���̶��
            bgTable.GetComponent<SpriteRenderer>().sprite = imgNightBg;
            isDay = false;
        }

    }

}
