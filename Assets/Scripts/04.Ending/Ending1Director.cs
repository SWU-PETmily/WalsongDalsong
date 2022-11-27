using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.Video;

public class Ending1Director : MonoBehaviour
{
    public VideoPlayer video1;

    void Start()
    {
        video1.loopPointReached += CheckOver1;

    }

    void CheckOver1(UnityEngine.Video.VideoPlayer vp)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("LogoScene");
    }
}
