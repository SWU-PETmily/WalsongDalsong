using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Waterbottle2Move : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public static Vector2 defaultposition;
    [SerializeField] Animator watervottle2Ani;
    [SerializeField] GameObject waterup;

    [SerializeField] GameObject water1;
    [SerializeField] GameObject water2;
    [SerializeField] Sprite waterimg;

    void Start()
    {

    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        defaultposition = this.transform.position;

    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 currentPos = Input.mousePosition;
        this.transform.position = currentPos;

    }

    public void OnEndDrag(PointerEventData eventData)
    {

        this.transform.position = defaultposition;
        this.GetComponent<Image>().sprite = waterimg;

        watervottle2Ani.SetBool("iswater", false);
        water1.SetActive(true);
        water2.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("bowl"))
        {
            watervottle2Ani.SetBool("iswater", true);
            waterup.SetActive(true);
        }
    }
}

