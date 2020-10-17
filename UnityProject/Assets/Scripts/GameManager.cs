using System.Collections;
using System.Collections.Generic;
using UnityEditor.Android;
using UnityEngine;

public class GameManager : MonoBehaviour
{  
    /// <summary>
    /// 싱글턴 인스턴트
    /// </summary>
    protected static GameManager instance;
    public static GameManager Instance { get { return instance; } }
    //-------------------------------------------------------------//

    /// <summary>
    /// 악마, 촉수, 저주, 마물, 언데드, 자연, 천사
    /// </summary>
    ulong ulong_resource_evil, ulong_resource_teil, ulong_resource_curse, ulong_resource_monster, 
        ulong_resource_undead, ulong_resource_nature, ulong_resource_angle;

    /// <summary>
    /// 플레이어 레벨
    /// </summary>
    ushort ushort_maxLevel, ushort_curLevel;

    private void Awake()
    {
        //싱글턴 인스턴트 생성------
        if (instance)
        {
            DestroyImmediate(gameObject);
            return;
        }
        instance = this;
        //--------------------------

        //제거 방지
        DontDestroyOnLoad(gameObject);
    }

    /// <summary>
    /// 초기화
    /// </summary>
    private void Init()
    {
        ulong_resource_evil = 0;
        ulong_resource_teil = 0;
        ulong_resource_curse = 0;
        ulong_resource_monster = 0;
        ulong_resource_undead = 0;
        ulong_resource_nature = 0;
        ulong_resource_angle = 0;

        ushort_maxLevel = 10;
        ushort_curLevel = 1;
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


}
