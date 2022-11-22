using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// 변수 초기화 && 가상부모 칭찬/경고
public class Parent2Advice : MonoBehaviour
{
    public Text dialogText;
    public GameObject dialogBox;
    public GameObject mom;

    public int dialogNum;       // 대사 번호
    public bool good = true;    // 칭찬/경고
    public int level;           // 칭찬/경고 단계
    string petName;             // 펫이름

    // 바꿀 이미지
    public Sprite momSmile;     // 웃는 엄마
    public Sprite momAngry;     // 화난 엄마

    // Start is called before the first frame update
    void Start()
    {
        // 임시 변수
        PlayerPrefs.SetInt("goodLevel", 1);
        PlayerPrefs.SetInt("badLevel", 1);
        PlayerPrefs.SetInt("feedNum", 2);
        PlayerPrefs.SetInt("pooCleaningNum", 4);
        PlayerPrefs.SetInt("walkNum", 2);
        PlayerPrefs.SetInt("stage", 2);


        petName = PlayerPrefs.GetString("name");
        dialogNum = 0;

        GoodOrBad();    // 칭찬 or 경고 분류
        showDialog();   // 첫 번째 구문 보여주기    
        ResetNum();     // 하루 변수 초기화
        QuitDateCheck();    // 종료 시간 재설정
    }

    // 버튼 클릭 함수
    public void ClickBtn()
    {
        if (good == true)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Card2Scene");
        }
        else
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Room2Scene");
        }
    }

    // 칭찬 or 경고 분류
    void GoodOrBad()
    {
        int feedNum = PlayerPrefs.GetInt("feedNum");
        int pooCleaningNum = PlayerPrefs.GetInt("pooCleaningNum");
        // int peeCleaningNum = PlayerPrefs.GetInt("peeCleaningNum");
        int walkNum = PlayerPrefs.GetInt("walkNum");

        // 칭찬 조건을 충족한다면
        if (feedNum >= 2 && pooCleaningNum >= 4 && walkNum >= 2)
        {
            mom.GetComponent<Image>().sprite = this.momSmile;  // 웃는 이미지로 변경
            good = true;
        }
        else
        {
            mom.GetComponent<Image>().sprite = this.momAngry;  // 화난 이미지로 변경
            good = false;
        }
    }

    // 첫번째 구문 보여주기
    void showDialog()
    {
        // 칭찬이라면
        if (good == true)
        {
            level = PlayerPrefs.GetInt("goodLevel");
            if (level == 1)
            {
                dialogText.text = "엄마가 처음엔 네가 " + petName + "을(를) 잘 돌볼 수 있을까 걱정했는데... 괜한 걱정이었구나! 정말 대견해~";
            }
            else if (level == 2)
            {
                dialogText.text = "옆집 형욱 아저씨가 그렇게 네 칭찬을 하더라. 엄마가 없을 때도 " + petName + " 산책도 잘 시킨다고. 너무 기특해!";
            }
            else
            {
                dialogText.text = "요즘 들어 무척 네가 자랑스럽네. " + petName + "을(를) 데려오고 책임감 있는 모습 보여줘서 고마워~";
            }
            PlayerPrefs.SetInt("goodLevel", level + 1);
        }
        // 경고라면
        else
        {
            level = PlayerPrefs.GetInt("badLevel");
            if (level == 1)
            {
                dialogText.text = petName+"을(를) 돌보는 걸 잊었구나... 하루에 식사를 2회, 배소변 처리 4회, 산책 2회는 꼭 해주어야 한단다!";
            }
            else if (level == 2)
            {
                dialogText.text = "너는 가족과 친구들이 있지만 " + petName + "(이)에게는 우리 가족 밖에 없단다. 그러니 우리가 책임을 가지고 돌봐줘야 해.";
            }
            else
            {
                dialogText.text = "이렇게 제대로 관리를 못 할 거면 우린 더 이상 " + petName + "을(를) 기르기 어려워.";
            }
            PlayerPrefs.SetInt("badLevel", level + 1);
        }
    }

    // 하루 먹이주기, 배소변관리, 쓰다듬기 횟수 리셋
    void ResetNum()
    {
        PlayerPrefs.SetInt("feedNum", 0);
        PlayerPrefs.SetInt("pooCleaningNum", 0);
        PlayerPrefs.SetInt("peeCleaningNum", 0);
        PlayerPrefs.SetInt("touchingNum", 0);
        PlayerPrefs.SetInt("walkNum", 0);
    }

    // 종료 시간 재설정
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
