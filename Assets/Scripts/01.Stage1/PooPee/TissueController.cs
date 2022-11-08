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


    // Update is called once per frame
    void Update()
    {
        // �浹 ����
        Vector3 t1 = transform.position;                // Ƽ�� �߽� ��ǥ

        // ���ʿ� ������
        if(t1.x <= 1200.0f && (t1.y >= 476.0f || t1.y <= 1000.0f) && left==true)
        {
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
            Destroy(gameObject);
            Destroy(water);
            Destroy(stain);
            Destroy(tissueBox);

            // �Ϸ� �躯 ġ��� Ƚ�� ����
            int num = PlayerPrefs.GetInt("pooCleaningNum")+1;
            PlayerPrefs.SetInt("pooCleaningNum", num);
            // �̼� ���� �˸�
            PlayerPrefs.SetInt("successPooPeeClean", 1);
            // �� ��ȯ
            UnityEngine.SceneManagement.SceneManager.LoadScene("Room1Scene");
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


}
