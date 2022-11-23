using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class WalkBtnController : MonoBehaviour
{
    public GameObject dayPet;
    public GameObject nightPet;
    WalkPetController walkPetController;
    public bool isDay;          // 낮 확인 변수

    void Start()
    {
        // 낮밤 확인 후 펫 컨트롤러 변경
        WalkSceneManager walkSceneManager = GameObject.Find("SceneManager").GetComponent<WalkSceneManager>();
        isDay = walkSceneManager.isDay;
        if (isDay == true)
        {
            walkPetController = dayPet.GetComponent<WalkPetController>();
        }
        else
        {
            walkPetController = nightPet.GetComponent<WalkPetController>();
        }
    }

    public void LeftBtnDown()
    {
        walkPetController.LeftMove = true;
    }

    public void LeftBtnUp()
    {
        walkPetController.LeftMove = false;
    }

    public void RightBtnDown()
    {
        walkPetController.RightMove = true;
    }

    public void RightBtnUp()
    {
        walkPetController.RightMove = false;
    }

    public void BackBtnClick()
    {
        PlayerPrefs.SetInt("successWalk", 0);     // 식사 급수 미션 실패
        UnityEngine.SceneManagement.SceneManager.LoadScene("Room2Scene");
    }
}
