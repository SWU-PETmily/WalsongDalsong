using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprayController : MonoBehaviour
{

    GameObject stain;
    public GameObject water;
    public GameObject tissue;

    // 바꿀 이미지
    public Sprite img_spray_ing;
    public Sprite img_spray;
    public Sprite img_water;

    Vector2 fp1;
    Vector2 fp2;
    float d2 = 0.0f;
    bool actSpray = false;

    private Animator animator;
    Vector3 destination = new Vector3(2, -1, 0);         // 스프레이 이동 위치
    Vector3 rotation = new Vector3(0, 0, 40);         // 스프레이  기울기

    // Start is called before the first frame update
    void Start()
    {
        this.stain = GameObject.Find("img_stain");

        // 애니메이터
        this.animator = GetComponent<Animator>();
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
            gameObject.GetComponent<SpriteRenderer>().sprite = this.img_spray;
        }

        if (d < r1 + r2)
        {
            gameObject.transform.Translate(destination);        //스프레이 이동
            gameObject.transform.localEulerAngles = rotation;        //스프레이 기울이기
            this.animator.SetTrigger("SprayTrigger");          // 애니메이션 실행
            water.SetActive(true);      //물방울 보이기
            Invoke("Water", 1.0f);

        }

        if(actSpray == true)
        {
            Invoke("Tissue", 1.9f);
        }

    }

    void Water()
    {
        water.GetComponent<SpriteRenderer>().sprite = this.img_water;       // 물방울 더 보이기
        actSpray = true;
        Destroy(gameObject, 2);                 // 스프레이 삭제
    }

    void Tissue()
    {
        tissue.SetActive(true);      // 티슈 보이기
    }
}
