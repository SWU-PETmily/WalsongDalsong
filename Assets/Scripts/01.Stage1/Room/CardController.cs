using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CardController : MonoBehaviour
{
    private Animator animator;
    int level;  // Ī�� �ܰ�
    public GameObject card;     //ī��

    void Start()
    {
        // �ִϸ�����
        this.animator = GetComponent<Animator>();

        // �������� 2���
        if (PlayerPrefs.GetInt("stage") == 2)
        {
            CheckLevel2();
        }
        else
        {
            CheckLevel1();
        }
    }

    void CheckLevel1()
    {
        level = PlayerPrefs.GetInt("goodLevel")-1;  // �ܰ� ����. ������ �ܰ� �÷���� ������ -1
        Debug.Log("�ܰ�"+PlayerPrefs.GetInt("goodLevel").ToString());
        if (level == 1)
        {
            // 1�ܰ� Ī��. ��ǰ
            this.animator.SetTrigger("YawnTrigger");
            Debug.Log("��ǰ");
        }
        else if (level == 2){
            // 2�ܰ� Ī��. ��
            this.animator.SetTrigger("NoseTrigger");
            Debug.Log("��");
        } else{
            // 3�ܰ� �̻� Ī��. �� �б�
            this.animator.SetTrigger("BodyShakeTrigger");
        }
    }

    void CheckLevel2()
    {
        level = PlayerPrefs.GetInt("goodLevel") - 1;  // �ܰ� ����. ������ �ܰ� �÷���� ������ -1
        Debug.Log("�ܰ�" + PlayerPrefs.GetInt("goodLevel").ToString());
        if (level == 1)
        {
            // 1�ܰ� Ī��. ȣ���
            this.animator.SetTrigger("QuestionTrigger");
            Debug.Log("ȣ���");
        }
        else if (level == 2)
        {
            // 2�ܰ� Ī��. ģ�ϰ� ������
            this.animator.SetTrigger("FriendTrigger");
            Debug.Log("ģ�ϰ� ������");
        }
        else if (level == 3)
        {
            // 3�ܰ� Ī��. �ֱ�
            this.animator.SetTrigger("LovelyTrigger");
        }
        else
        {
            // 4�ܰ� �̻� Ī��. ��Ź
            this.animator.SetTrigger("PleaseTrigger");
        }
    }
}
