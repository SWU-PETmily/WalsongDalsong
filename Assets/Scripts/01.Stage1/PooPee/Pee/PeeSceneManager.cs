using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PeeSceneManager : MonoBehaviour
{
    public GameObject spray;
    public GameObject tissueBox2;
    public GameObject water;
    public GameObject tissue1;
    public GameObject tissue2;

    // Start is called before the first frame update
    void Start()
    {
        spray.SetActive(false);
        tissueBox2.SetActive(false);
        water.SetActive(false);
        tissue1.SetActive(false);
        tissue2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void BtnBack()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Room1Scene");
    }
}
