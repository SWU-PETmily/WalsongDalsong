using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemController : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public static Vector2 defaultposition;
    public bool isCollision = false;           // �浹Ȯ�� ����
    public Animator petAnimator;
    public bool isDay;

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
        if (other.CompareTag("pet"))
        {
            Debug.Log("collision");
            //this.audioSource.Play();                                    //����� ����
            isCollision = true;
            // ���� Ȯ�� �� �ִϸ��̼� ����
            Door1TimeManager timeManager = GameObject.Find("TimeManager").GetComponent<Door1TimeManager>();
            isDay = timeManager.isDay;
            if (isDay)
            {
                Destroy(gameObject);
                petAnimator.SetTrigger("isDaySnell");    // �� ���� �ִϸ��̼� ����
            }
            else
            {
                Destroy(gameObject);
                petAnimator.SetTrigger("iNightSnell");    // �� ���� �ִϸ��̼� ����
            }
            
        }
    }
}
