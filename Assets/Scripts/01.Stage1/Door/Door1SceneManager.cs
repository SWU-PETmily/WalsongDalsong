using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Door1SceneManager : MonoBehaviour
{
    int quitDate;             // 종료한 날짜
    int quitTime;             // 종료한 시간

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // 뒤로가기 버튼
    public void BtnBack()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Room1Scene");
    }

    // 문 버튼
    public void BtnGrip()
    {
        Debug.Log("가상부모 등장");
    }

    // 종료시 실행
    private void OnApplicationQuit()
    {
        QuitDateCheck(); //종료날짜시간 체크
    }

    // 종료 날짜 시간 체크
    private void QuitDateCheck()
    {
        quitDate = int.Parse(System.DateTime.Now.ToString("yyyyMMdd"));
        quitTime = int.Parse(System.DateTime.Now.ToString("HHmm"));

        Debug.Log("종료 날짜 : " + quitDate);
        Debug.Log("종료 시간 : " + quitTime);

        PlayerPrefs.SetInt("quitDate", quitDate);
        PlayerPrefs.SetInt("quitTime", quitTime);

    }
}
