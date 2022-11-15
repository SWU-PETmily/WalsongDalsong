using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Item2Controller : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public static Vector2 defaultposition;
    public GameObject pet;               // ������
    public Sprite imgDaySnell;           // ������ ���� ��
    public Sprite imgNightSnell;         // ������ ���� ��

    public bool isDay;                    // ���� Ȯ�� ����
    public bool isSnell = false;          // ���� Ȯ�� ����
    public bool isBag = false;          // �躯 ���� Ȯ�� ����

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
        this.transform.position = defaultposition;
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
                Debug.Log("���ٰ� ������ �ε���");
                // ���� Ȯ�� �� �̹��� ����
                Door2TimeManager door2TimeManager = GameObject.Find("TimeManager").GetComponent<Door2TimeManager>();
                isDay = door2TimeManager.isDay;

                // ���̶��
                if (isDay == true)
                {
                    pet.GetComponent<Image>().sprite = imgDaySnell;       // ������ �̹��� ����

                }
                // ���̶��
                else
                {
                    pet.GetComponent<Image>().sprite = imgNightSnell;       // ������ �̹��� ����
                }
                gameObject.SetActive(false);                     // ������ ����
                isSnell = true;                         // ���� Ȯ��
            }
        }
        // ���� ������Ʈ�� �躯 �������
        else
        {
            // �ε��� ��ü�� ���������
            if (other.CompareTag("pet"))
            {
                Debug.Log("�躯������ ������ �ε���");
                gameObject.SetActive(false);                      // ������ ����
                isBag = true;                         // �躯 ���� Ȯ��
            }
        }
        
    }
}
