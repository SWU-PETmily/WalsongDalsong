using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FeedController : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public GameObject bg;           // ���
    public GameObject feed1;        // ����1
    public GameObject feed2;        // ����2
    public GameObject btnDog;        // ��������ư
    public GameObject bowlWater;     // ���׸�
    public static Vector2 defaultposition;
    public Sprite closeBag;         // ���� ������ �̹���
    public Sprite openBag;          // ���� ������ �̹���
    public Sprite imgShadowY;         // ��� �׸��� �ִ� �̹���(���)
    public Sprite imgShadowN;         // ��� �׸��� ���� �̹���(���)
    private Animator FeedingAnimator;
    public Animator BowlAnimatior;
    Vector3 destination = new Vector3(1000, 900, 0);         // ������ �̵� ��ġ
    Vector3 rotationStop = new Vector3(0, 0, 0);         // 0��
    Vector3 rotationMove = new Vector3(0, 0, -40);         // 40��

    bool isCollision = false;           // �浹Ȯ�� ����

    void Start()
    {
        FeedingAnimator = GetComponent<Animator>();
        feed1.SetActive(false);
        feed2.SetActive(false);
        btnDog.SetActive(false);
        bowlWater.SetActive(false);
        PlayerPrefs.SetInt("feedLevel", 0);     // �Ļ� �޼� �� �ܰ� ����. 0=�ƹ��͵� �� ��. 1=�Ļ����޿Ϸ�, 2=�Ļ� ġ���. 3=�����޿Ϸ�
    }

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
            this.GetComponent<Image>().sprite = openBag;
            bg.GetComponent<SpriteRenderer>().sprite = imgShadowN;         // ��� �׸��� ���ֱ�
            this.transform.localEulerAngles = rotationMove;     // ���� ����̱�
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
            this.GetComponent<Image>().sprite = openBag;
            bg.GetComponent<SpriteRenderer>().sprite = imgShadowN;         // ��� �׸��� ���ֱ�
            this.transform.localEulerAngles = rotationMove;    // ���� ����̱�
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
            this.GetComponent<Image>().sprite = closeBag;
            bg.GetComponent<SpriteRenderer>().sprite = imgShadowY;         // ��� �׸��� �����
            this.transform.localEulerAngles = rotationStop;     // ���� �ٷ� �����
        }
    }

    // �� �׸��� �浹 ��
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("bowl"))
        {
            Debug.Log("collision!!!");
            isCollision = true;
            FeedingAnimator.SetBool("isFeed", true);    // ������ �ִϸ����� ����
            feed1.SetActive(true);      // ���1 ��������
            feed2.SetActive(true);      // ���2 ��������
            BowlAnimatior.SetBool("isBowl", true);      // ��׸� �ִϸ����� ����
            bg.GetComponent<SpriteRenderer>().sprite = imgShadowN;         // ��� �׸��� ���ֱ�

            Invoke("ButtonActive", 4.0f);           // ��ư Ȱ��ȭ
            Destroy(gameObject, 4);                 // ��� ���� ����
            Destroy(feed1, 4);                      // ���1 ����
            Destroy(feed2, 4);                      // ���2 ����
        }
    }

    // ������ ��ư Ȱ��ȭ
    void ButtonActive()
    {
        btnDog.SetActive(true);
        PlayerPrefs.SetInt("feedLevel", 1);
    }


}
