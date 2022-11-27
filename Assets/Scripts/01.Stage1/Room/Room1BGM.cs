using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Room1BGM : MonoBehaviour
{
    // public Room1BGM obj;

    void Update()
    {
        Scene scene = UnityEngine.SceneManagement.SceneManager.GetActiveScene();
        if (!(scene.name == "Room1Scene" || scene.name == "Door1Scene" || scene.name == "Card1Scene" || scene.name == "FeedNoScene" || scene.name == "Parent1Scene"))
        {
            // �Ļ�޼�, ��Һ�, ��ġ ���̶�� ������ �����
            Destroy(gameObject);
        }
    }

    private void Awake()
    {
        var obj = FindObjectsOfType<Room1BGM>();
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
