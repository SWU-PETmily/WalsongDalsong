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

    // Start is called before the first frame update
    void Start()
    {
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
        }
        else
        {
            // 밤이라면
            bgTable.GetComponent<SpriteRenderer>().sprite = imgNightBg;
        }

    }

    // 종료시 실행
    private void OnApplicationQuit()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Room1Scene");       // 종료시 거실로 이동
        QuitDateCheck(); //종료날짜시간 체크
        PlayerPrefs.SetInt("feedLevel", 0);     // 식사 급수 내 단계 저장. 0=아무것도 안 함. 1=식사지급완료, 2=물지급완료.
        PlayerPrefs.SetInt("successFeed", 0);     // 식사 급수 미션 실패
    }

    // 종료 날짜 시간 체크
    private void QuitDateCheck()
    {
        int quitDate = int.Parse(System.DateTime.Now.ToString("yyyyMMdd"));
        int quitTime = int.Parse(System.DateTime.Now.ToString("HHmm"));

        Debug.Log("종료 날짜 : " + quitDate);
        Debug.Log("종료 시간 : " + quitTime);

        PlayerPrefs.SetInt("quitDate", quitDate);
        PlayerPrefs.SetInt("quitTime", quitTime);

    }
}
