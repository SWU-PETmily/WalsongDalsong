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

    // ���� �ٲ� ��� ���
    public GameObject imgBG;
    public GameObject imgTable;
    public Button btnFeed;
    public Button btnHarness;

    // �ٲ� �̹���
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
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    // �� �̸� ���� �Լ�
    public void ChangeName()
    {
        txtName.text = PlayerPrefs.GetString("name");
    }

    // ���� ��� �̹��� ���� �Լ�
    public void ChangeDayNighte()
    {
        nowTime = DateTime.Now;
        hh = nowTime.Hour;
        
        if (7 <= hh && hh <19)

        {
            // ���̶��
            this.imgBG.GetComponent<SpriteRenderer>().sprite = this.img_day_bg;
            this.imgTable.GetComponent<SpriteRenderer>().sprite = this.img_day_table;
            this.btnFeed.GetComponent<Image>().sprite = this.img_day_feed;
            this.btnHarness.GetComponent<Image>().sprite = this.img_day_harness;
        }
        else
        {
            // ���̶��
            this.imgBG.GetComponent<SpriteRenderer>().sprite = this.img_night_bg;
            this.imgTable.GetComponent<SpriteRenderer>().sprite = this.img_night_table;
            this.btnFeed.GetComponent<Image>().sprite = this.img_night_feed;
            this.btnHarness.GetComponent<Image>().sprite = this.img_night_harness;

            this.imgBG.GetComponent<SpriteRenderer>().sprite = this.img_day_bg;
            this.imgTable.GetComponent<SpriteRenderer>().sprite = this.img_day_table;
            this.btnFeed.GetComponent<Image>().sprite = this.img_day_feed;
            this.btnHarness.GetComponent<Image>().sprite = this.img_day_harness;
        }

    }

}
