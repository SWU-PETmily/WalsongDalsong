using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���� ��ġ ó������ ���ư� 
public class PuppyControllerTrial3 : MonoBehaviour
{
    private Animator animator;

    // �ڷ�ƾ
    public bool isDelay = false;
    public float delayTime = 4.0f;   // 55�� ���� ������
    public float accumTime;

    int animationOrder = 1;

    void Start()
    {
        // �ִϸ�����
        this.animator = GetComponent<Animator>();
        StartCoroutine(Sit());    // �ڷ�ƾ ����
        //this.animator.SetTrigger("SitTrigger");
    }

    void Update()
    {
        /*
        if (isDelay == false)
        {
            isDelay = true;
            StartCoroutine(Sit());    // �ڷ�ƾ ����
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

    // �ڷ�ƾ ����
    void sitting()
    {
        // �ڷ�ƾ ����
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

        yield return new WaitForSecondsRealtime(delayTime);     //Time.timeScale ���� ���� �ʴ� �������� �ð�
        while (true)
        {
            this.animator.SetTrigger("SitTrigger");
            Debug.Log("sittitntintintintninnnnnnnnnnnnnnnnnnnnnng");
            yield return new WaitForSecondsRealtime(delayTime);     //Time.timeScale ���� ���� �ʴ� �������� �ð�
        }
    }

    /*
    IEnumerator Sit()
    {
        this.animator.SetTrigger("SitTrigger");
        Debug.Log("sittitntintintintninnnnnnnnnnnnnnnnnnnnnng");
        yield return new WaitForSeconds(delayTime);     //Time.timeScale ���� ���� �ʴ� �������� �ð�
        isDelay = false;
    }*/

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
