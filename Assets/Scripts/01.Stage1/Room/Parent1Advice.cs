using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


// 변수 초기화 && 가상부모 칭찬/경고
public class Parent1Advice : MonoBehaviour
{
    public Text dialogText;
    public GameObject dialogBox;
    public GameObject mom;

    public int dialogNum;       // 대사 번호
    public bool good = true;    // 칭찬/경고
    public int level;           // 칭찬/경고 단계
    string petName;      // 펫이름

    // 바꿀 이미지
    public Sprite momSmile;     // 웃는 엄마
    public Sprite momAngry;     // 화난 엄마

    void Start()
    {

        // 임시 변수
        PlayerPrefs.SetInt("goodLevel", 1);
        PlayerPrefs.SetInt("badLevel", 1);
        PlayerPrefs.SetInt("feedNum", 1);
        PlayerPrefs.SetInt("pooCleaningNum", 3);
        PlayerPrefs.SetInt("peeCleaningNum", 3);

        petName = PlayerPrefs.GetString("name");
        dialogNum = 0;

        // 가상 부모 칭찬 레벨 없다면
        if (!PlayerPrefs.HasKey("goodLevel"))
            PlayerPrefs.SetInt("goodLevel", 1);
        // 가상 부모 경고 레벨 없다면
        if (!PlayerPrefs.HasKey("badLevel"))
            PlayerPrefs.SetInt("badLevel", 1);

        GoodOrBad();    // 칭찬 or 경고 분류
        showDialog();   // 첫 번째 구문 보여주기    
        ResetNum();     // 하루 변수 초기화
    }

    // 버튼 클릭 함수
    public void ClickBtn()
    {
        if (good == true)
        {
            if (level == 2)
            {
                Good1();
            }
            else
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("Card1Scene");
            }
        }
        else
        {
            if (level == 2)
            {
                Bad1();
            }
            else
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("Room1Scene");
            }
        }
    }

    // 칭찬 대사
    void Good1()
    {
        dialogNum = dialogNum + 1;
        switch (dialogNum)
        {
            case 1:
                dialogText.text = "해야할 일을 모두 해줬으니 선물을 줄게! 강아지의 의사 소통 신호를 파악할 수 있는 카밍시그널을 확인할 수 있는 카드야.";
                break;
            case 2:
                dialogText.text = "앞으로 하루 할 일을 모두 끝냈을 때마다 한 장씩 줄게. 네가 이 카드로 좀 더 "+ petName+"(이)를 이해할 수 있으면 좋겠어.";
                break;
            case 3:
                UnityEngine.SceneManagement.SceneManager.LoadScene("Card1Scene");
                break;
            default:
                break;
        }
    }

     // 경고 대사
    void Bad1()
    {
        dialogNum = dialogNum + 1;
        switch (dialogNum)
        {
            case 1:
                dialogText.text = "돌보는 방법이 헷갈리는 거 같으니 다시 얘기해줄게.";
                break;
            case 2:
                dialogText.text = "하루에 식사를 2회, 배변 처리를 2회, 소변 처리를 2회 해주어야 한단다!";
                break;
            case 3:
                UnityEngine.SceneManagement.SceneManager.LoadScene("Room1Scene");
                break;
            default:
                break;
        }
    }

    // 칭찬 or 경고 분류
    void GoodOrBad()
    {
        int feedNum = PlayerPrefs.GetInt("feedNum");
        int pooCleaningNum = PlayerPrefs.GetInt("pooCleaningNum");
        int peeCleaningNum = PlayerPrefs.GetInt("peeCleaningNum");
        // int touchingNum = PlayerPrefs.GetInt("touchingNum");

        // 칭찬 조건을 충족한다면
        if (feedNum>=2 && pooCleaningNum >=2 && peeCleaningNum >= 2)
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
        if(good == true)
        {
            level = PlayerPrefs.GetInt("goodLevel");
            if(level == 1)
            {
                dialogText.text = "와~ 집이 엄청 깨끗하네? " + petName + "(이)를 잘 돌봐줬구나. 정말 대견해.";
            }else if (level == 2)
            {
                dialogText.text = "어제 " + petName + "(이)의 밥 그릇을 보니까 싹 비워져있더라? 다 네가 잘 돌봐줘서야. 잘했어!";
            }
            else
            {
                dialogText.text = "엄마 없을 때도 " + petName + "(이)를 잘 돌봐줬구나? 정말 잘했어~";
            }
            PlayerPrefs.SetInt("goodLevel", level++);
        }
        // 경고라면
        else
        {
            level = PlayerPrefs.GetInt("badLevel");
            if (level == 1)
            {
                dialogText.text = " 강아지를 돌볼 때는 세심한 관심이 필요해. 이 점 주의해주렴!";
            }
            else if (level == 2)
            {
                dialogText.text = "다음부터는 " + petName + "(이)를 까먹지 말고 잘 챙겨줘";
            }
            else
            {
                dialogText.text = "오늘 많이 바쁘게 보냈나 보구나. 그래도 " + petName + "(이)도 신경써주렴!";
            }
            PlayerPrefs.SetInt("badLevel", level++);
        }
    }

    // 하루 먹이주기, 배소변관리, 쓰다듬기 횟수 리셋
    void ResetNum()
    {
        PlayerPrefs.SetInt("feedNum", 0);
        PlayerPrefs.SetInt("pooCleaningNum", 0);
        PlayerPrefs.SetInt("peeCleaningNum", 0);
        PlayerPrefs.SetInt("touchingNum", 0);
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
