using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TouchStage1Controller : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Animator animator;              // �ִϸ�����
    int touchCount = 0;                     // ��ġ Ƚ�� ���� ����
    AudioSource audioSource;                //������ҽ�
    public GameObject doneBg;               // �Ϸ� ���

    void Start()
    {
        doneBg.SetActive(false);
        animator = GetComponent<Animator>();                         // �ִϸ�����
        audioSource = this.gameObject.GetComponent<AudioSource>();   //������ҽ�
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");
        this.audioSource.Play();                                    //����� ����
    }

    public void OnDrag(PointerEventData eventData)
    {
        animator.SetBool("isTouch", true);    // ��ġ �ִϸ����� ����
        Debug.Log("OnDrag");
        touchCount = touchCount + 1;          // �巡�� Ƚ�� �߰�
        if (touchCount >= 110)
        {
            // ���� �θ� ȭ�� ����
            doneBg.SetActive(true);
            // �̼� ���� �˸�
            PlayerPrefs.SetInt("successTouch", 1);

        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        animator.SetBool("isTouch", false);    // ��ġ �ִϸ����� ����
        Debug.Log("OnEndDrag");
    }

    public void DoneBtnClick()
    {
        // �ŽǷ� �̵�
        UnityEngine.SceneManagement.SceneManager.LoadScene("Room1Scene");
    }
}
