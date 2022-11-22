using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CardClickController : MonoBehaviour
{
    public void btnClick()
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
}
