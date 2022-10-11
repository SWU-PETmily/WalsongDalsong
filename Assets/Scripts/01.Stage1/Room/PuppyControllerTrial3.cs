using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 멈춤 위치 처음으로 돌아감 
public class PuppyControllerTrial3 : MonoBehaviour
{
    private Animator animator;

    // 코루틴
    public bool isDelay = false;
    public float delayTime = 4.0f;   // 55분 동안 딜레이
    public float accumTime;

    int animationOrder = 1;

    void Start()
    {
        // 애니메이터
        this.animator = GetComponent<Animator>();
        StartCoroutine(Sit());    // 코루틴 실행
        //this.animator.SetTrigger("SitTrigger");
    }

    void Update()
    {
        /*
        if (isDelay == false)
        {
            isDelay = true;
            StartCoroutine(Sit());    // 코루틴 실행
        }
        */

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
            StartCoroutine(Walk3());
            // StartCoroutine(Walk5());
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

    IEnumerator Sit()
    {

        yield return new WaitForSecondsRealtime(delayTime);     //Time.timeScale 영향 받지 않는 절대적인 시간
        while (true)
        {
            this.animator.SetTrigger("SitTrigger");
            Debug.Log("sittitntintintintninnnnnnnnnnnnnnnnnnnnnng");
            yield return new WaitForSecondsRealtime(delayTime);     //Time.timeScale 영향 받지 않는 절대적인 시간
        }
    }

    /*
    IEnumerator Sit()
    {
        this.animator.SetTrigger("SitTrigger");
        Debug.Log("sittitntintintintninnnnnnnnnnnnnnnnnnnnnng");
        yield return new WaitForSeconds(delayTime);     //Time.timeScale 영향 받지 않는 절대적인 시간
        isDelay = false;
    }*/

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
