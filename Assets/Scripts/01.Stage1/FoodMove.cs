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
    [SerializeField] GameObject Feed;
    [SerializeField] GameObject Feedbowl;

    
    [SerializeField] GameObject Food1;
    [SerializeField] GameObject Food2;

    void Start()
    {
        imPos = obj.GetComponent<RectTransform>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        defaultposition = this.transform.position;
        // RotatingImage();
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 currentPos = Input.mousePosition;
        this.transform.position = currentPos;
    }

    public void OnEndDrag(PointerEventData eventData)
    {

        this.transform.position = defaultposition;
        Food1.SetActive(true);
        Food2.SetActive(false);
        Feed.SetActive(false);
        

    }

    public void RotatingImage()
    {
        transform.eulerAngles = new Vector3(0, 0, -40);
        // transform.Rotate(new Vector3(-15, -15, -10), Space.Self);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("bowl"))
        {
            Feed.SetActive(true);
            Feedbowl.SetActive(true);
            RotatingImage();
        }
    }

}
