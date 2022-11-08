using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class WaterController : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public GameObject bg;           // ���
    public GameObject btnDog;        // ��������ư
    public static Vector2 defaultposition;
    public Sprite closeWater;         // ���� ���� �̹���
    public Sprite openWater;          // ���� ���� �̹���
    public Sprite imgShadowY;         // ��� �׸��� �ִ� �̹���(��)
    public Sprite imgShadowN;         // ��� �׸��� ���� �̹���(��)
    private Animator WateringAnimator;
    public Animator BowlWaterAnimatior;

    Vector3 destination = new Vector3(1800, 970, 0);         // ���� �̵� ��ġ

    bool isFeeding = false;             // ��� �Ϸ� Ȯ�� ����
    bool isCollision = false;           // �浹Ȯ�� ����

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (isFeeding)
        {
            // ��� ������ �Ϸ��ߴٸ�
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
                bg.GetComponent<SpriteRenderer>().sprite = imgShadowN;         // ��� �׸��� ���ֱ�

            }
        }

    }

    public void OnDrag(PointerEventData eventData)
    {
        if (isFeeding)
        {
            // ��� ������ �Ϸ��ߴٸ�
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
                bg.GetComponent<SpriteRenderer>().sprite = imgShadowN;         // ��� �׸��� ���ֱ�

            }
        }
       
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (isFeeding)
        {
            // ��� ������ �Ϸ��ߴٸ�
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
                bg.GetComponent<SpriteRenderer>().sprite = imgShadowY;         // ��� �׸��� ���ֱ�

            }
        }
    }

    // �� �׸��� �浹 ��
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("bowl"))
        {
            Debug.Log("collision!!!");
            isCollision = true;
            WateringAnimator.SetBool("isWater", true);    // ���� �ִϸ����� ����
            BowlWaterAnimatior.SetBool("isBowlWater", true);      // ���׸� �ִϸ����� ����
            bg.GetComponent<SpriteRenderer>().sprite = imgShadowN;         // ��� �׸��� ���ֱ�

            Invoke("ButtonActive", 4.0f);           // ��ư Ȱ��ȭ
            Destroy(gameObject, 4);                 // ���� ����
        }
    }

    // ������ ��ư Ȱ��ȭ
    void ButtonActive()
    {
        btnDog.SetActive(true);
        PlayerPrefs.SetInt("feedLevel", 3);
    }

    // Start is called before the first frame update
    void Start()
    {
        WateringAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // ��� ���ް� �׸� ġ��⸦ �Ϸ��ߴٸ�
        if (PlayerPrefs.GetInt("feedLevel") == 2)
        {
            isFeeding = true;
        }
    }
}
