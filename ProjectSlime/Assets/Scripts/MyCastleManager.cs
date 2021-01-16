using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Event_Level : ushort
{
    resource_00_up,
    resource_00_down,
    resource_01_up,
    resource_01_down,
    resource_10_up,
    resource_10_down,
    resource_11_up,
    resource_11_down,
    resource_20_up,
    resource_20_down,
    resource_21_up,
    resource_21_down
}





public class MyCastleManager : MonoBehaviour
{
    protected static MyCastleManager instance;
    public static MyCastleManager Instance { get { return instance; } }
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

    private uint[] temp_Resource;

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void Init()
    {
        temp_Resource = new uint[6];
        Reset_Recourse();
    }

    public void Reset_Recourse()
    {
        for(int i = 0; i < temp_Resource.Length; ++i)
        {
            temp_Resource[i] = 0;
        }        
    }



    public void CalculateNextLevel(int n, int _set)
    {
        uint temp = GameResourceManger.Instance.Get_Resources(n);

        if (_set > 0)
        {
            if (temp_Resource[n] + _set > temp)
            {
                temp_Resource[n] = temp;
            }
            else
            {
                temp_Resource[n] = temp_Resource[n] + (uint)_set;
            }
        }
        else
        {
            if ( 0 > temp_Resource[n] + _set )
            {
                temp_Resource[n] = 0;
            }
            else
            {
                temp_Resource[n] = temp_Resource[n] + (uint)_set;
            }
        }

        UI_Manager.Instance.Click_Add_Resource(n, temp_Resource[n]);
        UI_Manager.Instance.Set_NextLevel_Calculate();
    }

    public void Click_Set_Temp_Resource(int e)
    {
        switch ((Event_Level)e)
        {
            case Event_Level.resource_00_up:
                CalculateNextLevel(0, 10);
                break;
            case Event_Level.resource_00_down:
                CalculateNextLevel(0, -10);
                break;

            case Event_Level.resource_01_up:
                CalculateNextLevel(1, 10);
                break;
            case Event_Level.resource_01_down:
                CalculateNextLevel(1, -10);
                break;

            case Event_Level.resource_10_up:
                CalculateNextLevel(2, 10);
                break;
            case Event_Level.resource_10_down:
                CalculateNextLevel(2, -10);
                break;

            case Event_Level.resource_11_up:
                CalculateNextLevel(3, 10);
                break;
            case Event_Level.resource_11_down:
                CalculateNextLevel(3, -10);
                break;

            case Event_Level.resource_20_up:
                CalculateNextLevel(4, 10);
                break;
            case Event_Level.resource_20_down:
                CalculateNextLevel(4, -10);
                break;

            case Event_Level.resource_21_up:
                CalculateNextLevel(5, 10);
                break;
            case Event_Level.resource_21_down:
                CalculateNextLevel(5, -10);
                break;
        }
    }

    
    public void Click_Cansle_LevelUp()
    {
        Reset_Recourse();
    }
}
