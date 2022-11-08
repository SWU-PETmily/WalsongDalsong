using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btnDogController : MonoBehaviour
{
    public GameObject bg;           // ���
    public GameObject bowlFeed;     // ���׸�
    public GameObject bowlWater;     // ���׸�
    public GameObject btnDog;     // ������ ��ư
    public GameObject btnBack;     // �ڷΰ��� ��ư
    public GameObject bgBlack;     // �������
    public GameObject particle;     // ��ƼŬ
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
            particle.SetActive(true);
            bg.GetComponent<SpriteRenderer>().sprite = imgShadowN;         // ��� �׸��� ���ֱ�

            PlayerPrefs.SetInt("feedLevel", 0);     // �Ļ� �޼� �� �ܰ� �ʱ�ȭ. 0=�ƹ��͵� �� ��. 1=�Ļ����޿Ϸ�, 2=�Ļ� ġ���. 3=�����޿Ϸ�
            PlayerPrefs.SetInt("successFeed", 1);     // �Ļ� �޼� �̼� ����
            int num = PlayerPrefs.GetInt("feedNum") + 1; // �Ϸ� �躯 ġ��� Ƚ�� ����
            PlayerPrefs.SetInt("feedNum", num);

            Invoke("ChangeScene", 5.0f);           // ��� ��ȯ
        }
    }

    // ��� ��ȯ
    void ChangeScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Room1Scene");

    }

    public void btnBackClick()
    {
        PlayerPrefs.SetInt("feedLevel", 0);     // �Ļ� �޼� �� �ܰ� ����. 0=�ƹ��͵� �� ��. 1=�Ļ����޿Ϸ�, 2=�Ļ� ġ���. 3=�����޿Ϸ�
        PlayerPrefs.SetInt("successFeed", 0);     // �Ļ� �޼� �̼� ����
        UnityEngine.SceneManagement.SceneManager.LoadScene("Room1Scene");
    }
}
