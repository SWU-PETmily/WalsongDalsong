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
    public Button btnPad;
    public Button btnHarness;
    

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

    public void ChangeName()
    {
        txtName.text = PlayerPrefs.GetString("name");
    }

    public void ChangeDayNighte()
    {
        nowTime = DateTime.Now;
        hh = nowTime.Hour;
        
        if (7 <= hh && hh <19)

        {
            // ���̶��
        }
        else
        {
            // ���̶��
            // imgBG.sprite = Resources.Load<Sprite>("Editor/ImgSoruce/01.Stage1/ver_night/bg_livingroom_night.png") as Sprite;

        }

    }
}
