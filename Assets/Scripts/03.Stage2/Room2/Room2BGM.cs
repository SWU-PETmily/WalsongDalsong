using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Room2BGM : MonoBehaviour
{
    void Update()
    {
        Scene scene = UnityEngine.SceneManagement.SceneManager.GetActiveScene();
        if (!(scene.name == "Room2Scene" || scene.name == "Door2Scene" || scene.name == "Card2Scene" || scene.name == "FeedNoScene" || scene.name == "Parent2Scene"))
        {
            // 식사급수, 대소변, 터치 씬이라면 비지엠 끊기기
            Destroy(gameObject);
        }
    }

    private void Awake()
    {
        var obj = FindObjectsOfType<Room2BGM>();
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
