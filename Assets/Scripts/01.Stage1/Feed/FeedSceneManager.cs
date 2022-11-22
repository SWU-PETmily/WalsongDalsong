using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class FeedSceneManager : MonoBehaviour
{
    int exeTime;              // 실행한 시간
    public GameObject bgTable;      // 배경 오브젝트
    public Sprite imgDayBg;         // 낮 배경 이미지
    public Sprite imgNightBg;          // 밤 배경 이미지
    public bool isDay = true;          // 낮 확인 변수

    // Start is called before the first frame update
    void Start()
    {

        // 0=아무것도 안 함. 1=식사지급완료, 2=식사 치우기. 3=물지급완료
        PlayerPrefs.SetInt("feedLevel", 0);
        // 식사 급수 미션 성공 = 0
        PlayerPrefs.SetInt("successFeed", 0);
        // 낮/밤에 따라 배경 이미지 변경
        ExeDateCheck();
    }

    // 낮/밤에 따라 배경 이미지 변경
    private void ExeDateCheck()
    {
        exeTime = int.Parse(System.DateTime.Now.ToString("HH"));

        if(exeTime >= 07 && exeTime < 19)
        {
            // 낮이라면
            bgTable.GetComponent<SpriteRenderer>().sprite = imgDayBg;
            isDay = true;
        }
        else
        {
            // 밤이라면
            bgTable.GetComponent<SpriteRenderer>().sprite = imgNightBg;
            isDay = false;
        }

    }

}
