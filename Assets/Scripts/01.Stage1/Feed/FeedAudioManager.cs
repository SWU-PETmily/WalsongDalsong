using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedAudioManager : MonoBehaviour
{
    AudioSource audioSource;
    public bool isFeedCollision;                // 사료알 충돌 확인 변수
    public bool isWaterCollision;               // 물 충돌 확인 변수
    public AudioClip audioFeed;                 // 사료 오디오클립
    public AudioClip audioWater;                // 물 오디오클립

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // 사료알 떨어짐 확인
        FeedController feedController = GameObject.Find("feedBag").GetComponent<FeedController>();
        isFeedCollision = feedController.isCollision;
        if (isFeedCollision)
        {
            audioSource.clip = audioFeed;
        }
    }
}
