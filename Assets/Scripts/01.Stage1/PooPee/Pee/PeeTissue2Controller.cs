using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeeTissue2Controller : MonoBehaviour
{
    bool left = true;
    int touchNum = 0;       // 드래그 횟수 카운트
    int totalNum = 7;       // 드래그 총 횟수 

    public GameObject water;
    public GameObject stain;
    public GameObject tissueBox;

    // Update is called once per frame
    void Update()
    {
        // 충돌 판정
        Vector3 t1 = transform.position;                // 티슈 중심 좌표

        // 왼쪽에 닿으면
        if (t1.x <= -1 && (t1.y >= -1.55f || t1.y <= 1.8f) && left == true)
        {
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
            Destroy(water);
            Destroy(stain);
            Destroy(tissueBox);

            // 하루 배변 치우기 횟수 증가
            int num = PlayerPrefs.GetInt("peeCleaningNum") + 1;
            PlayerPrefs.SetInt("peeCleaningNum", num);
            // 미션 성공 알림
            PlayerPrefs.SetInt("successPooPeeClean", 1);
            // 씬 전환
            UnityEngine.SceneManagement.SceneManager.LoadScene("Room1Scene");

        }
    }
}
