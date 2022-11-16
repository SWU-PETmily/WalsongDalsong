using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TissueBoxController : MonoBehaviour
{
    public GameObject tissue;           // Ƽ�� �� ��
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

    // Ƽ���ڽ� ��ġ �� Ƽ�� ����
    void ActiveTissue()
    {
        if (Input.GetMouseButtonDown(0))
        {

            //ȭ���� ��ǥ�踦 ���� ��ǥ��� ��ȯ���ִ� �Լ�
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(touchPos, Camera.main.transform.forward);

            if (hit.collider != null)
            {
                Debug.Log(hit.collider.gameObject.name);
                string touchObject = hit.collider.gameObject.name;      // ��ġ�� ������Ʈ��

                Debug.Log(touchObject);

                if (touchObject == "tissueBox" || touchObject == "tissueBox1" || touchObject == "tissueBox2")
                {
                    // �躯�� ��ġ�ߴٸ�
                    tissue.SetActive(true);
                    tissueBoxTouch = true;

                }

            }
        }
    }
}
