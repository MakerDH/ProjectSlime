using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum SlimeType
{
    normal,
    white,
    red,
    blue,
    green,
    black
}

public class Slime
{
    public SlimeType slimeType;
    public ushort level;


}


public class Alter_Manager : MonoBehaviour
{
    protected static Alter_Manager instance;
    public static Alter_Manager Instance { get { return instance; } }
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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
