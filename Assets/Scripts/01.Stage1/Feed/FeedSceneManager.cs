using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedSceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // 식사 급수 미션 성공 = 0
        PlayerPrefs.SetInt("successFeed", 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 종료시 실행
    private void OnApplicationQuit()
    {
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
