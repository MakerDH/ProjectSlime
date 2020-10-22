using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using System.IO;



public class SlimeJson
{
    public SlimeJson(float _settingTime , float _currentTime ,
                        int _slimeTpye_evil = 0,
                        int _slimeTpye_teil = 0,
                        int _slimeTpye_curse = 0,
                        int _slimeTpye_monster = 0,
                        int _slimeTpye_undead = 0,
                        int _slimeTpye_nature = 0,
                        int _slimeTpye_angle = 0)
    {
        settingTime = _settingTime;
        currentTime = _currentTime;
        slimeTpye_evil = _slimeTpye_evil;
        slimeTpye_teil = _slimeTpye_teil;
        slimeTpye_curse = _slimeTpye_curse;
        slimeTpye_monster = _slimeTpye_monster;
        slimeTpye_undead = _slimeTpye_undead;
        slimeTpye_nature = _slimeTpye_nature;
        slimeTpye_angle = _slimeTpye_angle;
    }

    public float SettingTime { get { return settingTime; } set { settingTime = value; } }
    public float CurrentTime { get { return currentTime; } set { currentTime = value; } }
    public int SlimeTpye_evil { get { return slimeTpye_evil; } set { slimeTpye_evil = value; } }
    public int SlimeTpye_teil { get { return slimeTpye_teil; } set { slimeTpye_teil = value; } }
    public int SlimeTpye_curse { get { return slimeTpye_curse; } set { slimeTpye_curse = value; } }
    public int SlimeTpye_monster { get { return slimeTpye_monster; } set { slimeTpye_monster = value; } }
    public int SlimeTpye_undead { get { return slimeTpye_undead; } set { slimeTpye_undead = value; } }
    public int SlimeTpye_nature { get { return slimeTpye_nature; } set { slimeTpye_nature = value; } }
    public int SlimeTpye_angle { get { return slimeTpye_angle; } set { slimeTpye_angle = value; } }

    public override string ToString()
    {        
        return String.Format("세팅시간 : {0} , 현재시간 : {1} , 악마슬라임 : {2} , 촉수슬라임 : {3} , 저주슬라임 : {4} , 몬스터슬라임 : {5} , 언데드슬라임 : {6} , 자연슬라임 : {7} , 천사슬라임 : {8}"
            , settingTime, currentTime, slimeTpye_evil, slimeTpye_teil, slimeTpye_curse, slimeTpye_monster, slimeTpye_undead, slimeTpye_nature, slimeTpye_angle);

    }

    /// <summary>
    /// json object 이기때문에 public 선언
    /// </summary>
    public float settingTime;
    public float currentTime;
    public int slimeTpye_evil;
    public int slimeTpye_teil;
    public int slimeTpye_curse;
    public int slimeTpye_monster;
    public int slimeTpye_undead;
    public int slimeTpye_nature;
    public int slimeTpye_angle;
}

public class SlimeManager : MonoBehaviour
{
    //파일 경로
    private string strFilePath;
    public string strFileName = "/testText.txt";

    //json 출력용 문자열
    private string json = string.Empty;

    private List<SlimeJson> slime;

    void Awake()
    {
        strFilePath = Application.dataPath; //aditor;project asset folder
    }

    // Start is called before the first frame update
    void Start()
    {
        slime = new List<SlimeJson>();

        //SlimeJson monster = new SlimeJson(1f, 5f );
        //slime.Add(monster);       

        //json += JsonUtility.ToJson(monster) + "\n";
        //json += JsonUtility.ToJson(monster) + "\n";
        //print(json);


        //WriteFile(); //쓰기
        ReadFile(); //읽기
    }


    void WriteFile()
    {
        StreamWriter sw = new StreamWriter(strFilePath + strFileName, false, System.Text.Encoding.Default);
        //기본형 StreamWriter(파일경로);
        //사용오버로드 StreamWriter(파일경로, 덮어쓰기유무-false때 덮어씀, 인코딩방식)

        sw.WriteLine(json); //쓰기

        sw.Flush(); //버퍼를 스트림에 입력 후 버퍼 비움
        sw.Close();
    }



    void ReadFile()
    {
        string[] text = File.ReadAllLines(strFilePath + strFileName, System.Text.Encoding.Default);
        //파일열고 읽어 저장, 라인별로 배열에 저장됨


        SlimeJson[] monsters = new SlimeJson[text.Length];

        for (int i = 0; i < text.Length; ++i)
        {
            //monsters[i] = JsonUtility.FromJson<SlimeJson>(text[i]);

            slime.Add(JsonUtility.FromJson<SlimeJson>(text[i]));

            print( slime[i].ToString() );
        }
    }
}
