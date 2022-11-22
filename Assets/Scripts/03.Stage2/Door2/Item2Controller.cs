using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Item2Controller : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public static Vector2 defaultposition;

    public bool isSnell = false;          // ���� Ȯ�� ����
    public bool isClothes = false;        // �� Ȯ�� ����

    bool isCollision = false;           // �浹Ȯ�� ����

    public void OnBeginDrag(PointerEventData eventData)
    {
        defaultposition = this.transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 currentPos = Input.mousePosition;
        this.transform.position = currentPos;
    }

    public void OnEndDrag(PointerEventData eventData)
    {

        if (isCollision)
        {
            // �浹�� �־��ٸ�
            this.transform.position = new Vector3(4000, 900, 0);
        }
        else
        {
            // �浹�� �����ٸ�
            this.transform.position = defaultposition;
        }
        
    }

    // �������� �浹 ��
    void OnTriggerEnter2D(Collider2D other)
    {
        // ���� ������Ʈ�� �����̶��
        if (this.CompareTag("snell"))
        {
            // �ε��� ��ü�� ���������
            if (other.CompareTag("pet"))
            {
                Debug.Log("���� ������ �ε���");
                isCollision = true;                            // ������ �����
                isSnell = true;                         // ���� Ȯ��
            }
        }
        // ���� ������Ʈ�� ���̶��
        else
        {
            // �ε��� ��ü�� ���������
            if (other.CompareTag("pet"))
            {
                Debug.Log("�� ������ �ε���");
                isCollision = true;                             // ������ �����
                isClothes = true;                         // �躯 ���� Ȯ��
            }
        }
        
    }



}
