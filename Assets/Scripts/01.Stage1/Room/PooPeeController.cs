using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PooPeeController : MonoBehaviour
{
    // GameObject poo;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // gameObject.GetComponent<Renderer>().material.col

        //pooPos.GetComponent<SpriteRenderer>().bounds.Contains(pooPos);
        if (Input.GetMouseButtonDown(0))
        {
            //화면의 좌표계를 월드 좌표계로 전환해주는 함수
            Vector2 pooPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(pooPos, Vector2.zero);

            if (hit.collider != null)
            { 
                Debug.Log(hit.collider.gameObject.name);
                string touchObject = hit.collider.gameObject.name;      // 터치된 오브젝트명

                if(touchObject == "Poo1Prefab(Clone)" || touchObject == "Poo2Prefab(Clone)")
                {
                    // 배변을 터치했다면
                    SceneManager.LoadScene("Poo1Scene");

                }
                else if(touchObject == "Pee1Prefab(Clone)" || touchObject == "Pee2Prefab(Clone)")
                {
                    // 소변을 터치했다면
                    SceneManager.LoadScene("Pee1Scene");
                }

            }
        }
    }
}
