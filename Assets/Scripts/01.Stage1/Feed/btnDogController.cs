using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btnDogController : MonoBehaviour
{
    public GameObject bowlFeed;     // ���׸�
    public GameObject bowlWater;     // ���׸�
    public GameObject btnDog;     // ������ ��ư

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
            PlayerPrefs.SetInt("feedLevel", 0);     // �Ļ� �޼� �� �ܰ� �ʱ�ȭ. 0=�ƹ��͵� �� ��. 1=�Ļ����޿Ϸ�, 2=�Ļ� ġ���. 3=�����޿Ϸ�
            PlayerPrefs.SetInt("successFeed", 1);     // �Ļ� �޼� �̼� ����
            Invoke("ChangeScene", 4.0f);           // ��� ��ȯ
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
