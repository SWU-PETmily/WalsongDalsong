using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PooController : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public static Vector2 defaultposition;
    public GameObject trashCan;
    public GameObject spray;
    public GameObject stain;

    // �ٲ� �̹���
    public Sprite img_garbage_open;
    public Sprite img_garbage;

    void Start()
    {
        spray.SetActive(false);
    }

    void Update()
    {
        // �浹 ����
        Vector2 p1 = transform.position;                // �躯 �߽� ��ǥ
        Vector2 p2 = trashCan.transform.position;  // �������� �߽� ��ǥ
        Vector2 dir = p1 - p2;
        float d = dir.magnitude;
        float r1 = 1.0f;                                // �躯 �ݰ�
        float r2 = 1.2f;                                // �������� �߽� �ݰ�

        if (d < r1 + r2 + 500.0f)
        {
            // �������� ����
            this.trashCan.GetComponent<Image>().sprite = this.img_garbage_open;
        }
        else
        {
            // �������� �ݱ�
            this.trashCan.GetComponent<Image>().sprite = this.img_garbage;
        }

        if (d < r1 + r2+150.0f)
        {
            // �浹 �� �躯 ����
            Destroy(gameObject);
            this.trashCan.GetComponent<Image>().sprite = this.img_garbage;
            Destroy(this.trashCan.GetComponent<Image>());
            spray.SetActive(true);

        }

    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        defaultposition = this.transform.position;
        stain.SetActive(true);      // ��� ���̱�
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
