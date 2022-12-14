using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeeTissue1Controller : MonoBehaviour
{
    bool left = true;
    int touchNum = 0;       // 드래그 횟수 카운트
    int totalNum = 7;       // 드래그 총 횟수 

    public GameObject stain;
    public GameObject tissueBox;
    public GameObject spray;
    AudioSource audioSource;                                        //오디오소스
    public AudioClip audioErase;                            //닦는 소리 오디오 클립

    void Start()
    {
        audioSource = this.gameObject.GetComponent<AudioSource>();   //오디오소스
    }

    void Update()
    {
        // 충돌 판정
        Vector3 t1 = transform.position;                // 티슈 중심 좌표

        // 왼쪽에 닿으면
        if (t1.x <= -1 && (t1.y >= -1.55f || t1.y <= 1.8f) && left == true)
        {
            audioSource.clip = audioErase;
            this.audioSource.Play();                                    //오디오 실행
            left = false;
            touchNum++;
        }

        // 왼쪽에 닿으면
        if (t1.x >= 1.6f && (t1.y >= -1.55f || t1.y <= 1.8f) && left == false)
        {
            left = true;
            touchNum++;
        }

        if (touchNum >= totalNum)
        {
            // 게임오브젝트 삭제
            Destroy(gameObject);
            Destroy(stain);
            Destroy(tissueBox);

            // 스프레이 생성
            spray.SetActive(true);

        }

    }
}
