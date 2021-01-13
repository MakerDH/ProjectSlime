using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum OriginalSlimeType:ushort
{
    normal,
    goblin,


    mao
}



public class MyRoomManager : MonoBehaviour
{
    protected static MyRoomManager instance;
    public static MyRoomManager Instance { get { return instance; } }
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

    //========================//
    private ushort slimeMaxLevel; public ushort SlimeMaxLevel { get { return slimeMaxLevel; } set { slimeMaxLevel += value; } }
    private ushort slimeLevel; public ushort SlimeLevel { get { return slimeLevel; } set { slimeLevel += value; } }



    //========================//


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}



/*
 * 진화 과정
================================
마인 majin
고블린, 오거, 오니, 아수라
Goblin / OGRE / Oni / Asura
================================
마수 Beast
검은 늑대, 스타 울프, 케르베로스, 펜릴
blackWolf, starWolf, Kerberos, Fenrir
================================
용족 Draconic
리자드맨, 드라고 뉴트, 용, 용왕
Lizardman, Dragonewt, Dragon, DragonKing
================================
마물 Monster
스파이더, 킹 스파이더, 아난시, 인섹트킹
spider, kingSpider, Anansi, insectKing
================================
악마 Demons
데몬, 아크데몬, 데몬로드, 태초의 악마
demon,archDemon, demonlord, DemonOrigin
================================
언데드 UNDEAD
스켈레톤, 해골기사, 엘더리치, 오버로드
skeleton, deathKnight, ElderRich, overLord
================================
휴먼 humans
인간, 검사, 성검사, 용사
human, knight, holiKnight, Hero
드워프, 전사, 광전사, 토르
Dwarf, warrior, Berserker, Thor
엘프, 궁사, 마궁사, 요정왕
elf, Archer, magicArcher, Oberon
 
 */