using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puppy2Controller : MonoBehaviour
{
    [SerializeField] Transform[] puppyPos;  // ������ ��ġ
    [SerializeField] float speed = 0.5f;    // �ӵ�
    int puppyNum = 0;   // ��ġ ����

    public bool isDelay;
    public float delaySit = 5.0f;  //������ �ð�
    public float delayWalk = 7.0f;  //������ �ð�

    AudioSource audioSource;        //������ҽ�
    private Animator animator;

    bool isMove = false;
    bool isChangePos = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = this.gameObject.GetComponent<AudioSource>();   //������ҽ�
        StartCoroutine(MoveStart());    // �ڷ�ƾ ����
    }

    void Update()
    {
        if (isMove == true)
        {
            Move();
        }
    }

    // ���� ���� �� 30�� �� ��Һ�
    IEnumerator MoveStart()
    {
        // �ɾ��ֱ�
        this.audioSource.Play();              //����� ����
        animator.SetTrigger("SitTrigger");    // �̵� Ʈ����
        yield return new WaitForSeconds(delaySit);              // ù ���� ���

        // pos2-���������� �̵�
        animator.ResetTrigger("SitTrigger");    // �̵� Ʈ����
        animator.SetTrigger("RightTrigger");    // �̵� Ʈ����
        ChangePosition();
        isMove = true;
        yield return new WaitForSeconds(5.0f);

        // �ɾ��ֱ�
        isMove = false;
        this.audioSource.Play();              //����� ����
        animator.ResetTrigger("RightTrigger");    // �̵� Ʈ����
        animator.SetTrigger("SitTrigger");    // �̵� Ʈ����
        yield return new WaitForSeconds(delaySit);

        // pos3-������ �Ʒ��� �̵�
        animator.ResetTrigger("SitTrigger");
        animator.SetTrigger("RightDownTrigger");
        ChangePosition();
        isMove = true;
        yield return new WaitForSeconds(delayWalk);

        // �ɾ��ֱ�
        isMove = false;
        this.audioSource.Play();              //����� ����
        animator.ResetTrigger("RightDownTrigger");
        animator.SetTrigger("SitTrigger");
        yield return new WaitForSeconds(delaySit);

        // pos4-������ ���� �̵�
        animator.ResetTrigger("SitTrigger");
        animator.SetTrigger("RightUpTrigger");
        ChangePosition();
        isMove = true;
        yield return new WaitForSeconds(5.0f);

        // �ɾ��ֱ�
        isMove = false;
        this.audioSource.Play();              //����� ����
        animator.ResetTrigger("RightUpTrigger");
        animator.SetTrigger("SitTrigger");
        yield return new WaitForSeconds(delaySit);

        // pos5-�������� �̵�
        animator.ResetTrigger("SitTrigger");
        animator.SetTrigger("LeftTrigger");
        ChangePosition();
        isMove = true;
        yield return new WaitForSeconds(delayWalk);

        // �ɾ��ֱ�
        isMove = false;
        this.audioSource.Play();              //����� ����
        animator.ResetTrigger("LeftTrigger");
        animator.SetTrigger("SitTrigger");
        yield return new WaitForSeconds(delaySit);

        // pos6-�������� �̵�
        animator.ResetTrigger("SitTrigger");
        animator.SetTrigger("LeftTrigger");
        ChangePosition();
        isMove = true;
        yield return new WaitForSeconds(delayWalk);

        // �ɾ��ֱ�
        isMove = false;
        this.audioSource.Play();              //����� ����
        animator.ResetTrigger("LeftTrigger");
        animator.SetTrigger("SitTrigger");
        yield return new WaitForSeconds(delaySit);

        // pos7-�������� �̵�
        animator.ResetTrigger("SitTrigger");
        animator.SetTrigger("LeftTrigger");
        ChangePosition();
        isMove = true;
        yield return new WaitForSeconds(delayWalk);

        // �ɾ��ֱ�
        isMove = false;
        this.audioSource.Play();              //����� ����
        animator.ResetTrigger("LeftTrigger");
        animator.SetTrigger("SitTrigger");
        yield return new WaitForSeconds(delaySit);

        // pos8-���� �Ʒ��� �̵�
        animator.ResetTrigger("SitTrigger");
        animator.SetTrigger("LeftDownTrigger");
        ChangePosition();
        isMove = true;
        yield return new WaitForSeconds(delayWalk);

        // �ɾ��ֱ�
        isMove = false;
        this.audioSource.Play();              //����� ����
        animator.ResetTrigger("LeftDownTrigger");
        animator.SetTrigger("SitTrigger");
        yield return new WaitForSeconds(delaySit);

        // pos9-���� ���� �̵�
        animator.ResetTrigger("SitTrigger");
        animator.SetTrigger("LeftUpTrigger");
        ChangePosition();
        isMove = true;
        yield return new WaitForSeconds(delayWalk);

        // �ɾ��ֱ�
        isMove = false;
        this.audioSource.Play();              //����� ����
        animator.ResetTrigger("LeftUpTrigger");
        animator.SetTrigger("SitTrigger");
        yield return new WaitForSeconds(delaySit);

        // pos10-���������� �̵�
        animator.ResetTrigger("SitTrigger");
        animator.SetTrigger("RightTrigger");
        ChangePosition();
        isMove = true;
        yield return new WaitForSeconds(delayWalk);

        // �ɾ��ֱ�
        isMove = false;
        this.audioSource.Play();              //����� ����
        animator.ResetTrigger("RightTrigger");
        animator.SetTrigger("SitTrigger");
        yield return new WaitForSeconds(delaySit);

        // pos11-���������� �̵�
        animator.ResetTrigger("SitTrigger");
        animator.SetTrigger("RightTrigger");
        ChangePosition();
        isMove = true;
        yield return new WaitForSeconds(delayWalk);

        // �ɾ��ֱ�
        isMove = false;
        this.audioSource.Play();              //����� ����
        animator.ResetTrigger("RightTrigger");
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
        puppyNum++;
        if (puppyNum == puppyPos.Length)
            puppyNum = 0;
        Debug.Log(puppyNum);
    }
}
