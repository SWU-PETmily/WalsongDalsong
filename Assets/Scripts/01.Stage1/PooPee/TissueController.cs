using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class TissueController : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public static Vector2 defaultposition;

    bool left = true;
    int touchNum = 0;       // �巡�� Ƚ�� ī��Ʈ
    int totalNum = 5;       // �巡�� �� Ƚ�� 

    public GameObject water;
    public GameObject stain;
    public GameObject tissueBox;
    public GameObject btnBack;

    public GameObject bgBlack;     // �������
    public GameObject particle;     // ��ƼŬ
    public GameObject txtDone;     // �Ϸ� �ؽ�Ʈ�̹���

    AudioSource audioSource;                                        //������ҽ�
    public AudioClip audioErase;                            //�۴� �Ҹ� ����� Ŭ��

    Vector3 destination = new Vector3(3500, 900, 0);         // ������ �̵� ��ġ

    void Start()
    {
        audioSource = this.gameObject.GetComponent<AudioSource>();   //������ҽ�
    }

    void Update()
    {
        // �浹 ����
        Vector3 t1 = transform.position;                // Ƽ�� �߽� ��ǥ

        // ���ʿ� ������
        if(t1.x <= 1200.0f && (t1.y >= 476.0f || t1.y <= 1000.0f) && left==true)
        {
            audioSource.clip = audioErase;
            this.audioSource.Play();                                    //����� ����
            left = false;
            touchNum++;
        }

        // �����ʿ� ������
        if (t1.x >= 1800.0f && (t1.y >= 476.0f || t1.y <= 1000.0f) && left == false)
        {
            left = true;
            touchNum++;
        }

        if(touchNum >= totalNum)
        {
            // ���ӿ�����Ʈ ����
            //Destroy(gameObject);
            this.transform.position = destination;
            Destroy(water);
            Destroy(stain);
            Destroy(tissueBox);
            Destroy(btnBack);

            // ���� ��ƼŬ
            bgBlack.SetActive(true);
            txtDone.SetActive(true);
            particle.SetActive(true);

            // �Ϸ� �躯 ġ��� Ƚ�� ����
            int num = PlayerPrefs.GetInt("pooCleaningNum")+1;
            PlayerPrefs.SetInt("pooCleaningNum", num);
            // �̼� ���� �˸�
            PlayerPrefs.SetInt("successPooPeeClean", 1);

            // �� ��ȯ
            Invoke("ChangeScene", 5.0f);           // ��� ��ȯ
        }

    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        defaultposition = this.transform.position;
        stain.SetActive(true);      // ��� ���̱�
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 currentPos = Input.mousePosition;
        this.transform.position = currentPos;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        this.transform.position = defaultposition;
    }

    // ��� ��ȯ
    void ChangeScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Room1Scene");
    }


}
