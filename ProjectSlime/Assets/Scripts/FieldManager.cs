using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldManager : MonoBehaviour
{
    //싱글턴
    //----------------------------------------------------//
    protected static FieldManager instance;
    public static FieldManager Instance { get { return instance; } }
    //----------------------------------------------------//
    private void Awake()
    {
        //싱글턴 인스턴트
        if (null == instance) { instance = this; }
    }

    //변수
    //============================================//

    public RectTransform rt_field_map;
    private Vector2 vec2_fieldMap_origin_pos;
    public float m_movespeed;
    //============================================//


    public void Init()
    {
        vec2_fieldMap_origin_pos = rt_field_map.anchoredPosition;
    }

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Button_Map_Reset()
    {
        StartCoroutine(Map_Reset_move());
    }

    IEnumerator Map_Reset_move()
    {   
        while (!Vector2.Equals(rt_field_map.anchoredPosition, vec2_fieldMap_origin_pos))
        {

            rt_field_map.anchoredPosition = Vector2.Lerp(rt_field_map.anchoredPosition, vec2_fieldMap_origin_pos, Time.deltaTime * m_movespeed);

            //yield return new WaitForSeconds(0.1f);
            yield return new WaitForEndOfFrame();

           
        }
    }
}
