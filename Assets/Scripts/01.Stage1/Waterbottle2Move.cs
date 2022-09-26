using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Waterbottle2Move : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public static Vector2 defaultposition;
    public Animator anim;

    void Start()
    {
        anim.SetBool("IsWaterBottle2", false);
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        defaultposition = this.transform.position;
        anim.SetBool("IsWaterBottle2", true);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 currentPos = Input.mousePosition;
        this.transform.position = currentPos;
    
    }

    public void OnEndDrag(PointerEventData eventData)
    {

        this.transform.position = defaultposition;

    }
}

