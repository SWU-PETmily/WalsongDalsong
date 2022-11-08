using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class AutumnDirector : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // 씬 전환
        Invoke("ChangeScene", 5.0f);           // 장면 전환
    }

    // 장면 전환
    void ChangeScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Room2Scene");
    }
}
