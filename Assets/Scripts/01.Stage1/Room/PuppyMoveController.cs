using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuppyMoveController : MonoBehaviour
{
    private Animator animator;

    // �ڷ�ƾ
    public bool isDelay = false;
    public float delayTime = 10.0f;   // 55�� ���� ������
    public float accumTime;

    int animationOrder = 1;

    void Start()
    {
        // �ִϸ�����
        this.animator = GetComponent<Animator>();
        //this.animator.SetTrigger("Walk3Trigger");         //================�ּ� �ٽ� Ǯ��=================
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

    // �ڷ�ƾ ����
    void sitting()
    {
        // �ڷ�ƾ ����
        if (isDelay == false)
        {
            isDelay = true;
            //StartCoroutine(Walk3());          //================�ּ� �ٽ� Ǯ��=================
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
        yield return new WaitForSecondsRealtime(delayTime);     //Time.timeScale ���� ���� �ʴ� �������� �ð�
        animationOrder = 2;
        isDelay = false;
    }

    IEnumerator Walk5()
    {
        this.animator.SetTrigger("Walk5Trigger");
        yield return new WaitForSecondsRealtime(delayTime);     //Time.timeScale ���� ���� �ʴ� �������� �ð�
        isDelay = false;
    }
}