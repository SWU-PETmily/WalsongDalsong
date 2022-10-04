using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TimeManager : MonoBehaviour
{
    public DateTime nowTime;
    public int hh;

    public Text txtName;

    // 낮밤 바뀔 배경 요소
    public GameObject imgBG;
    public GameObject imgTable;
    public Button btnFeed;
    public Button btnHarness;

    // 바꿀 이미지
    public Sprite img_day_bg;
    public Sprite img_day_table;
    public Sprite img_day_feed;
    public Sprite img_day_harness;
    public Sprite img_night_bg;
    public Sprite img_night_table;
    public Sprite img_night_feed;
    public Sprite img_night_harness;


    // Start is called before the first frame update
    void Start()
    {
        ChangeName();
        ChangeDayNighte();

        // 식사급수 횟수 저장
        if (!PlayerPrefs.HasKey("feedNum"))
            PlayerPrefs.SetInt("feedNum", 0);
        // 배변 횟수 저장
        if (!PlayerPrefs.HasKey("pooCleaningNum"))
            PlayerPrefs.SetInt("pooCleaningNum", 0);
        // 소변 횟수 저장
        if (!PlayerPrefs.HasKey("peeCleaningNum"))
            PlayerPrefs.SetInt("peeCleaningNum", 0);
        // 쓰다듬기 횟수 저장
        if (!PlayerPrefs.HasKey("touchingNum"))
            PlayerPrefs.SetInt("touchingNum", 0);
        // 미션 성공 여부 저장
        if (!PlayerPrefs.HasKey("success"))
            PlayerPrefs.SetInt("success", 0);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    // 펫 이름 변경 함수
    public void ChangeName()
    {
        txtName.text = PlayerPrefs.GetString("name");
    }

    // 낮밤 배경 이미지 변경 함수
    public void ChangeDayNighte()
    {
        nowTime = DateTime.Now;
        hh = nowTime.Hour;
        
        if (7 <= hh && hh <19)

        {
            // 낮이라면
            this.imgBG.GetComponent<SpriteRenderer>().sprite = this.img_day_bg;
            this.imgTable.GetComponent<SpriteRenderer>().sprite = this.img_day_table;
            this.btnFeed.GetComponent<Image>().sprite = this.img_day_feed;
            this.btnHarness.GetComponent<Image>().sprite = this.img_day_harness;

        }
        else
        {
            // 밤이라면
            this.imgBG.GetComponent<SpriteRenderer>().sprite = this.img_night_bg;
            this.imgTable.GetComponent<SpriteRenderer>().sprite = this.img_night_table;
            this.btnFeed.GetComponent<Image>().sprite = this.img_night_feed;
            this.btnHarness.GetComponent<Image>().sprite = this.img_night_harness;

        }

    }

}
