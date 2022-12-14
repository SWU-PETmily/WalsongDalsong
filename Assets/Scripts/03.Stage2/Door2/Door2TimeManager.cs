using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Door2TimeManager : MonoBehaviour
{
    public DateTime nowTime;
    public int hh;

    // ???? ?ٲ? ???? ????
    public GameObject background;
    public GameObject pet;

    // ?ٲ? ?̹???
    public Sprite img_day_bg;
    public Sprite img_night_bg;
    public Sprite img_day_pet;
    public Sprite img_night_pet;

    public bool isDay;          // ?? Ȯ?? ????

    void Start()
    {
        ChangeDayNighte();          // ???? ????
    }

    // ???? ???? ?̹??? ???? ?Լ?
    public void ChangeDayNighte()
    {
        nowTime = DateTime.Now;
        hh = nowTime.Hour;

        if (7 <= hh && hh < 19)

        {
            // ???̶???
            this.background.GetComponent<SpriteRenderer>().sprite = this.img_day_bg;
            this.pet.GetComponent<Image>().sprite = this.img_day_pet;
            isDay = true;
        }
        else
        {
            // ???̶???
            this.background.GetComponent<SpriteRenderer>().sprite = this.img_night_bg;
            this.pet.GetComponent<Image>().sprite = this.img_night_pet;
            isDay = false;
        }

    }
}
