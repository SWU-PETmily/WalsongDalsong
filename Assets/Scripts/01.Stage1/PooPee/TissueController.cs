using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TissueController : MonoBehaviour
{

    public GameObject tissue;           // Ƽ�� �� ��
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

    // Ƽ���ڽ� ��ġ �� Ƽ�� ����
    void ActiveTissue()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //ȭ���� ��ǥ�踦 ���� ��ǥ��� ��ȯ���ִ� �Լ�
            Vector2 tissueBox = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(tissueBox, Vector2.zero);

            if (hit.collider != null)
            {
                Debug.Log(hit.collider.gameObject.name);
                string touchObject = hit.collider.gameObject.name;      // ��ġ�� ������Ʈ��

                if (touchObject == "img_tissue_pre")
                {
                    // �躯�� ��ġ�ߴٸ�
                    tissue.SetActive(true);
                    tissueBoxTouch = true;

                }

            }
        }
    }
}
