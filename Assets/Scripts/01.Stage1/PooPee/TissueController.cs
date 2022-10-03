using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TissueController : MonoBehaviour
{

    public GameObject tissue;           // 티슈 한 장
    bool tissueBoxTouch = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(tissueBoxTouch == false)
        {
            ActiveTissue();
        }
        
    }

    // 티슈박스 터치 시 티슈 생성
    void ActiveTissue()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //화면의 좌표계를 월드 좌표계로 전환해주는 함수
            Vector2 tissueBox = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(tissueBox, Vector2.zero);

            if (hit.collider != null)
            {
                Debug.Log(hit.collider.gameObject.name);
                string touchObject = hit.collider.gameObject.name;      // 터치된 오브젝트명

                if (touchObject == "img_tissue_pre")
                {
                    // 배변을 터치했다면
                    tissue.SetActive(true);
                    tissueBoxTouch = true;

                }

            }
        }
    }
}
