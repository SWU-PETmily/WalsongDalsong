using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class WaterController : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public GameObject btnDog;        // ��������ư
    public static Vector2 defaultposition;
    public Sprite closeWater;         // ���� ���� �̹���
    public Sprite openWater;          // ���� ���� �̹���
    private Animator FeedingAnimator;
    public Animator BowlWaterAnimatior;

    Vector3 destination = new Vector3(518, 900, 0);         // ���� �̵� ��ġ


    bool isCollision = false;           // �浹Ȯ�� ����

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (isCollision)
        {
            // �浹�� �־��ٸ�
            this.transform.position = destination;      // ���� ��ġ ����
        }
        else
        {
            // �浹�� �����ٸ�
            defaultposition = this.transform.position;
            this.GetComponent<Image>().sprite = openWater;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (isCollision)
        {
            // �浹�� �־��ٸ�
            this.transform.position = destination;      // ���� ��ġ ����
        }
        else
        {
            // �浹�� �����ٸ�
            Vector2 currentPos = Input.mousePosition;
            this.transform.position = currentPos;
            this.GetComponent<Image>().sprite = openWater;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (isCollision)
        {
            // �浹�� �־��ٸ�
            this.transform.position = destination;      // ���� ��ġ ����
        }
        else
        {
            // �浹�� �����ٸ�
            this.transform.position = defaultposition;
            this.GetComponent<Image>().sprite = closeWater;
        }
    }

    // �� �׸��� �浹 ��
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("bowl"))
        {
            Debug.Log("collision!!!");
            isCollision = true;
            //FeedingAnimator.SetBool("isWater", true);    // ������ �ִϸ����� ����
            //feed1.SetActive(true);      // ���1 ��������
            //feed2.SetActive(true);      // ���2 ��������
            //BowlAnimatior.SetBool("isBowlWater", true);      // ��׸� �ִϸ����� ����

            //Invoke("ButtonActive", 4.0f);           // ��ư Ȱ��ȭ
            //Destroy(gameObject, 4);                 // ��� ���� ����
            //Destroy(feed1, 4);                      // ���1 ����
            //Destroy(feed2, 4);                      // ���2 ����
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
