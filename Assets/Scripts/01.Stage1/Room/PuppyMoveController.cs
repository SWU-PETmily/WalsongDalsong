using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuppyMoveController : MonoBehaviour
{
    private Animator animator;

    // 코루틴
    public bool isDelay = false;
    public float delayTime = 10.0f;   // 55분 동안 딜레이
    public float accumTime;

    int animationOrder = 1;

    void Start()
    {
        // 애니메이터
        this.animator = GetComponent<Animator>();
        //this.animator.SetTrigger("Walk3Trigger");         //================주석 다시 풀기=================
    }

    void Update()
    {
        //sitting();

        //Invoke("walk3", 2);
        //Invoke("walk5", 5);

        /*
        switch (animationOrder)
        {
            case 1:
                this.animator.SetTrigger("Walk3Trigger");
                sitting();
                break;
            default:
                break;


        }
        */
    }

    // 코루틴 생성
    void sitting()
    {
        // 코루틴 생성
        if (isDelay == false)
        {
            isDelay = true;
            //StartCoroutine(Walk3());          //================주석 다시 풀기=================
        }
    }

    /*
    void walk3()
    {
        this.animator.SetTrigger("Walk3Trigger");
    }
    void walk5()
    {
        this.animator.SetTrigger("Walk5Trigger");
    }

    */


    IEnumerator Walk3()
    {
        this.animator.SetTrigger("Walk3Trigger");
        yield return new WaitForSecondsRealtime(delayTime);     //Time.timeScale 영향 받지 않는 절대적인 시간
        animationOrder = 2;
        isDelay = false;
    }

    IEnumerator Walk5()
    {
        this.animator.SetTrigger("Walk5Trigger");
        yield return new WaitForSecondsRealtime(delayTime);     //Time.timeScale 영향 받지 않는 절대적인 시간
        isDelay = false;
    }
}