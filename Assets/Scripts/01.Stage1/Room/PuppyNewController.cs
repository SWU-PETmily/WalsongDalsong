using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuppyNewController : MonoBehaviour
{
    [SerializeField] Transform[] puppyPos;  // ������ ��ġ
    [SerializeField] float speed = 20.0f;    // �ӵ�
    int puppyNum = 0;   // ��ġ ����

    public bool isDelay;
    public float delaySit = 5.0f;  //������ �ð�
    public float delayWalk = 7.0f;  //������ �ð�


    private Animator animator;

    bool isMove = false;
    bool isChangePos = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(MoveStart());    // �ڷ�ƾ ����


    }

    void Update()
    {
        /*
        Move();     // �����̱�

        if (isDelay == false)
        {
            isDelay = true;
            ChangePosition();       // ��ǥ ��ġ �ٲٱ�
            StartCoroutine(WaitForIt());    // �ڷ�ƾ ����
        }
        */
        if (isMove == true)
        {
            Move();
        }


    }

    // ���� ���� �� 30�� �� ��Һ�
    IEnumerator MoveStart()
    {
        // �ɾ��ֱ�
        animator.SetTrigger("SitTrigger");    // �̵� Ʈ����
        yield return new WaitForSeconds(delaySit);              // ù ���� ���

        // pos2-���������� �̵�
        animator.ResetTrigger("SitTrigger");    // �̵� Ʈ����
        animator.SetTrigger("RightDayTrigger");    // �̵� Ʈ����
        ChangePosition();
        isMove = true;
        yield return new WaitForSeconds(delayWalk);

        // �ɾ��ֱ�
        isMove = false;
        animator.ResetTrigger("RightDayTrigger");    // �̵� Ʈ����
        animator.SetTrigger("SitTrigger");    // �̵� Ʈ����
        yield return new WaitForSeconds(delaySit);

        // pos3-������ �Ʒ��� �̵�
        animator.ResetTrigger("SitTrigger");    
        animator.SetTrigger("RightDownDayTrigger");
        ChangePosition();
        isMove = true;
        yield return new WaitForSeconds(delayWalk);

        // �ɾ��ֱ�
        isMove = false;
        animator.ResetTrigger("RightDownDayTrigger");   
        animator.SetTrigger("SitTrigger"); 
        yield return new WaitForSeconds(delaySit);

        // pos4-������ ���� �̵�
        animator.ResetTrigger("SitTrigger");
        animator.SetTrigger("RightUpDayTrigger");
        ChangePosition();
        isMove = true;
        yield return new WaitForSeconds(delayWalk);

        // �ɾ��ֱ�
        isMove = false;
        animator.ResetTrigger("RightUpDayTrigger");  
        animator.SetTrigger("SitTrigger");  
        yield return new WaitForSeconds(delaySit);

        // pos5-�������� �̵�
        animator.ResetTrigger("SitTrigger");
        animator.SetTrigger("LeftDayTrigger");
        ChangePosition();
        isMove = true;
        yield return new WaitForSeconds(delayWalk);

        // �ɾ��ֱ�
        isMove = false;
        animator.ResetTrigger("LeftDayTrigger");
        animator.SetTrigger("SitTrigger");
        yield return new WaitForSeconds(delaySit);

        // pos6-�������� �̵�
        animator.ResetTrigger("SitTrigger");
        animator.SetTrigger("LeftDayTrigger");
        ChangePosition();
        isMove = true;
        yield return new WaitForSeconds(delayWalk);

        // �ɾ��ֱ�
        isMove = false;
        animator.ResetTrigger("LeftDayTrigger");
        animator.SetTrigger("SitTrigger");
        yield return new WaitForSeconds(delaySit);

        // pos7-�������� �̵�
        animator.ResetTrigger("SitTrigger");
        animator.SetTrigger("LeftDayTrigger");
        ChangePosition();
        isMove = true;
        yield return new WaitForSeconds(delayWalk);

        // �ɾ��ֱ�
        isMove = false;
        animator.ResetTrigger("LeftDayTrigger");
        animator.SetTrigger("SitTrigger");
        yield return new WaitForSeconds(delaySit);

        // pos8-���� �Ʒ��� �̵�
        animator.ResetTrigger("SitTrigger");
        animator.SetTrigger("LeftDownDayTrigger");
        ChangePosition();
        isMove = true;
        yield return new WaitForSeconds(delayWalk);

        // �ɾ��ֱ�
        isMove = false;
        animator.ResetTrigger("LeftDownDayTrigger");
        animator.SetTrigger("SitTrigger");
        yield return new WaitForSeconds(delaySit);

        // pos9-���� ���� �̵�
        animator.ResetTrigger("SitTrigger");
        animator.SetTrigger("LeftUpDayTrigger");
        ChangePosition();
        isMove = true;
        yield return new WaitForSeconds(delayWalk);

        // �ɾ��ֱ�
        isMove = false;
        animator.ResetTrigger("LeftUpDayTrigger");
        animator.SetTrigger("SitTrigger");
        yield return new WaitForSeconds(delaySit);

        // pos10-���������� �̵�
        animator.ResetTrigger("SitTrigger");
        animator.SetTrigger("RightDayTrigger");
        ChangePosition();
        isMove = true;
        yield return new WaitForSeconds(delayWalk);

        // �ɾ��ֱ�
        isMove = false;
        animator.ResetTrigger("RightDayTrigger");
        animator.SetTrigger("SitTrigger");
        yield return new WaitForSeconds(delaySit);

        // pos11-���������� �̵�
        animator.ResetTrigger("SitTrigger");
        animator.SetTrigger("RightDayTrigger");
        ChangePosition();
        isMove = true;
        yield return new WaitForSeconds(delayWalk);

        // �ɾ��ֱ�
        isMove = false;
        animator.ResetTrigger("RightDayTrigger");
        animator.SetTrigger("SitTrigger");
        yield return new WaitForSeconds(delaySit);

    }



    // ������ ��ġ �̵�
    void Move()
    {

        transform.position = Vector2.MoveTowards(transform.position, puppyPos[puppyNum].transform.position, speed * Time.deltaTime);

    }

    // ������ ��ǥ ��ǥ ����
    void ChangePosition()
    {
        /*
        if (transform.position == puppyPos[puppyNum].transform.position)
            puppyNum++;

        if (puppyNum == puppyPos.Length)
            puppyNum = 0;
        */
        puppyNum++;
        if (puppyNum == puppyPos.Length)
            puppyNum = 0;
        Debug.Log(puppyNum);
    }

    // ��� �ڷ�ƾ ����
    IEnumerator WaitForIt()
    {
        //animator.SetTrigger("RightDayTrigger");    // �̵� Ʈ����
        Debug.Log("RightTrigger");
        yield return new WaitForSeconds(delayWalk);
        //animator.SetTrigger("SitTrigger");    // �̵� Ʈ����
        Debug.Log("SitTrigger");
        isDelay = false;
    }

}
