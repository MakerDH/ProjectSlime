using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    protected static GameManager instance;
    public static GameManager Instance { get { return instance; } }
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

    // Start is called before the first frame update
    void Start()
    {
        Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Initialize()
    {
        SoundManager.Instance.Init();

        MyRoomManager.Instance.Init();
        FieldManager.Instance.Init();
        Alter_Manager.Instance.Init();
        MyCastleManager.Instance.Init();
        Store_Manager.Instance.Init();

        GameResourceManger.Instance.Init();

        UI_Manager.Instance.Init();
    }

}
