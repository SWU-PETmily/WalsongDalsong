using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprayController : MonoBehaviour
{

    GameObject stain;
    public GameObject water;
    public GameObject tissue;

    // �ٲ� �̹���
    public Sprite img_spray_ing;
    public Sprite img_spray;
    public Sprite img_water;

    Vector2 fp1;
    Vector2 fp2;
    float d2 = 0.0f;
    bool actSpray = false;

    private Animator animator;
    Vector3 destination = new Vector3(2, -1, 0);         // �������� �̵� ��ġ
    Vector3 rotation = new Vector3(0, 0, 40);         // ��������  ����

    // Start is called before the first frame update
    void Start()
    {
        this.stain = GameObject.Find("img_stain");

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



        if (d >= d2  && actSpray==false)
        {
            // �������� �ʷ�
            gameObject.GetComponent<SpriteRenderer>().sprite = this.img_spray;
        }
        else
        {
            // ��������
            gameObject.GetComponent<SpriteRenderer>().sprite = this.img_spray;
        }

        if (d < r1 + r2)
        {
            gameObject.transform.Translate(destination);        //�������� �̵�
            gameObject.transform.localEulerAngles = rotation;        //�������� ����̱�
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
        water.GetComponent<SpriteRenderer>().sprite = this.img_water;       // ����� �� ���̱�
        actSpray = true;
        Destroy(gameObject, 2);                 // �������� ����
    }

    void Tissue()
    {
        tissue.SetActive(true);      // Ƽ�� ���̱�
    }
}
