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
        // �� ��ȯ
        Invoke("ChangeScene", 5.0f);           // ��� ��ȯ
    }

    // ��� ��ȯ
    void ChangeScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Room2Scene");
    }
}
