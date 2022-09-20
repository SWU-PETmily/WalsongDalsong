using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MouseBehavior : MonoBehaviour
{

    public GameObject waterbottle1;
    public GameObject waterbottle2;

    void Start()
    {

        waterbottle2.SetActive(false);
    }

    public void ClickOn()
    {
        waterbottle2.SetActive(true);
        waterbottle1.SetActive(false);
    }

}


