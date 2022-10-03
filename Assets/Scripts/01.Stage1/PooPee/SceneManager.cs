using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public GameObject spray;
    public GameObject tissue;
    public GameObject water;

    // Start is called before the first frame update
    void Start()
    {
        spray.SetActive(false);
        tissue.SetActive(false);
        water.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
