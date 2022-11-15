using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkSceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 종료시 실행
    private void OnApplicationPause()
    {
        PlayerPrefs.SetString("quitSceneName", "Room2Scene");   // 종료씬 저장
        QuitDateCheck(); //종료날짜시간 체크
        PlayerPrefs.SetInt("successWalk", 0);     // 식사 급수 미션 실패
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
