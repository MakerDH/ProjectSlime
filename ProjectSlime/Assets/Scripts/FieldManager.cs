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

    //변수
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

        while (0.02f < Vector2.Distance(rt_field_map.anchoredPosition, vec2_fieldMap_origin_pos))
        {

            rt_field_map.anchoredPosition = Vector2.Lerp(rt_field_map.anchoredPosition, vec2_fieldMap_origin_pos, Time.deltaTime * m_movespeed);

            //yield return new WaitForSeconds(0.1f);
            yield return new WaitForEndOfFrame();

           
        }

        rt_field_map.anchoredPosition = vec2_fieldMap_origin_pos;
    }

    public string DungeonInfomation(int n)
    {
        string test = string.Format("전투력 {0}\n속성 저주\n이동시간 3분\n추천레벨 30", (DungeonType)n);
        return test;
    }

    public void DungeonStart()
    {
        Debug.Log("startDungeon");
    }
}
