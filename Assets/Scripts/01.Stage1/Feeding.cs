using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBowl : MonoBehaviour
{
    public GameObject waterup;
    void Start()
    {
        waterup.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.CompareTag("waterbottle"))
        {
            Debug.Log("dd");
            waterup.SetActive(true);
        }
    }

    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {

    }
}
