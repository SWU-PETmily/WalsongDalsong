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

    // �ٲ� �̹���
    //public Sprite imgYawn;     // ��ǰ
    //public Sprite imgNose;     // ��
    //public Sprite imgBodyShake; // �� �б�

    // Start is called before the first frame update
    void Start()
    {
        // �ִϸ�����
        this.animator = GetComponent<Animator>();
        CheckLevel();
    }

    void CheckLevel()
    {
        level = PlayerPrefs.GetInt("goodLevel")-1;  // �ܰ� ����. ������ �ܰ� �÷���� ������ -1
        Debug.Log("�ܰ�"+PlayerPrefs.GetInt("goodLevel").ToString());
        if (level == 1)
        {
            // 1�ܰ� Ī��. ��ǰ
            //card.GetComponent<SpriteRenderer>().sprite = this.imgYawn;  // ��ǰ �̹����� ����
            this.animator.SetTrigger("YawnTrigger");
            Debug.Log("��ǰ");
        }
        else if (level == 2){
            // 2�ܰ� Ī��. ��
            // card.GetComponent<SpriteRenderer>().sprite = this.imgNose;  // �� �̹����� ����
            this.animator.SetTrigger("NoseTrigger");
            Debug.Log("��");
        } else{
            // 3�ܰ� �̻� Ī��. �� �б�
            // card.GetComponent<SpriteRenderer>().sprite = this.imgBodyShake;  // �� �б� �̹����� ����
            this.animator.SetTrigger("BodyShakeTrigger");
        }
    }

    // ����� ����
    private void OnApplicationQuit()
    {
        QuitDateCheck(); //���ᳯ¥�ð� üũ
    }

    // ���� ��¥ �ð� üũ
    private void QuitDateCheck()
    {
        int quitDate = int.Parse(System.DateTime.Now.ToString("yyyyMMdd"));
        int quitTime = int.Parse(System.DateTime.Now.ToString("HHmm"));

        Debug.Log("���� ��¥ : " + quitDate);
        Debug.Log("���� �ð� : " + quitTime);

        PlayerPrefs.SetInt("quitDate", quitDate);
        PlayerPrefs.SetInt("quitTime", quitTime);

    }
}
