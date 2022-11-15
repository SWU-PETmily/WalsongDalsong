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
    float moveSpeed = 4;    // 버튼 누르는 동안의 오브젝트 속도

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
    }

    // 눈 강아지와 충돌 시
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("goal");
        //UnityEngine.SceneManagement.SceneManager.LoadScene("Room2Scene");
    }
}
