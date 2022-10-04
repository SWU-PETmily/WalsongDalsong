using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeeTissue1Controller : MonoBehaviour
{
    bool left = true;
    int touchNum = 0;       // �巡�� Ƚ�� ī��Ʈ
    int totalNum = 7;       // �巡�� �� Ƚ�� 

    public GameObject stain;
    public GameObject tissueBox;
    public GameObject spray;


    // Update is called once per frame
    void Update()
    {
        // �浹 ����
        Vector3 t1 = transform.position;                // Ƽ�� �߽� ��ǥ

        // ���ʿ� ������
        if (t1.x <= -1 && (t1.y >= -1.55f || t1.y <= 1.8f) && left == true)
        {
            left = false;
            touchNum++;
        }

        // ���ʿ� ������
        if (t1.x >= 1.6f && (t1.y >= -1.55f || t1.y <= 1.8f) && left == false)
        {
            left = true;
            touchNum++;
        }

        if (touchNum >= totalNum)
        {
            // ���ӿ�����Ʈ ����
            Destroy(gameObject);
            Destroy(stain);
            Destroy(tissueBox);

            // �������� ����
            spray.SetActive(true);

        }

    }
}
