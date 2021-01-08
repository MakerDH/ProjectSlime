using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{   
    protected static UI_Manager instance;
    public static UI_Manager Instance { get { return instance; } }
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
    //====================//
    enum UI_Buttons
    {
        MyRoom = 0,
        Field = 1,
        Alter = 2,
        Store = 4
    }


    //====================//

    //text
    public Text tx_rec_a;    public Text tx_rec_b;    public Text tx_rec_c;    public Text tx_rec_d;    public Text tx_rec_e;    public Text tx_rec_f;

    //button
    public GameObject[] bt_Maps;

    //cavas map
    public GameObject[] Maps;

    //image
    public GameObject loading;


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
        loading.SetActive(false);

    }

    public void Maps_Clear() 
    {
        On_Loading();

        for (int i = 0; i < Maps.Length; ++i) Maps[i].SetActive(false);
    }

    public void Click_MyRoom()
    {
        Maps_Clear();

        Maps[(int)UI_Buttons.MyRoom].SetActive(true);
    }
    public void Click_Field()
    {
        Maps_Clear();
        Maps[(int)UI_Buttons.Field].SetActive(true);
    }
    public void Click_Alter()
    {
        Maps_Clear();
        Maps[(int)UI_Buttons.Alter].SetActive(true);
    }
    public void Click_Store()
    {
        Maps_Clear();
        Maps[(int)UI_Buttons.Store].SetActive(true);
    }

    public void On_Loading() { loading.SetActive(true); Invoke("Off_Loading", .07f); }
    public void Off_Loading() { loading.SetActive(false); }


}
