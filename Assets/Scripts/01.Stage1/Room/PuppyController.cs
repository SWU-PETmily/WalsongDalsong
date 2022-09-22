using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuppyController : MonoBehaviour
{
    [SerializeField] Transform[] puppyPos;  // ������ ��ġ
    [SerializeField] float speed = 0.5f;    // �ӵ�
    int puppyNum = 0;   // ��ġ ����

    public bool isDelay;
    public float delayTime = 5.0f;  //������ �ð�

    // Start is called before the first frame update
    void Start()
    {
        transform.position = puppyPos[puppyNum].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();     // �����̱�

        if (isDelay == false)
        {
            isDelay = true;
            ChangePosition();       // ��ǥ ��ġ �ٲٱ�
            StartCoroutine(WaitForIt());    // �ڷ�ƾ ����
        }

    }

    // ������ ��ġ �̵�
    void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, puppyPos[puppyNum].transform.position, speed * Time.deltaTime);

    }

    // ������ ��ǥ ��ǥ ����
    void ChangePosition()
    {

        if (transform.position == puppyPos[puppyNum].transform.position)
            puppyNum++;

        if (puppyNum == puppyPos.Length)
            puppyNum = 0;
    }

    // ��� �ڷ�ƾ ����
    IEnumerator WaitForIt()
    {
        yield return new WaitForSeconds(delayTime);
        isDelay = false;
    }
}
