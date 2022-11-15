using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class PuppyNewDayNight : MonoBehaviour
{
    public DateTime nowTime;
    public int hh;
    public GameObject dayPuppy;
    public GameObject nightPuppy;

    void Start()
    {
        ChangeDayNighte();          // ³·¹ã °­¾ÆÁö º¯°æ
    }

    // ³·¹ã ¹è°æ ÀÌ¹ÌÁö º¯°æ ÇÔ¼ö
    public void ChangeDayNighte()
    {
        nowTime = DateTime.Now;
        hh = nowTime.Hour;

        if (7 <= hh && hh < 19)

        {
            // ³·ÀÌ¶ó¸é
            dayPuppy.SetActive(true);         // ³· °­¾ÆÁö º¸ÀÌ±â
            nightPuppy.SetActive(false);      // ¹ã °­¾ÆÁö ¼û±â±â
        }
        else
        {
            // ¹ãÀÌ¶ó¸é
            dayPuppy.SetActive(false);         // ³· °­¾ÆÁö ¼û±â±â
            nightPuppy.SetActive(true);        // ¹ã °­¾ÆÁö º¸ÀÌ±â
        }

    }
}
