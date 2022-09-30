using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprayController : MonoBehaviour
{

    GameObject stain;
    GameObject water;

    // 바꿀 이미지
    public Sprite img_spray_pre;
    public Sprite img_spray_ing;
    public Sprite img_spray;
    public Sprite img_water;

    Vector2 fp1;
    Vector2 fp2;
    float d2 = 0.0f;
    bool actSpray = false;

    // Start is called before the first frame update
    void Start()
    {
        this.stain = GameObject.Find("img_stain");
        this.water = GameObject.Find("img_spray_water1");
        water.SetActive(false);

        // 초반 좌표
        fp1 = transform.position;                // 스프레이 중심 좌표
        fp2 = this.stain.transform.position;  // 얼룩 중심 좌표
        Vector2 dir = fp1 - fp2;
        d2 = dir.magnitude;
    }

    // Update is called once per frame
    void Update()
    {
        // 충돌 판정
        Vector2 p1 = transform.position;                // 스프레이 중심 좌표
        Vector2 p2 = this.stain.transform.position;  // 얼룩 중심 좌표
        Vector2 dir = p1 - p2;
        float d = dir.magnitude;
        float r1 = 1.5f;                                // 스프레이 반경
        float r2 = 1.2f;                                // 얼룩 중심 반경



        if (d >= d2  && actSpray==false)
        {
            // 스프레이 초록
            gameObject.GetComponent<SpriteRenderer>().sprite = this.img_spray;
        }
        else
        {
            // 스프레이
            // 제외하기
            gameObject.GetComponent<SpriteRenderer>().sprite = this.img_spray;
        }

        if (d < r1 + r2)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = this.img_spray_ing;
            // +애니메이션 추가하기
            water.SetActive(true);      //물방울 보이기
            water.GetComponent<SpriteRenderer>().sprite = this.img_water;       // 물방울 더 보이기
            gameObject.transform.localPosition = fp1;       // 스프레이 원위치
            gameObject.GetComponent<SpriteRenderer>().sprite = this.img_spray;      // 스프레이 완료 이미지
            actSpray = true;
        }

    }
}
