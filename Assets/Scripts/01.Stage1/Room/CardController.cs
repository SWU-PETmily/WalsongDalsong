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

    // 바꿀 이미지
    //public Sprite imgYawn;     // 하품
    //public Sprite imgNose;     // 코
    //public Sprite imgBodyShake; // 몸 털기

    // Start is called before the first frame update
    void Start()
    {
        // 애니메이터
        this.animator = GetComponent<Animator>();
        CheckLevel();
    }

    void CheckLevel()
    {
        level = PlayerPrefs.GetInt("goodLevel")-1;  // 단계 저장. 이전에 단계 올려줬기 때문에 -1
        Debug.Log("단계"+PlayerPrefs.GetInt("goodLevel").ToString());
        if (level == 1)
        {
            // 1단계 칭찬. 하품
            //card.GetComponent<SpriteRenderer>().sprite = this.imgYawn;  // 하품 이미지로 변경
            this.animator.SetTrigger("YawnTrigger");
            Debug.Log("하품");
        }
        else if (level == 2){
            // 2단계 칭찬. 코
            // card.GetComponent<SpriteRenderer>().sprite = this.imgNose;  // 코 이미지로 변경
            this.animator.SetTrigger("NoseTrigger");
            Debug.Log("코");
        } else{
            // 3단계 이상 칭찬. 몸 털기
            // card.GetComponent<SpriteRenderer>().sprite = this.imgBodyShake;  // 몸 털기 이미지로 변경
            this.animator.SetTrigger("BodyShakeTrigger");
        }
    }

    // 종료시 실행
    private void OnApplicationQuit()
    {
        QuitDateCheck(); //종료날짜시간 체크
    }

    // 종료 날짜 시간 체크
    private void QuitDateCheck()
    {
        int quitDate = int.Parse(System.DateTime.Now.ToString("yyyyMMdd"));
        int quitTime = int.Parse(System.DateTime.Now.ToString("HHmm"));

        Debug.Log("종료 날짜 : " + quitDate);
        Debug.Log("종료 시간 : " + quitTime);

        PlayerPrefs.SetInt("quitDate", quitDate);
        PlayerPrefs.SetInt("quitTime", quitTime);

    }
}
