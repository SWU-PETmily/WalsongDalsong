using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PooController : MonoBehaviour
{

    GameObject trashCan;
    public GameObject spray;

    // �ٲ� �̹���
    public Sprite img_garbage_open;
    public Sprite img_garbage;

    void Start()
    {
        this.trashCan = GameObject.Find("trashCan");
        spray.SetActive(false);
    }

    void Update()
    {
        // �浹 ����
        Vector2 p1 = transform.position;                // �躯 �߽� ��ǥ
        Vector2 p2 = this.trashCan.transform.position;  // �������� �߽� ��ǥ
        Vector2 dir = p1 - p2;
        float d = dir.magnitude;
        float r1 = 0.8f;                                // �躯 �ݰ�
        float r2 = 1.2f;                                // �������� �߽� �ݰ�


        if (d < r1 + r2 + 1.9f)
        {
            // �������� ����
            this.trashCan.GetComponent<SpriteRenderer>().sprite = this.img_garbage_open;
        }
        else
        {
            // �������� �ݱ�
            this.trashCan.GetComponent<SpriteRenderer>().sprite = this.img_garbage;
        }

        if (d < r1 + r2)
        {
            // �浹 �� �躯 ����
            Destroy(gameObject);
            this.trashCan.GetComponent<SpriteRenderer>().sprite = this.img_garbage;
            Destroy(this.trashCan.GetComponent<SpriteRenderer>());
            spray.SetActive(true);

        }

    }
}
