using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SprayController : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public static Vector2 defaultposition;
    GameObject stain;
    public GameObject water;
    public GameObject tissue;
    public GameObject posSpray;       // �������� �̵� ��ġ

    // �ٲ� �̹���
    public Sprite img_spray_ing;
    public Sprite img_spray;
    public Sprite img_water;

    Vector2 fp1;
    Vector2 fp2;
    float d2 = 0.0f;
    bool actSpray = false;

    private Animator animator;
    Vector3 rotation = new Vector3(0, 0, 40);         // ��������  ����
    bool isCollision = false;                    // �浹 Ȯ�� ����

    // Start is called before the first frame update
    void Start()
    {
        this.stain = GameObject.Find("stain1");

        // �ִϸ�����
        this.animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // �浹 ����
        Vector2 p1 = transform.position;                // �������� �߽� ��ǥ
        Vector2 p2 = this.stain.transform.position;  // ��� �߽� ��ǥ
        Vector2 dir = p1 - p2;
        float d = dir.magnitude;
        float r1 = 1.5f;                                // �������� �ݰ�
        float r2 = 1.2f;                                // ��� �߽� �ݰ�


        if (d < r1 + r2+300.0f)
        {
            isCollision = true;
            this.transform.position = posSpray.transform.position;       //�������� �̵�
            this.transform.localEulerAngles = rotation;        //�������� ����̱�
            this.animator.SetTrigger("SprayTrigger");          // �ִϸ��̼� ����
            water.SetActive(true);      //����� ���̱�
            Invoke("Water", 1.0f);

        }

        if(actSpray == true)
        {
            Invoke("Tissue", 1.9f);
        }

    }

    void Water()
    {
        water.GetComponent<Image>().sprite = this.img_water;       // ����� �� ���̱�
        actSpray = true;
        Destroy(gameObject, 2);                 // �������� ����
    }

    void Tissue()
    {
        tissue.SetActive(true);      // Ƽ�� ���̱�
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!isCollision)
        {
            defaultposition = this.transform.position;
        }

    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!isCollision)
        {
            Vector2 currentPos = Input.mousePosition;
            this.transform.position = currentPos;
        }

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!isCollision)
        {
            this.transform.position = defaultposition;
        }

    }
}
