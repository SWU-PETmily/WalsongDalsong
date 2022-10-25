using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btnDogController : MonoBehaviour
{
    public GameObject bowlFeed;     // 사료그릇
    public GameObject bowlWater;     // 물그릇
    public GameObject btnDog;     // 강아지 버튼

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
