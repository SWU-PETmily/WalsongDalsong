using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PadBoxController : MonoBehaviour
{
    public GameObject newPad;           // 패드 한 장
    public GameObject bgBlack;     // 검정배경
    public GameObject txtDone;     // 완료 텍스트이미지

    public void ClickPadBox()
    {
        // 패드박스를 터치했다면
        newPad.SetActive(true);              // 새 패드 생성              
        // 미션 성공 알림
        PlayerPrefs.SetInt("successPooPeeClean", 1);
        Invoke("DoneTxtActive", 1.0f);        // 완료 문구 생성
        Invoke("ChangeScene", 4.0f);        // 거실로 돌아가기
    }

    // 완료 문구 생성
    void DoneTxtActive()
    {
        bgBlack.SetActive(true);
        txtDone.SetActive(true);
    }

    // 장면 전환
    void ChangeScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Room2Scene");
    }
}
