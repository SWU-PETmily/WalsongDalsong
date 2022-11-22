using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Door2PetController : MonoBehaviour
{
    public bool isDay;            // ≥∑π„ »Æ¿Œ ∫Øºˆ
    public bool isSnell;          // ∏Ò¡Ÿ »Æ¿Œ ∫Øºˆ
    public bool isClothes;        // ø  »Æ¿Œ ∫Øºˆ

    public Sprite imgDaySnell;                  // ≥∑ ∏Ò¡Ÿ
    public Sprite imgNightSnell;                // π„ ∏Ò¡Ÿ
    public Sprite imgDayClothes;                // ≥∑ ø 
    public Sprite imgNightClothes;              // π„ ø 
    public Sprite imgDaySnellClothes;           // ≥∑ ∏Ò¡Ÿ ø 
    public Sprite imgNightSnellClothes;         // π„ ∏Ò¡Ÿ ø 

    void Start()
    {
        // ≥∑π„ »Æ¿Œ »ƒ ¿ÃπÃ¡ˆ ∫Ø∞Ê
        Door2TimeManager door2TimeManager = GameObject.Find("TimeManager").GetComponent<Door2TimeManager>();
        isDay = door2TimeManager.isDay;
    }

    void Update()
    {
        // ∏Ò¡Ÿ »Æ¿Œ ∫Øºˆ
        Item2Controller item2Controller1 = GameObject.Find("snell").GetComponent<Item2Controller>();
        isSnell = item2Controller1.isSnell;
        // ø  »Æ¿Œ ∫Øºˆ
        Item2Controller item2Controller2 = GameObject.Find("clothes").GetComponent<Item2Controller>();
        isClothes = item2Controller2.isClothes;

        // ≥∑¿Ã∂Û∏È
        if (isDay == true)
        {
            if (isSnell == true && isClothes == true)
            {
                this.gameObject.GetComponent<Image>().sprite = imgDaySnellClothes;       // ≥∑ ∏Ò¡Ÿ ø 
            }
            else
            {
                if (isSnell == true)
                {
                    this.gameObject.GetComponent<Image>().sprite = imgDaySnell;       // ≥∑ ∏Ò¡Ÿ
                }
                else if (isClothes == true)
                {
                    this.gameObject.GetComponent<Image>().sprite = imgDayClothes;       // ≥∑ ø 
                }
            }
        }
        // π„¿Ã∂Û∏È
        else
        {
            if (isSnell == true && isClothes == true)
            {
                this.gameObject.GetComponent<Image>().sprite = imgNightSnellClothes;       // π„ ∏Ò¡Ÿ ø 
            }
            else if(isSnell == true && isClothes == false)
            {
                this.gameObject.GetComponent<Image>().sprite = imgNightSnell;       // π„ ∏Ò¡Ÿ
            }
            else if (isSnell == false && isClothes == true)
            {
                this.gameObject.GetComponent<Image>().sprite = imgNightClothes;       // π„ ø 
            }
        }
    }
}
