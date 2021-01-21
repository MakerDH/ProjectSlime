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
        if (instance)
        {
            DestroyImmediate(gameObject);
            return;
        }
        instance = this;

        DontDestroyOnLoad(gameObject);
    }

    //맵 제어
    //============================================//
    public RectTransform rt_field_map;
    private Vector2 vec2_fieldMap_origin_pos;
    public float m_movespeed;
    //============================================//
    [SerializeField]
    private List<Dungeon> dungeons;

    public void Init()
    {
        vec2_fieldMap_origin_pos = rt_field_map.anchoredPosition;

        GameObject[] objects = GameObject.FindGameObjectsWithTag("Dungeons");

        for (ushort i = 0; i < objects.Length; ++i)
        {
            dungeons.Add(objects[i].GetComponent<Dungeon>());
            Debug.Log(dungeons[i].gameObject.name);
            dungeons[i].Index = i;
        }
         
    }

    // Start is called before the first frame update
    void Start()
    {
       // Init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        if(Input.GetMouseButtonDown(0) && null != mapReset)
        {
            StopCoroutine(mapReset);
            mapReset = null;
        }
    }


    private Coroutine mapReset;
    public void Button_Map_Reset()
    {
        mapReset = StartCoroutine(Map_Reset_move());
    }

    IEnumerator Map_Reset_move()
    {   

        while (0.02f < Vector2.Distance(rt_field_map.anchoredPosition, vec2_fieldMap_origin_pos))
        {

            rt_field_map.anchoredPosition = Vector2.Lerp(rt_field_map.anchoredPosition, vec2_fieldMap_origin_pos, Time.deltaTime * m_movespeed);

            //yield return new WaitForSeconds(0.1f);
            yield return new WaitForEndOfFrame();

           
        }

        rt_field_map.anchoredPosition = vec2_fieldMap_origin_pos;
        //mapReset = null;
    }

    public void DungeonInfomation(int _index)
    {
        string _string = string.Format("던전 이름 {0}\n자원 종류{1}\n자원량 {2}\n추천레벨 {3}\n채집시간 {4}",
            dungeons[_index].Name,
            dungeons[_index].Type,
            dungeons[_index].Item,            
            dungeons[_index].Level,
            dungeons[_index].DurationTime                        
            ) ;

        UI_Manager.Instance.Click_Dungeon(_string);
    }

    public void DungeonStart()
    {
        Debug.Log("startDungeon");
    }
}
