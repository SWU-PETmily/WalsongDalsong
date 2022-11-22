using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Poo2Controller : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public static Vector2 defaultposition;
    public GameObject trashCan1;
    public GameObject trashCan2;
    AudioSource audioSource;                                        //������ҽ�

    // �ٲ� �̹���
    public Sprite img_garbage_open;
    public Sprite img_garbage;

    void Start()
    {
        trashCan2.SetActive(false);
        audioSource = this.gameObject.GetComponent<AudioSource>();   //������ҽ�
    }

    void Update()
    {
        // �浹 ����
        Vector2 p1 = transform.position;                // �躯 �߽� ��ǥ
        Vector2 p2 = trashCan1.transform.position;  // �������� �߽� ��ǥ
        Vector2 dir = p1 - p2;
        float d = dir.magnitude;
        float r1 = 1.0f;                                // �躯 �ݰ�
        float r2 = 1.2f;                                // �������� �߽� �ݰ�

        if (d < r1 + r2 + 500.0f)
        {
            // �������� ����
            StartCoroutine(StartAudio());
            this.trashCan1.GetComponent<Image>().sprite = this.img_garbage_open;
        }
        else
        {
            // �������� �ݱ�
            this.trashCan1.GetComponent<Image>().sprite = this.img_garbage;
        }

        if (d < r1 + r2 + 150.0f)
        {
            // �浹 �� �躯 ����
            this.audioSource.Play();                                    //����� ����
            Destroy(gameObject);
            this.trashCan1.GetComponent<Image>().sprite = this.img_garbage;
            Destroy(this.trashCan1.GetComponent<Image>());
            trashCan2.SetActive(true);

        }

    }

    IEnumerator StartAudio()
    {
        this.audioSource.Play();                                    //����� ����
        yield return new WaitForSeconds(3);
    }

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
}
