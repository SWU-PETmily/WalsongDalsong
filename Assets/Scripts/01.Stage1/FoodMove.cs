using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FoodMove : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public static Vector2 defaultposition;
    public GameObject obj;
    
    private Transform imPos;
    void Start()
    {
        imPos = obj.GetComponent<RectTransform>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        defaultposition = this.transform.position;
        RotatingImage();
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

   public void RotatingImage()
    {
        transform.Rotate(new Vector3(-15, -15, -10), Space.Self);
    }

   
}
