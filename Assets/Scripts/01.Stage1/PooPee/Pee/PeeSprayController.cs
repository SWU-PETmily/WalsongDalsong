using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeeSprayController : MonoBehaviour
{
    public GameObject stain;
    public GameObject water;
    public GameObject tissueBox2;

    private Animator animator;
    Vector3 destination = new Vector3(6, 2, 0);         // 스프레이 이동 위치
    Vector3 rotation = new Vector3(0, 0, 40);         // 스프레이  기울기

    bool actSpray = false;

    public Sprite img_water;

    // Start is called before the first frame update
    void Start()
    {
        // 애니메이터
        this.animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
     
        // 충돌 검사
        CheckColiision();


    }

    void CheckColiision()
    {
        // 충돌 판정
        Vector2 p1 = transform.position;                // 스프레이 중심 좌표
        Vector2 p2 = this.stain.transform.position;  // 얼룩 중심 좌표
        Vector2 dir = p1 - p2;
        float d = dir.magnitude;
        float r1 = 1.5f;                                // 스프레이 반경
        float r2 = 1.8f;                                // 얼룩 중심 반경

        // 스프레이와 얼룩이 충돌할 경우
        if (d < r1 + r2)
        {
            gameObject.transform.position=destination;        //스프레이 이동
            gameObject.transform.localEulerAngles = rotation;        //스프레이 기울이기
            this.animator.SetTrigger("SprayTrigger");          // 애니메이션 실행
            water.SetActive(true);      //물방울 보이기
            Invoke("Water", 1.9f);
            Invoke("Tissue", 3);
        }
    }

    
    void Water()
    {
        water.GetComponent<SpriteRenderer>().sprite = this.img_water;       // 물방울 더 보이기
        Destroy(gameObject, 1.3f);                 // 스프레이 삭제
    }

    void Tissue()
    {
        tissueBox2.SetActive(true);      // 티슈 보이기
    }
    
}
