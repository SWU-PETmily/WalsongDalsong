using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkPetController : MonoBehaviour
{
    Animator animator;
    public bool LeftMove = false;
    public bool RightMove = false;
    Vector3 moveVelocity = Vector3.zero;
    float moveSpeed = 4;    // ��ư ������ ������ ������Ʈ �ӵ�

    bool wasLeft = true;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (LeftMove)
        {
            /*
            animator.ResetTrigger("Right");
            animator.ResetTrigger("StopLeft");
            animator.ResetTrigger("StopRight");
            animator.SetTrigger("Left");
            */
            animator.SetInteger("Direction", 2);
            moveVelocity = new Vector3(-80f, 0, 0);
            transform.position += moveVelocity * moveSpeed * Time.deltaTime;
            wasLeft = true;
        }

        if (RightMove)
        {
            /*
            animator.ResetTrigger("Left");
            animator.ResetTrigger("StopLeft");
            animator.ResetTrigger("StopRight");
            animator.SetTrigger("Right");
            */
            animator.SetInteger("Direction", 4);
            moveVelocity = new Vector3(+80f, 0, 0);
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
    }
}
