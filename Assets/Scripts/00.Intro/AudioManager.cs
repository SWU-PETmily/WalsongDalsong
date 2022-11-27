using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    // Start is called before the first frame update
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
