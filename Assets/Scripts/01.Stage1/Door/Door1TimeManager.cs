using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Door1TimeManager : MonoBehaviour
{
    public DateTime nowTime;
    public int hh;

    // ³·¹ã ¹Ù²ð ¹è°æ ¿ä¼Ò
    public GameObject background;
    public GameObject pet;

    // ¹Ù²Ü ÀÌ¹ÌÁö
    public Sprite img_day_bg;
    public Sprite img_night_bg;

    // Start is called before the first frame update
    void Start()
    {
        ChangeDayNighte();          // ³·¹ã º¯°æ
    }

    // ³·¹ã ¹è°æ ÀÌ¹ÌÁö º¯°æ ÇÔ¼ö
    public void ChangeDayNighte()
    {
        nowTime = DateTime.Now;
        hh = nowTime.Hour;

        if (7 <= hh && hh < 19)

        {
            // ³·ÀÌ¶ó¸é
            this.background.GetComponent<SpriteRenderer>().sprite = this.img_day_bg;
        }
        else
        {
            // ¹ãÀÌ¶ó¸é
            this.background.GetComponent<SpriteRenderer>().sprite = this.img_night_bg;
        }

    }
}
