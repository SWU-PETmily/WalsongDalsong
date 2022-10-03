using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class SceneManager : MonoBehaviour
{
    public GameObject spray;
    public GameObject tissueBox;
    public GameObject water;
    public GameObject tissue;

    // Start is called before the first frame update
    void Start()
    {
        spray.SetActive(false);
        tissueBox.SetActive(false);
        water.SetActive(false);
        tissue.SetActive(false);
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
