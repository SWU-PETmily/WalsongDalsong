using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Door2PetController : MonoBehaviour
{
    public bool isDay;            // ���� Ȯ�� ����
    public bool isSnell;          // ���� Ȯ�� ����
    public bool isClothes;        // �� Ȯ�� ����

    public Sprite imgDaySnell;                  // �� ����
    public Sprite imgNightSnell;                // �� ����
    public Sprite imgDayClothes;                // �� ��
    public Sprite imgNightClothes;              // �� ��
    public Sprite imgDaySnellClothes;           // �� ���� ��
    public Sprite imgNightSnellClothes;         // �� ���� ��

    void Start()
    {
        // ���� Ȯ�� �� �̹��� ����
        Door2TimeManager door2TimeManager = GameObject.Find("TimeManager").GetComponent<Door2TimeManager>();
        isDay = door2TimeManager.isDay;
    }

    void Update()
    {
        // ���� Ȯ�� ����
        Item2Controller item2Controller1 = GameObject.Find("snell").GetComponent<Item2Controller>();
        isSnell = item2Controller1.isSnell;
        // �� Ȯ�� ����
        Item2Controller item2Controller2 = GameObject.Find("clothes").GetComponent<Item2Controller>();
        isClothes = item2Controller2.isClothes;

        // ���̶��
        if (isDay == true)
        {
            if (isSnell == true && isClothes == true)
            {
                this.gameObject.GetComponent<Image>().sprite = imgDaySnellClothes;       // �� ���� ��
            }
            else
            {
                if (isSnell == true)
                {
                    this.gameObject.GetComponent<Image>().sprite = imgDaySnell;       // �� ����
                }
                else if (isClothes == true)
                {
                    this.gameObject.GetComponent<Image>().sprite = imgDayClothes;       // �� ��
                }
            }
        }
        // ���̶��
        else
        {
            if (isSnell == true && isClothes == true)
            {
                this.gameObject.GetComponent<Image>().sprite = imgNightSnellClothes;       // �� ���� ��
            }
            else if(isSnell == true && isClothes == false)
            {
                this.gameObject.GetComponent<Image>().sprite = imgNightSnell;       // �� ����
            }
            else if (isSnell == false && isClothes == true)
            {
                this.gameObject.GetComponent<Image>().sprite = imgNightClothes;       // �� ��
            }
        }
    }
}
