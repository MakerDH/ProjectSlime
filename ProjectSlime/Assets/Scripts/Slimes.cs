using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public enum Majin
{
//      고블린, 오거, 오니, 아수라
    non, Goblin, OGRE , Oni , Asura
}

public enum Beast 
{
    //  검은 늑대, 스타 울프, 케르베로스, 펜릴
    non, BlackWolf, StarWolf, Kerberos, Fenrir
}
public enum Draconic 
{
    //  리자드맨, 드라고 뉴트, 용, 용왕
    non, Lizardman, Dragonewt, Dragon, DragonKing
}
public enum Monster
{
    //  스파이더, 킹 스파이더, 아난시, 인섹트킹
    non, Spider, KingSpider, Anansi, InsectKing
}

public enum Demons
{
    //  데몬, 아크데몬, 데몬로드, 태초의 악마
    non, Demon, ArchDemon, DemonRord, DemonOrigin
}

public enum Undead
{
    //  스켈레톤, 해골기사, 엘더리치, 오버로드
    non, Skeleton, DeathKnight, ElderRich, OverLord
}

public enum Humans
{
    //  인간, 검사, 성검사, 용사
    non, Human, Knight, HoliKnight, Hero 
}
public enum Dwarfs
{
    //  드워프, 전사, 광전사, 토르
    non, Dwarf, warrior, Berserker, Thor
}
public enum Elfs
{
    //  엘프, 궁사, 마궁사, 요정왕
    non, elf, Archer, magicArcher, Oberon
}

public enum SlimeType : ushort
{    
    normal,
    white,
    red,
    blue,
    green,
    black
}

public class Race 
{
    public Majin majin;
    public Beast beast;
    public Draconic draconic;
    public Monster monster;
    public Demons demons;
    public Undead undead;
    public Humans humans;
    public Dwarfs dwarfs;
    public Elfs elfs;
}


public class Slimes : MonoBehaviour
{
    [SerializeField]
    private SlimeType type; public SlimeType Type { get { return type; } }

    [SerializeField]
    private ushort level; public ushort Level { get { return level; } }
     
 
    [SerializeField]
    private string name; public string Name { static get {  return  name; } }


    [SerializeField]
    private ushort index; public ushort Index { get { return index; } set { index = value; } }


    private void Start()
    {
        //버튼 스크립트에 이벤트 연결
        GetComponent<UnityEngine.UI.Button>().onClick.AddListener(delegate { Click(); });
    }


    public void SetLevel()
    {

    }

    public void Click()
    {
        Debug.Log("click " + gameObject.name);

        FieldManager.Instance.DungeonInfomation(Index);
    }
}
