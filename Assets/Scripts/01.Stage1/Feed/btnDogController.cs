using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btnDogController : MonoBehaviour
{
    public GameObject bowlFeed;     // ���׸�
    public GameObject bowlWater;     // ���׸�
    public GameObject btnDog;     // ������ ��ư

    public void btnClick()
    {
        if (PlayerPrefs.GetInt("feedLevel") == 1)
        {
            bowlFeed.SetActive(false);
            bowlWater.SetActive(true);
            btnDog.SetActive(false);

        }
        else if (PlayerPrefs.GetInt("feedLevel") == 2)
        {

        }
    }
}
