using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameResourceManger : MonoBehaviour
{
    protected static GameResourceManger instance;
    public static GameResourceManger Instance { get { return instance; } }
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

    //================================//
    private uint[] resources;
    private ushort[] updataBase;


    private Coroutine resourceUpdate;

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
        ResourceInitialize();
        UpdateBaceInitialize();

        resourceUpdate = StartCoroutine(ResourceUpdate());
    }

    public void ResourceInitialize()
    {
        //test code
        resources = new uint[6];
        for (int i = 0; i < resources.Length; ++i)
        {
            resources[i] = 0;
        }
    }
    public void UpdateBaceInitialize()
    { 
        //test code
        updataBase = new ushort[6];
        for (int i = 0; i < updataBase.Length; ++i)
        {
            updataBase[i] = 1;
        }
    }


    IEnumerator ResourceUpdate()
    {
        while(true)//null != resourceUpdate)
        {
            for(int i = 0; i< resources.Length; ++i)
            {
                resources[i] += updataBase[i];
            }
            yield return new WaitForSeconds(1f);
        }
        
    }

    public uint Get_Resources(int i){ return resources[i]; }
    public void Set_Resources(int i, uint n) { resources[i] = n; }
    public uint Get_UpdataBase(int i) { return updataBase[i]; }
    public void Set_UpdataBase(int i, ushort n) { updataBase[i] = n; }
}
