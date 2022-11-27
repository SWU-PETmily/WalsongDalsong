using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    void Start()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    void Update()
    {
        if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Room1Scene")
        {
            Destroy(gameObject);
        }
    }
}
