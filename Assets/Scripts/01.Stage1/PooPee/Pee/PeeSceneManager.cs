using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PeeSceneManager : MonoBehaviour
{
    public GameObject spray;
    public GameObject tissueBox2;
    public GameObject water;
    public GameObject tissue1;
    public GameObject tissue2;

    // Start is called before the first frame update
    void Start()
    {
        spray.SetActive(false);
        tissueBox2.SetActive(false);
        water.SetActive(false);
        tissue1.SetActive(false);
        tissue2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void BtnBack()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Room1Scene");
    }

    // 종료시 실행
    private void OnApplicationQuit()
    {
        QuitDateCheck(); //종료날짜시간 체크
    }

    // 종료 날짜 시간 체크
    private void QuitDateCheck()
    {
        int quitDate = int.Parse(System.DateTime.Now.ToString("yyyyMMdd"));
        int quitTime = int.Parse(System.DateTime.Now.ToString("HHmm"));

        Debug.Log("종료 날짜 : " + quitDate);
        Debug.Log("종료 시간 : " + quitTime);

        PlayerPrefs.SetInt("quitDate", quitDate);
        PlayerPrefs.SetInt("quitTime", quitTime);

    }
}
