using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Door1SceneManager : MonoBehaviour
{
    int quitDate;             // 종료한 날짜
    int quitTime;             // 종료한 시간
    string petName;           // 펫이름

    public GameObject bgBlack;          // 검정배경
    public GameObject dialogBox;        // 가상부모 대화창
    public Text dialogText;             // 가상부모 대화창 텍스트

    public GameObject btnBack;          // 뒤로가기 버튼
    public GameObject btnGrip;          // 손잡이 버튼
    public GameObject snell;            // 목줄
    public GameObject footbag;          // 배변봉투

    // Start is called before the first frame update
    void Start()
    {
        // 가상부모 대화창 숨기기
        bgBlack.SetActive(false);
        dialogBox.SetActive(false);
        // 강아지 이름 가져오기
        petName = PlayerPrefs.GetString("name");
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
        UnityEngine.SceneManagement.SceneManager.LoadScene("Room1Scene");
    }

    // 문 버튼
    public void BtnGrip()
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
        dialogText.text = "강아지 첫 산책은 3개월이 지나기 전에 하는 게 좋다고 하지만 " + petName + "(이)가 무서워하니까 조금 시간을 주자.";
    }

}
