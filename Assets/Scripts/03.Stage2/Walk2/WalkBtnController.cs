using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
