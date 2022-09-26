using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feeding : MonoBehaviour
{
   // public Animator waterup;
    public Animator foodup;

    void Start()
    {
        //waterup.SetBool("IsWater",false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.CompareTag("WaterBottle"))
        {
            Debug.Log("dd");
            //waterup.SetBool("IsWater", true);
        }
    }

    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {

    }
}
