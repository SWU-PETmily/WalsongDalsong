using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puppy2Controller : MonoBehaviour
{
    [SerializeField] Transform[] puppyPos;  // ������ ��ġ
    [SerializeField] float speed = 0.5f;    // �ӵ�
    int puppyNum = 0;   // ��ġ ����

    public bool isDelay;
    public float delaySit = 5.0f;  // ������ �ð�
    public float delayWalk = 7.0f;  // ������ �ð�

    AudioSource audioSource;        // ������ҽ�
    private Animator animator;      // �ִϸ�����

    bool isMove = false;            // ������ ���� ���� ����
    public GameObject posPoo;       // �躯 ���� ��ġ
    public GameObject prefabPoo;         // ��Һ� ������

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

        while (true)
        {
            // pos2-���������� �̵�
            animator.ResetTrigger("SitTrigger");    // �̵� Ʈ����
            animator.SetTrigger("RightTrigger");    // �̵� Ʈ����
            ChangePosition();
            isMove = true;
            yield return new WaitForSeconds(4.5f);

            // pos3-������ �Ʒ��� �̵�
            animator.ResetTrigger("RightTrigger");
            animator.SetTrigger("RightDownTrigger");
            ChangePosition();
            yield return new WaitForSeconds(delayWalk);


            // pos4-������ ���� �̵�
            animator.ResetTrigger("RightDownTrigger");
            animator.SetTrigger("RightUpTrigger");
            ChangePosition();
            yield return new WaitForSeconds(5.0f);

            // �ɾ��ֱ� (�躯 ����)
            isMove = false;
            Instantiate(prefabPoo, posPoo.transform.position, posPoo.transform.rotation);    // �躯 ������ ����
            this.audioSource.Play();              //����� ����
            animator.ResetTrigger("RightUpTrigger");
            animator.SetTrigger("SitTrigger");
            yield return new WaitForSeconds(delaySit);

            // pos5-�������� �̵�
            animator.ResetTrigger("SitTrigger");
            animator.SetTrigger("LeftTrigger");
            ChangePosition();
            isMove = true;
            yield return new WaitForSeconds(18.0f);

            // pos6-���� �Ʒ��� �̵�
            animator.ResetTrigger("LeftTrigger");
            animator.SetTrigger("LeftDownTrigger");
            ChangePosition();
            yield return new WaitForSeconds(delayWalk);

            // pos7-���� ���� �̵�
            animator.ResetTrigger("LeftDownTrigger");
            animator.SetTrigger("LeftUpTrigger");
            ChangePosition();
            yield return new WaitForSeconds(6.0f);

            // pos8-���������� �̵�
            animator.ResetTrigger("LeftUpTrigger");
            animator.SetTrigger("RightTrigger");
            ChangePosition();
            yield return new WaitForSeconds(14.0f);

            // �ɾ��ֱ�
            isMove = false;
            this.audioSource.Play();              //����� ����
            animator.ResetTrigger("RightTrigger");
            animator.SetTrigger("SitTrigger");
            ChangePosition();
            yield return new WaitForSeconds(delaySit);
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
        puppyNum++;
        if (puppyNum == puppyPos.Length)
            puppyNum = 0;
        Debug.Log(puppyNum);
    }
}