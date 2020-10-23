using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FieldManager : MonoBehaviour
{
    //----------------------------------------------------//
    //싱글턴
    protected static FieldManager instance;
    public static FieldManager Instance { get { return instance; } }
    //----------------------------------------------------//

    private void Awake()
    {
        //싱글턴 인스턴트
        if(null == instance) { instance = this; }
    }


    public GameObject Dungeon_info;
    public Text tx_dungeon_info;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Button_info_open()
    {
        Dungeon_info.active = true;
    }

    public void Button_info_close()
    {
        Dungeon_info.active = false;
    }
}
