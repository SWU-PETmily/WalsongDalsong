using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class WalkBtnController : MonoBehaviour
{
    public GameObject pet;
    WalkPetController walkPetController;

    // Start is called before the first frame update
    void Start()
    {
        walkPetController = pet.GetComponent<WalkPetController>();
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
