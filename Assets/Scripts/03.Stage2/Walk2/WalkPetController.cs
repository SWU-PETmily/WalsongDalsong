using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class WalkPetController : MonoBehaviour
{
    Animator animator;
    public bool LeftMove = false;
    public bool RightMove = false;
    Vector3 moveVelocity = Vector3.zero;
    float moveSpeed = 4;    // ��ư ������ ������ ������Ʈ �ӵ�

    bool wasLeft = true;

    // ���� ������Ʈ
    public GameObject btnBack;     // �ڷΰ��� ��ư
    public GameObject btnRight;     // ������ ��ư
    public GameObject btnLeft;     // ���� ��ư
    public GameObject bgBlack;     // �������
    public GameObject particle;     // ��ƼŬ
    public GameObject txtDone;     // �Ϸ� �ؽ�Ʈ�̹���
    bool isDone = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        bgBlack.SetActive(false);
        txtDone.SetActive(false);
        particle.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (LeftMove)
        {
            animator.SetInteger("Direction", 2);
            moveVelocity = new Vector3(-0.5f, 0, 0);
            transform.position += moveVelocity * moveSpeed * Time.deltaTime;
            wasLeft = true;
        }

        if (RightMove)
        {
            animator.SetInteger("Direction", 4);
            moveVelocity = new Vector3(+0.5f, 0, 0);
            transform.position += moveVelocity * moveSpeed * Time.deltaTime;
            wasLeft = false;
        }

        if(RightMove == false && LeftMove == false)
        {
            if (wasLeft)
            {
                animator.SetInteger("Direction", 1);
            }
            else
            {
                animator.SetInteger("Direction", 3);
            }
        }

        if (isDone)
        {
            moveVelocity = new Vector3(-1.0f, 0, 0);
            transform.position += moveVelocity * moveSpeed * Time.deltaTime;
        }
    }

    // �� �������� �浹 ��
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("goal");
        btnLeft.SetActive(false);
        btnRight.SetActive(false);
        btnBack.SetActive(false);
        bgBlack.SetActive(true);
        txtDone.SetActive(true);
        particle.SetActive(true);
        isDone = true;
        PlayerPrefs.SetInt("successWalk", 1);     // �Ļ� �޼� �̼� ����
        Invoke("ChangeScene", 5.0f);           // ��� ��ȯ
    }

    // ��� ��ȯ
    void ChangeScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Room2Scene");
    }
}
