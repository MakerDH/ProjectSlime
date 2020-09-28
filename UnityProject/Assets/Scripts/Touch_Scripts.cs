using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Touch_Scripts : MonoBehaviour
{
    /// <summary>
    /// 마우스 눌렸는지 파악
    /// </summary>
    private bool bool_mouseButtonStay;
    
    
    /// <summary>
    /// 마우스 클릭다운 시점 좌표
    /// </summary>
    private Vector2 vec2_mouseButtonDownPos;

    /// <summary>
    /// 카메라 위치
    /// </summary>
    private Vector3 vec3_cameraPos;

    /// <summary>
    /// 마우스 좌표계 수정
    /// </summary>
    public Vector2 vec2_mousePos;
    
    /// <summary>
    /// 화면 해상도의 절반
    /// </summary>
    private float screen_height, screen_wdith;

    /// <summary>
    /// 초기 카메라 위치
    /// </summary>
    private Vector3 vec3_cameraOriginalPos;

    /// <summary>
    /// 카메라 위치 초기화 코루틴
    /// </summary>
    private Coroutine cor_CameraReset;


    // Start is called before the first frame update
    void Start()
    {
        Initialized();
    }

    // Update is called once per frame
    void Update()
    {
        vec2_mousePos = new Vector2(Input.mousePosition.x - screen_wdith, Input.mousePosition.y - screen_height);


        CameraMove();

    }

    /// <summary>
    /// 변수 초기화
    /// </summary>
    private void Initialized()
    {
        bool_mouseButtonStay = false;
        vec2_mouseButtonDownPos = Vector2.zero;
        vec3_cameraPos = transform.position;
        vec3_cameraOriginalPos = transform.position;
        //vec3_cameraPos = Vector3.zero;

        screen_height = (Screen.height / 2);
        screen_wdith = (Screen.width / 2);

        cor_CameraReset = null;

        
    }

    /// <summary>
    /// 카메라를 움직여 맵 탐색 기능
    /// </summary>
    void CameraMove()
    {
        //마우스 좌클릭다운
        if (Input.GetMouseButtonDown(0))
        {
            if(null != cor_CameraReset) StopCoroutine(cor_CameraReset);

            bool_mouseButtonStay = true;

            vec2_mouseButtonDownPos = vec2_mousePos;
        }

        //마우스 좌클릭업
        if (Input.GetMouseButtonUp(0))
        {
            cor_CameraReset = StartCoroutine("CameraMovetoPosZero");

            bool_mouseButtonStay = false;

            vec3_cameraPos = transform.position;
        }

        //터치-스크롤한 방향으로 이동
        if (bool_mouseButtonStay)
        {
            Vector2 vec2_temp = (vec2_mouseButtonDownPos - vec2_mousePos) / 52;

            //Debug.Log(vec2_temp);

            transform.position = (vec3_cameraPos + (Vector3)vec2_temp) ;            
        }
    }

    /// <summary>
    /// 카메라 초기 위치 되돌리기
    /// </summary>
    /// <returns></returns>
    IEnumerator CameraMovetoPosZero()
    {
        yield return new WaitForSeconds(1.5f);

        float temp_speed = 10f;

        while (0.01f <= Vector3.Distance(transform.position , vec3_cameraOriginalPos))
        {
            yield return new WaitForEndOfFrame();
            
            transform.position = Vector3.Lerp(transform.position, vec3_cameraOriginalPos, Time.deltaTime * temp_speed);

            if(3f > Vector3.Distance(transform.position, vec3_cameraOriginalPos))
            {
                temp_speed += 10;
            }
        }

        vec3_cameraPos = transform.position = vec3_cameraOriginalPos;
    }
}
