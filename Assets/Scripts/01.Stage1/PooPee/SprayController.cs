using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SprayController : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public static Vector2 defaultposition;
    GameObject stain;
    public GameObject water;
    public GameObject tissue;
    public GameObject posSpray;       // 스프레이 이동 위치

    // 바꿀 이미지
    public Sprite img_spray_ing;
    public Sprite img_spray;
    public Sprite img_water;

    Vector2 fp1;
    Vector2 fp2;
    float d2 = 0.0f;
    bool actSpray = false;

    private Animator animator;
    Vector3 rotation = new Vector3(0, 0, 40);         // 스프레이  기울기
    bool isCollision = false;                    // 충돌 확인 변수

    // Start is called before the first frame update
    void Start()
    {
        this.stain = GameObject.Find("stain1");

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


        if (d < r1 + r2+300.0f)
        {
            isCollision = true;
            this.transform.position = posSpray.transform.position;       //스프레이 이동
            this.transform.localEulerAngles = rotation;        //스프레이 기울이기
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
        water.GetComponent<Image>().sprite = this.img_water;       // 물방울 더 보이기
        actSpray = true;
        Destroy(gameObject, 2);                 // 스프레이 삭제
    }

    void Tissue()
    {
        tissue.SetActive(true);      // 티슈 보이기
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!isCollision)
        {
            defaultposition = this.transform.position;
        }

    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!isCollision)
        {
            Vector2 currentPos = Input.mousePosition;
            this.transform.position = currentPos;
        }

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!isCollision)
        {
            this.transform.position = defaultposition;
        }

    }
}
