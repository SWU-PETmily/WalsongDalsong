using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AfterMinutes : MonoBehaviour
{
    public GameObject bad;
    public GameObject good;
    public GameObject mom;
    
    public GameObject text1;
    public GameObject text2;
    public GameObject next;
    public Image gauge;
    public int t1;

    
    DateTime dt1;
    DateTime dt2;


    void Start()
    {
        bad.SetActive(true);
        good.SetActive(false);
        mom.SetActive(false);
        
        text1.SetActive(false);
        text2.SetActive(false);
        next.SetActive(false);
        gauge.enabled = (false);

        LetsCheckAgain();//시작시간 체크

        StartCoroutine(WaitForIt(3.0f));

    }


    void Update()
    {

        

    }
    IEnumerator WaitForIt(float time)
    {


        bool result = TimeSpans();
        if (result == true)
        {
            yield return new WaitForSeconds(2);
            Debug.Log(result);

            GuideLine();

            yield return new WaitForSeconds(1);
            NextGuideLine();
            yield return new WaitForSeconds(1);
            Final();
            yield return new WaitForSeconds(1);
            SceneManager.LoadScene("MomNamingTutorialScene");
        }
        else
        {
            Debug.Log("s");
        }
       
    }


    private void LetsCheck()
    {
        Debug.Log("종료 시간 : " + System.DateTime.Now.ToString());
        dt1 = System.DateTime.Now;
        PlayerPrefs.SetInt("lasttime", dt1.Minute);

    }

    private void LetsCheckAgain()
    {
        Debug.Log("재시작 시간 : " + System.DateTime.Now.ToString());
        dt2 = System.DateTime.Now;
       
    }

    private bool TimeSpans()
    {
        int lasttime = PlayerPrefs.GetInt("lasttime");
         int t1= dt2.Minute - lasttime;
        Debug.Log(dt2.Minute);
        Debug.Log(lasttime);
        if (t1 >= 1)
        {
            bad.SetActive(false);
            good.SetActive(true);
            gauge.fillAmount = 0.3f;

            return true;
        }

        return false;
    }

    private void GuideLine()
    {
        mom.SetActive(true);
        
        text1.SetActive(true);
        Debug.Log("gogo");

    }

    private void NextGuideLine()
    {
        text1.SetActive(false);
        text2.SetActive(true);


    }
    private void Final()
    {
        next.SetActive(true);
    }

    private void OnApplicationQuit()
    {
        LetsCheck();//종료시간 체크
    }

    
}
