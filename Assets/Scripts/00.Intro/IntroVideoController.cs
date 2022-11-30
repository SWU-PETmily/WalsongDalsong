using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class IntroVideoController : MonoBehaviour
{
    //public GameObject canVideo1;
    //public GameObject canVideo2;
    //public GameObject canVideo3;
    public VideoPlayer video1;
    public VideoPlayer video2;
    public VideoPlayer video3;

    void Start()
    {

        //canVideo1.SetActive(true);
        //canVideo2.SetActive(false);
        //canVideo3.SetActive(false);


        //video1.url = Application.streamingAssetsPath + "/intro1.mp4";
        /*
        video1.url = "jar:file://" + Application.dataPath + "!/assets/intro1.mp4";;
        video2.url = Application.streamingAssetsPath + "/intro2.mp4";
        video3.url = Application.streamingAssetsPath + "/intro3.mp4";
        */
        video1.loopPointReached += CheckOver1;
    }

    void CheckOver1(UnityEngine.Video.VideoPlayer vp)
    {
        //canVideo1.SetActive(false);
        //canVideo2.SetActive(true);
        //canVideo3.SetActive(false);

        video1.Stop();
        video2.Play();
        video3.Stop();
        video2.loopPointReached += CheckOver2;
    }

    void CheckOver2(UnityEngine.Video.VideoPlayer vp)
    {
        //canVideo1.SetActive(false);
        //canVideo2.SetActive(false);
        //canVideo3.SetActive(true);

        video1.Stop();
        video2.Stop();
        video3.Play();
        video3.loopPointReached += CheckOver3;
    }

    void CheckOver3(UnityEngine.Video.VideoPlayer vp)
    {
        video3.Stop();
        Debug.Log("doneVideo");
        UnityEngine.SceneManagement.SceneManager.LoadScene("MomWaitingTutorialScene");
    }

    public void skipBtnClick()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MomWaitingTutorialScene");
    }
}
