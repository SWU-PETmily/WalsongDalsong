using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CardController : MonoBehaviour
{
    private Animator animator;
    int level;  // 칭찬 단계
    public GameObject card;     //카드

    void Start()
    {
        // 애니메이터
        this.animator = GetComponent<Animator>();

        // 스테이지 2라면
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
        level = PlayerPrefs.GetInt("goodLevel")-1;  // 단계 저장. 이전에 단계 올려줬기 때문에 -1
        Debug.Log("단계"+PlayerPrefs.GetInt("goodLevel").ToString());
        if (level == 1)
        {
            // 1단계 칭찬. 하품
            this.animator.SetTrigger("YawnTrigger");
            Debug.Log("하품");
        }
        else if (level == 2){
            // 2단계 칭찬. 코
            this.animator.SetTrigger("NoseTrigger");
            Debug.Log("코");
        } else{
            // 3단계 이상 칭찬. 몸 털기
            this.animator.SetTrigger("BodyShakeTrigger");
        }
    }

    void CheckLevel2()
    {
        level = PlayerPrefs.GetInt("goodLevel") - 1;  // 단계 저장. 이전에 단계 올려줬기 때문에 -1
        Debug.Log("단계" + PlayerPrefs.GetInt("goodLevel").ToString());
        if (level == 1)
        {
            // 1단계 칭찬. 호기심
            this.animator.SetTrigger("QuestionTrigger");
            Debug.Log("호기심");
        }
        else if (level == 2)
        {
            // 2단계 칭찬. 친하게 지내자
            this.animator.SetTrigger("FriendTrigger");
            Debug.Log("친하게 지내자");
        }
        else if (level == 3)
        {
            // 3단계 칭찬. 애교
            this.animator.SetTrigger("LovelyTrigger");
        }
        else
        {
            // 4단계 이상 칭찬. 부탁
            this.animator.SetTrigger("PleaseTrigger");
        }
    }
}
