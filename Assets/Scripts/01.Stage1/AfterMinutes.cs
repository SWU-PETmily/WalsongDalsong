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

    public GameObject dialogBox;
    public GameObject bgblack;
    public Text dialogText;
    public Button next;
    public Image gauge;
    public int t1;
    //public Animator anim;
    //public Animator anim2;

    DateTime dt1;
    DateTime dt2;

    void Start()
    {
        //bad.SetActive(false);
        //good.SetActive(false);
        gauge.fillAmount = 0.0f;
        dialogBox.SetActive(false);
        bgblack.SetActive(false);
        //gauge.enabled = (false);

        LetsCheckAgain();//시작시간 체크

        //anim.SetBool("IsAnxious", true);
        StartCoroutine(WaitForIt(3.0f));

    }

    IEnumerator WaitForIt(float time)
    {
        bool result = TimeSpans();
        if (result == true)
        {
            yield return new WaitForSeconds(3);
            gauge.fillAmount = 0.1f;
            PlayerPrefs.SetFloat("guage", 0.1f);
            Debug.Log(result);

            GuideLine();

            yield return new WaitForSeconds(10);
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
        int t1 = dt2.Minute - lasttime;

        Debug.Log("현재 분: " + dt2.Minute);
        Debug.Log("과거 분: " + lasttime);
        Debug.Log("시간 차: " + t1);

        // 절대값 계산
        if (t1 < 0){
            t1 = t1 * -1;
        }

        if (t1 >=30)
        {
            //gauge.enabled = (true);
            good.SetActive(true);
            return true;
        }

        bad.SetActive(true);
        return false;
    }

    private void GuideLine()
    {

        dialogBox.SetActive(true);
        bgblack.SetActive(true);


    }

    private void OnApplicationQuit()
    {
        print("종료");

        LetsCheck();//종료시간 체크
    }

    public void btnClick()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MomNamingTutorialScene");
    }


}
