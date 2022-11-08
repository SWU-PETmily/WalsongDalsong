using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class TissueController : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public static Vector2 defaultposition;

    bool left = true;
    int touchNum = 0;       // 드래그 횟수 카운트
    int totalNum = 5;       // 드래그 총 횟수 

    public GameObject water;
    public GameObject stain;
    public GameObject tissueBox;


    // Update is called once per frame
    void Update()
    {
        // 충돌 판정
        Vector3 t1 = transform.position;                // 티슈 중심 좌표

        // 왼쪽에 닿으면
        if(t1.x <= 1200.0f && (t1.y >= 476.0f || t1.y <= 1000.0f) && left==true)
        {
            left = false;
            touchNum++;
        }

        // 오른쪽에 닿으면
        if (t1.x >= 1800.0f && (t1.y >= 476.0f || t1.y <= 1000.0f) && left == false)
        {
            left = true;
            touchNum++;
        }

        if(touchNum >= totalNum)
        {
            // 게임오브젝트 삭제
            Destroy(gameObject);
            Destroy(water);
            Destroy(stain);
            Destroy(tissueBox);

            // 하루 배변 치우기 횟수 증가
            int num = PlayerPrefs.GetInt("pooCleaningNum")+1;
            PlayerPrefs.SetInt("pooCleaningNum", num);
            // 미션 성공 알림
            PlayerPrefs.SetInt("successPooPeeClean", 1);
            // 씬 전환
            UnityEngine.SceneManagement.SceneManager.LoadScene("Room1Scene");
        }

    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        defaultposition = this.transform.position;
        stain.SetActive(true);      // 얼룩 보이기
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 currentPos = Input.mousePosition;
        this.transform.position = currentPos;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        this.transform.position = defaultposition;
    }


}
