using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprayController : MonoBehaviour
{

    GameObject stain;
    GameObject water;

    // �ٲ� �̹���
    public Sprite img_spray_pre;
    public Sprite img_spray_ing;
    public Sprite img_spray;
    public Sprite img_water;

    Vector2 fp1;
    Vector2 fp2;
    float d2 = 0.0f;
    bool actSpray = false;

    // Start is called before the first frame update
    void Start()
    {
        this.stain = GameObject.Find("img_stain");
        this.water = GameObject.Find("img_spray_water1");
        water.SetActive(false);

        // �ʹ� ��ǥ
        fp1 = transform.position;                // �������� �߽� ��ǥ
        fp2 = this.stain.transform.position;  // ��� �߽� ��ǥ
        Vector2 dir = fp1 - fp2;
        d2 = dir.magnitude;
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
            // �����ϱ�
            gameObject.GetComponent<SpriteRenderer>().sprite = this.img_spray;
        }

        if (d < r1 + r2)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = this.img_spray_ing;
            // +�ִϸ��̼� �߰��ϱ�
            water.SetActive(true);      //����� ���̱�
            water.GetComponent<SpriteRenderer>().sprite = this.img_water;       // ����� �� ���̱�
            gameObject.transform.localPosition = fp1;       // �������� ����ġ
            gameObject.GetComponent<SpriteRenderer>().sprite = this.img_spray;      // �������� �Ϸ� �̹���
            actSpray = true;
        }

    }
}
