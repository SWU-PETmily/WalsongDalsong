using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btnDogController : MonoBehaviour
{
    public GameObject bg;              // ���
    public Sprite imgDayBg;         // �� ��� �̹���
    public Sprite imgNightBg;          // �� ��� �̹���
    public bool isDay = true;          // �� Ȯ�� ����
    public GameObject bowlFeed;     // ���׸�
    public GameObject bowlWater;     // ���׸�
    public GameObject btnDog;     // ������ ��ư
    public GameObject btnBack;     // �ڷΰ��� ��ư
    public GameObject bgBlack;     // �������
    public GameObject txtDone;     // �Ϸ� �ؽ�Ʈ�̹���
    public Sprite imgShadowN;         // ��� �׸��� ���� �̹���(�׸�)

    public void btnDogClick()
    {
        if (PlayerPrefs.GetInt("feedLevel") == 1)
        {
            bowlFeed.SetActive(false);
            bowlWater.SetActive(true);
            btnDog.SetActive(false);
            PlayerPrefs.SetInt("feedLevel", 2);         // �Ļ� �޼� �� �ܰ� ����. 0=�ƹ��͵� �� ��. 1=�Ļ����޿Ϸ�, 2=�Ļ� ġ���. 3=�����޿Ϸ�

        }
        else if (PlayerPrefs.GetInt("feedLevel") == 3)
        {
            bowlWater.SetActive(false);
            btnDog.SetActive(false);
            btnBack.SetActive(false);
            bgBlack.SetActive(true);
            txtDone.SetActive(true);
         
            // ���� Ȯ�� �� ��� ����
            FeedSceneManager feedSceneManager = GameObject.Find("SceneManager").GetComponent<FeedSceneManager>();
            isDay = feedSceneManager.isDay;
            if (isDay == true)
            {
                bg.GetComponent<SpriteRenderer>().sprite = imgDayBg;         // ��� �׸��� ����� - ��
            }
            else
            {
                bg.GetComponent<SpriteRenderer>().sprite = imgNightBg;         // ��� �׸��� ����� - ��
            }

            PlayerPrefs.SetInt("feedLevel", 0);     // �Ļ� �޼� �� �ܰ� �ʱ�ȭ. 0=�ƹ��͵� �� ��. 1=�Ļ����޿Ϸ�, 2=�Ļ� ġ���. 3=�����޿Ϸ�
            PlayerPrefs.SetInt("successFeed", 1);     // �Ļ� �޼� �̼� ����

            Invoke("ChangeScene", 5.0f);           // ��� ��ȯ
        }
    }

    // ��� ��ȯ
    void ChangeScene()
    {

        // �������� 2���
        if (PlayerPrefs.GetInt("stage") == 2)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Room2Scene");
        }
        else
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Room1Scene");

        }
    }

    public void btnBackClick()
    {
        PlayerPrefs.SetInt("feedLevel", 0);     // �Ļ� �޼� �� �ܰ� ����. 0=�ƹ��͵� �� ��. 1=�Ļ����޿Ϸ�, 2=�Ļ� ġ���. 3=�����޿Ϸ�
        PlayerPrefs.SetInt("successFeed", 0);     // �Ļ� �޼� �̼� ����
        // �������� 2���
        if (PlayerPrefs.GetInt("stage") == 2)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Room2Scene");
        }
        else
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Room1Scene");

        }
    }
}
