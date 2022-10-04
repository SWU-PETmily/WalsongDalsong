using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeeSprayController : MonoBehaviour
{
    public GameObject stain;
    public GameObject water;
    public GameObject tissueBox2;

    private Animator animator;
    Vector3 destination = new Vector3(6, 2, 0);         // �������� �̵� ��ġ
    Vector3 rotation = new Vector3(0, 0, 40);         // ��������  ����

    bool actSpray = false;

    public Sprite img_water;

    // Start is called before the first frame update
    void Start()
    {
        // �ִϸ�����
        this.animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
     
        // �浹 �˻�
        CheckColiision();


    }

    void CheckColiision()
    {
        // �浹 ����
        Vector2 p1 = transform.position;                // �������� �߽� ��ǥ
        Vector2 p2 = this.stain.transform.position;  // ��� �߽� ��ǥ
        Vector2 dir = p1 - p2;
        float d = dir.magnitude;
        float r1 = 1.5f;                                // �������� �ݰ�
        float r2 = 1.8f;                                // ��� �߽� �ݰ�

        // �������̿� ����� �浹�� ���
        if (d < r1 + r2)
        {
            gameObject.transform.position=destination;        //�������� �̵�
            gameObject.transform.localEulerAngles = rotation;        //�������� ����̱�
            this.animator.SetTrigger("SprayTrigger");          // �ִϸ��̼� ����
            water.SetActive(true);      //����� ���̱�
            Invoke("Water", 1.9f);
            Invoke("Tissue", 3);
        }
    }

    
    void Water()
    {
        water.GetComponent<SpriteRenderer>().sprite = this.img_water;       // ����� �� ���̱�
        Destroy(gameObject, 1.3f);                 // �������� ����
    }

    void Tissue()
    {
        tissueBox2.SetActive(true);      // Ƽ�� ���̱�
    }
    
}
