using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FeedController : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public static Vector2 defaultposition;
    public Sprite closeBag;
    public Sprite openBag;
    private Animator FeedingAnimator;
    Vector3 destination = new Vector3(1000, 900, 0);         // ������ �̵� ��ġ
    Vector3 rotationStop = new Vector3(0, 0, 0);         // 0��
    Vector3 rotationMove = new Vector3(0, 0, -40);         // 40��

    bool isCollision = false;

    void Start()
    {
        FeedingAnimator = GetComponent<Animator>();
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
            this.transform.localEulerAngles = rotationStop;     // ���� �ٷ� �����
        }
    }

    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("bowl"))
        {
            Debug.Log("collision!!!");
            isCollision = true;
            FeedingAnimator.SetBool("isFeed", true);
            //waterup.SetActive(true);
        }
    }
    

}
