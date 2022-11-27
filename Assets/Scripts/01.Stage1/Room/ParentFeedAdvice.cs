using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class ParentFeedAdvice : MonoBehaviour
{
     public void ClickBtn()
    {
        int stage = PlayerPrefs.GetInt("stage");
        if (stage == 2)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Room2Scene");
        }
        else
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Room1Scene");
        }

    }
}
