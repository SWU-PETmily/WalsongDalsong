using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    /*11
    public Transform target;

    public float smoothSpeed = 3;
    public Vector2 offset;
    public float limitMinX, limitMaxX, limitMinY, limitMaxY;
    float cameraHalfWidth, cameraHalfHeight;
*/

    //22
    public GameObject dayPet;
    public GameObject nightPet;
    Transform tr;
    public float limitMinX, limitMaxX, limitMinY, limitMaxY;
    public bool isDay;          // ³· È®ÀÎ º¯¼ö

    // Start is called before the first frame update
    void Start()
    {
        /*11
        cameraHalfWidth = Camera.main.aspect * Camera.main.orthographicSize;
        cameraHalfHeight = Camera.main.orthographicSize;
        */

        ///22
        //tr = pet.transform;

        // ³·¹ã È®ÀÎ ÈÄ Æê ÄÁÆ®·Ñ·¯ º¯°æ
        WalkSceneManager walkSceneManager = GameObject.Find("SceneManager").GetComponent<WalkSceneManager>();
        isDay = walkSceneManager.isDay;
        if (isDay == true)
        {
            tr = dayPet.transform;
        }
        else
        {
            tr = nightPet.transform;
        }

        //3333333333333
        //this.pet = GameObject.Find("petNew");
    }

    void Update()
    {
        /*333333333333333333333
        Vector3 petPos = pet.transform.position;
        this.transform.position = new Vector3(petPos.x, transform.position.y, transform.position.z);
        */
    }

    private void LateUpdate()
    {
        //22
        
        float x = Mathf.Clamp(tr.position.x, limitMinX, limitMaxX);
        float y = Mathf.Clamp(tr.position.y, limitMinY, limitMaxY);
        transform.position = new Vector3(x, y, -10);
        

        /*111
        Vector3 desiredPosition = new Vector3(
            Mathf.Clamp(target.position.x + offset.x, limitMinX + cameraHalfWidth, limitMaxX - cameraHalfWidth),   // X
            Mathf.Clamp(target.position.y + offset.y, limitMinY + cameraHalfHeight, limitMaxY - cameraHalfHeight), // Y
            -10);                                                                                                  // Z
        transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * smoothSpeed);
        */
    }
}
