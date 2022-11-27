using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    void Update()
    {
        if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Room1Scene")
        {
            Destroy(gameObject);
        }
    }

    private void Awake()
    {
        var obj = FindObjectsOfType<AudioManager>();
        if (obj.Length == 1)
        {
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
