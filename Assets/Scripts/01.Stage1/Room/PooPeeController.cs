using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PooPeeController : MonoBehaviour
{
    // GameObject poo;

    // Update is called once per frame
    void Update()
    {
        // gameObject.GetComponent<Renderer>().material.col

        //pooPos.GetComponent<SpriteRenderer>().bounds.Contains(pooPos);
        if (Input.GetMouseButtonDown(0))
        {
            //ȭ���� ��ǥ�踦 ���� ��ǥ��� ��ȯ���ִ� �Լ�
            Vector2 pooPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(pooPos, Vector2.zero);

            if (hit.collider != null)
            { 
                Debug.Log(hit.collider.gameObject.name);
                string touchObject = hit.collider.gameObject.name;      // ��ġ�� ������Ʈ��

                if(touchObject == "Poo1Prefab(Clone)" || touchObject == "Poo2Prefab(Clone)")
                {
                    // �躯�� ��ġ�ߴٸ�
                    if (PlayerPrefs.GetInt("stage") == 2)
                    {
                        UnityEngine.SceneManagement.SceneManager.LoadScene("Poo2Scene");
                    }
                    else
                    {
                        UnityEngine.SceneManagement.SceneManager.LoadScene("Poo1Scene");
                    }
                }
                else if(touchObject == "Pee1Prefab(Clone)" || touchObject == "Pee2Prefab(Clone)")
                {
                    // �Һ��� ��ġ�ߴٸ�
                    UnityEngine.SceneManagement.SceneManager.LoadScene("Pee1Scene");
                }
                else if(touchObject == "puppyDay" || touchObject == "puppyNight")
                {
                    if (PlayerPrefs.GetInt("stage") == 2)
                    {
                        // �������� ��ġ�ߴٸ�
                        UnityEngine.SceneManagement.SceneManager.LoadScene("TouchPetScene");
                    }
                    else
                    {
                        // �������� ��ġ�ߴٸ�
                        UnityEngine.SceneManagement.SceneManager.LoadScene("Touch1Scene");
                    }  
                }

            }
        }
    }
}
