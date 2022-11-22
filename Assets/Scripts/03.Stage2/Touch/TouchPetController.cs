using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TouchPetController : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Animator animator;              // �ִϸ�����
    int touchCount = 0;                     // ��ġ Ƚ�� ���� ����
    AudioSource audioSource;                //������ҽ�
    public GameObject doneBg;                   // �Ϸ� ���
    public GameObject doneTxt;              // �Ϸ� �ؽ�Ʈ

    void Start()
    {
        doneBg.SetActive(false);
        doneTxt.SetActive(false);
        animator = GetComponent<Animator>();                         // �ִϸ�����
        audioSource = this.gameObject.GetComponent<AudioSource>();   //������ҽ�
    }

    void Update()
    {
        
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
        if (touchCount >= 150)
        {
            // �̼� �Ϸ�â ����
            doneBg.SetActive(true);
            doneTxt.SetActive(true);
            // �̼� ���� �˸�
            PlayerPrefs.SetInt("successTouch", 1);
            // �ŽǷ� �̵�
            Invoke("RetunRoom", 4.0f);         
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        animator.SetBool("isTouch", false);    // ��ġ �ִϸ����� ����
        Debug.Log("OnEndDrag");
    }

    // �ŽǷ� �̵�
    void RetunRoom()
    {
        // �ŽǷ� �̵�
        UnityEngine.SceneManagement.SceneManager.LoadScene("Room2Scene");
    }
}
