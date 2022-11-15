using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Door2SceneManager : MonoBehaviour
{
    int quitDate;             // 종료한 날짜
    int quitTime;             // 종료한 시간

    public GameObject bgBlack;          // 검정배경
    public GameObject dialogBox;        // 가상부모 대화창
    public Text dialogText;             // 가상부모 대화창 텍스트

    public GameObject btnBack;          // 뒤로가기 버튼
    public GameObject btnGrip;          // 손잡이 버튼
    public GameObject snell;            // 목줄
    public GameObject footbag;          // 배변봉투

    public bool isSnell = false;          // 목줄 확인 변수
    public bool isBag = false;          // 배변 봉투 확인 변수

    // Start is called before the first frame update
    void Start()
    {
        // 가상부모 대화창 숨기기
        bgBlack.SetActive(false);
        dialogBox.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    // 대화 넘기기 버튼
    public void BtnNextDialog()
    {

        // 가상부모 대화창 숨기기
        bgBlack.SetActive(false);
        dialogBox.SetActive(false);

        // UI 보이기
        btnBack.SetActive(true);
        btnGrip.SetActive(true);
        snell.SetActive(true);
        footbag.SetActive(true);
    }

    // 뒤로가기 버튼
    public void BtnBack()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Room2Scene");
    }

    // 문 버튼
    public void BtnGrip()
    {

        // 낮밤 확인 후 이미지 변경
        Item2Controller item2Controller1 = GameObject.Find("snell").GetComponent<Item2Controller>();
        Item2Controller item2Controller2 = GameObject.Find("footbag").GetComponent<Item2Controller>();
        isSnell = item2Controller1.isSnell;
        isBag = item2Controller2.isBag;

        // 목줄과 배변봉투 둘 다 챙겼다면
        if (isSnell == true && isBag == true)
        {
            Debug.Log("산책하기");
            UnityEngine.SceneManagement.SceneManager.LoadScene("WalkOutsideScene");
        }
        // 챙기지 않았다면
        else
        {
            // 가상부모 대화창 보이기
            bgBlack.SetActive(true);
            dialogBox.SetActive(true);

            // UI 숨기기
            btnBack.SetActive(false);
            btnGrip.SetActive(false);
            snell.SetActive(false);
            footbag.SetActive(false);

            // 대화창 텍스트 변경
            dialogText.text = "산책을 하려면 목줄과 배변봉투를 모두 챙겨야해.";
        }
    }

    // 종료시 실행
    private void OnApplicationPause()
    {
        PlayerPrefs.SetString("quitSceneName", "Room2Scene");   // 종료씬 저장
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
