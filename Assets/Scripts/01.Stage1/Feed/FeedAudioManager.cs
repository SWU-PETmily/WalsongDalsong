using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedAudioManager : MonoBehaviour
{
    AudioSource audioSource;
    public bool isFeedCollision;                // ���� �浹 Ȯ�� ����
    public bool isWaterCollision;               // �� �浹 Ȯ�� ����
    public AudioClip audioFeed;                 // ��� �����Ŭ��
    public AudioClip audioWater;                // �� �����Ŭ��

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // ���� ������ Ȯ��
        FeedController feedController = GameObject.Find("feedBag").GetComponent<FeedController>();
        isFeedCollision = feedController.isCollision;
        if (isFeedCollision)
        {
            audioSource.clip = audioFeed;
        }
    }
}
