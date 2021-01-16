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
    enum UI_Buttons : int
    {
        MyRoom = 0,
        Field = 1,
        Alter = 2,
        Store = 4
        //MyRoom ,
        //Field ,
        //Alter ,
        //Store 
    }


    //====================//

    [Header("UI_base")]
    //text
    public Text[] tx_rec;//    public Text tx_rec_b;    public Text tx_rec_c;    public Text tx_rec_d;    public Text tx_rec_e;    public Text tx_rec_f;

    //button
    public GameObject[] bt_Maps;

    //cavas map
    public GameObject[] Maps;

    //image
    public GameObject loading;

    private Coroutine ui_Update;

    [Header("Filed")]
    #region Filed
    //field tap
    public GameObject dungeonInfo;
    public Text tx_dungeonInfo;
    #endregion

    [Header("Alter")]
    #region Slime
    public GameObject slimeInfo;
    public Text tx_slimeInfo;
    #endregion

    [Header("Castle")]
    #region Castle
    public GameObject castleInfo_Level;
    public Text tx_CastleInfo_Level;

    public GameObject castleInfo_Skill;
    public Text tx_CastleInfo_Skill;

    public Text[] tx_temp_rec;
    #endregion


    // Start is called before the first frame update
    void Start()
    {
        Init();
    }


    IEnumerator UI_Update()
    {

        while (true) //null != ui_Update)
        {
            Debug.Log("uiupdate");
            yield return new WaitForSeconds(1f);

            for (int i = 0; i < tx_rec.Length; ++i)
            {
                tx_rec[i].text = GameResourceManger.Instance.Get_Resources(i).ToString();
            }
        }
    }


    public void Init()
    {
        loading.SetActive(false);

        ui_Update = StartCoroutine(UI_Update());
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


    
    #region Filed
    public void Click_Dungeon(string str)
    {
        tx_dungeonInfo.text = str;
        
        dungeonInfo.SetActive(true);
    }

    public void Click_Dungeon_Start()
    {
        dungeonInfo.SetActive(false);
        FieldManager.Instance.DungeonStart();
    }

    public void Click_Dungeon_Cancle()
    {
        dungeonInfo.SetActive(false);
    }
    #endregion

    
    #region Alter
    public void Click_Alter(string _str)
    {
        slimeInfo.SetActive(true);
        tx_slimeInfo.text = _str;
    }
    #endregion

    #region Castle
    public void Click_Castle_Level()
    {
        castleInfo_Level.SetActive(true);
        tx_CastleInfo_Level.text = "계산전";
    }

    public void Click_Add_Resource(int n, uint _rec)
    {
        tx_temp_rec[n].text = _rec.ToString();
    }
    public void Set_NextLevel_Calculate()
    {
        tx_CastleInfo_Level.text = "계산후";
    }

    public void Click_Cansle_LevelUp()
    {
        castleInfo_Level.SetActive(false);
        MyCastleManager.Instance.Click_Cansle_LevelUp();

        for(int i = 0; i<tx_temp_rec.Length; ++i)
        {
            tx_temp_rec[i].text = "0";
        }

    }

    public void Click_Castle_Skill()
    {
        castleInfo_Skill.SetActive(true);
        tx_CastleInfo_Skill.text = "";
    }


    #endregion
}
