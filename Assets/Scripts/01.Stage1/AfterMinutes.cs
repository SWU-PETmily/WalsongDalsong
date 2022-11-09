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

    int dt1;
    int dt2;

    void Start()
    {
        //bad.SetActive(false);
        //good.SetActive(false);
        gauge.fillAmount = 0.0f;
        dialogBox.SetActive(false);
        bgblack.SetActive(false);
        //gauge.enabled = (false);

        LetsCheckAgain();//���۽ð� üũ

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
        Debug.Log("���� �ð� : " + System.DateTime.Now.ToString());
        dt1 = int.Parse(System.DateTime.Now.ToString("HHmm"));
        PlayerPrefs.SetInt("lasttime", dt1);

    }

    private void LetsCheckAgain()
    {
        Debug.Log("����� �ð� : " + System.DateTime.Now.ToString());
        dt2 = int.Parse(System.DateTime.Now.ToString("HHmm"));

    }

    private bool TimeSpans()
    {
        int lasttime = PlayerPrefs.GetInt("lasttime");
        int t1 = dt2 - lasttime;

        Debug.Log("���� �ð� " + dt2);
        Debug.Log("���� �ð�: " + lasttime);
        Debug.Log("�ð� ��: " + t1);

        // ���밪 ���
        if (t1 < 0){
            t1 = t1 * -1;
        }

        // ������ �� 30���� �����ٸ�
        if (t1 >=30)
        {
            // ó�� ������ �ƴ϶��
            if(lasttime != -1)
            {
                good.SetActive(true);
                return true;
            }
        }

        bad.SetActive(true);
        return false;
    }

    private void GuideLine()
    {

        dialogBox.SetActive(true);
        bgblack.SetActive(true);


    }

    private void OnApplicationPause()
    {
        PlayerPrefs.SetString("quitSceneName", "CalmingSignal");   // ����� ����
        print("����");
        LetsCheck();//����ð� üũ
    }

    public void btnClick()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MomNamingTutorialScene");
    }


}
