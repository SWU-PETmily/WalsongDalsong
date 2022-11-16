using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TissueBoxController : MonoBehaviour
{
    public GameObject tissue;           // 티슈 한 장
    bool tissueBoxTouch = false;

    // Update is called once per frame
    void Update()
    {
        if(tissueBoxTouch == false)
        {
            ActiveTissue();
        }
        
    }

    public void ClickTissue()
    {
        tissue.SetActive(true);
    }

    // 티슈박스 터치 시 티슈 생성
    void ActiveTissue()
    {
        if (Input.GetMouseButtonDown(0))
        {

            //화면의 좌표계를 월드 좌표계로 전환해주는 함수
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(touchPos, Camera.main.transform.forward);

            if (hit.collider != null)
            {
                Debug.Log(hit.collider.gameObject.name);
                string touchObject = hit.collider.gameObject.name;      // 터치된 오브젝트명

                Debug.Log(touchObject);

                if (touchObject == "tissueBox" || touchObject == "tissueBox1" || touchObject == "tissueBox2")
                {
                    // 배변을 터치했다면
                    tissue.SetActive(true);
                    tissueBoxTouch = true;

                }

            }
        }
    }
}
