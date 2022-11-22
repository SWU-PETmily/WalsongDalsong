using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class ParentFeedAdvice : MonoBehaviour
{
    public GameObject bg;           // 배경
    public Sprite bgSummer;         // 여름 배경 이미지
    public Sprite bgWinter;         // 겨울 배경 이미지
    int stage = 0;                  // 단계 저장 변수

    void Start()
    {
        stage = PlayerPrefs.GetInt("stage");
        if (stage == 2)
        {
            // 겨울
            bg.GetComponent<SpriteRenderer>().sprite = bgWinter;
        }
        else
        {
            // 여름
            bg.GetComponent<SpriteRenderer>().sprite = bgSummer;
        }
    }

    public void ClickBtn()
    {
        if (stage == 2)
        {
            // 겨울
            UnityEngine.SceneManagement.SceneManager.LoadScene("Room2Scene");
        }
        else
        {
            // 여름
            UnityEngine.SceneManagement.SceneManager.LoadScene("Room1Scene");
        }

    }
}
