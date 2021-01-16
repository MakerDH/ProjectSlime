using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public enum Majin
{
//      고블린, 오거, 오니, 아수라
    non, Goblin, OGRE , Oni , Asura
}

public enum Beast : ushort
{
    //  검은 늑대, 스타 울프, 케르베로스, 펜릴
    non, BlackWolf, StarWolf, Kerberos, Fenrir
}
public enum Draconic : ushort
{
    //  리자드맨, 드라고 뉴트, 용, 용왕
    non, Lizardman, Dragonewt, Dragon, DragonKing
}
public enum Monster : ushort
{
    //  스파이더, 킹 스파이더, 아난시, 인섹트킹
    non, Spider, KingSpider, Anansi, InsectKing
}

public enum Demons : ushort
{
    //  데몬, 아크데몬, 데몬로드, 태초의 악마
    non, Demon, ArchDemon, DemonRord, DemonOrigin
}

public enum Undead : ushort
{
    //  스켈레톤, 해골기사, 엘더리치, 오버로드
    non, Skeleton, DeathKnight, ElderRich, OverLord
}

public enum Humans : ushort
{
    //  인간, 검사, 성검사, 용사
    non, Human, Knight, HoliKnight, Hero 
}
public enum Dwarfs : ushort
{
    //  드워프, 전사, 광전사, 토르
    non, Dwarf, warrior, Berserker, Thor
}
public enum Elfs : ushort
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


public class Slime
{
    public Majin majin;         public Majin Majin { get { return majin; } set { majin = value; } }
    public uint majinCore;      public uint MajinCore { get {return majinCore; } set { majinCore = value; } }    

    public Beast beast;         public Beast Beast { get { return beast; } set { beast = value; } }
    public uint beastCore;      public uint BeastCore { get { return beastCore; } set { beastCore = value; } }

    public Draconic draconic;   public Draconic Draconic { get { return draconic; } set { draconic = value; } }
    public uint draconicCore;   public uint DraconicCore { get { return draconicCore; } set { draconicCore = value; } }

    public Monster monster;     public Monster Monster { get { return monster; } set { monster = value; } }
    public uint monsterCore;    public uint MonsterCore { get { return monsterCore; } set { monsterCore = value; } }

    public Demons demons;       public Demons Demons { get { return demons; } set { demons = value; } }
    public uint demonsCore;     public uint DemonsCore { get { return demonsCore; } set { demonsCore = value; } }

    public Undead undead;       public Undead Undead { get { return undead; } set { undead = value; } }
    public uint undeadCore;     public uint UndeadCore { get { return undeadCore; } set { undeadCore = value; } }

    public Humans humans;       public Humans Humans { get { return humans; } set { humans = value; } }
    public uint humansEssence;  public uint HumansEssence { get { return humansEssence; } set { humansEssence = value; } }

    public Dwarfs dwarfs;       public Dwarfs Dwarfs { get { return dwarfs; } set { dwarfs = value; } }
    public uint dwarfsEssence;  public uint DwarfsEssence { get { return dwarfsEssence; } set { dwarfsEssence = value; } }
    
    public Elfs elfs;           public Elfs Elfs { get { return elfs; } set { elfs = value; } }
    public uint elfsEssence;    public uint ElfsEssence { get { return elfsEssence; } set { elfsEssence = value; } }

    public Slime()     
    {
        majin = 0;  beast = 0;  draconic = 0;   monster = 0;    demons = 0;    undead = 0;    humans = 0;    dwarfs = 0;    elfs = 0;
        majinCore = 0; beastCore = 0; demonsCore = 0; demonsCore = 0; undeadCore = 0;  humansEssence = 0; dwarfsEssence = 0; elfsEssence = 0;
    }
}


public class Slimes : MonoBehaviour
{
    [SerializeField]
    private ushort level; public ushort Level { get { return level; } }     
 
    [SerializeField]
    private string name; public string Name { get {  return  name; } }

    [SerializeField]
    private ushort index; public ushort Index { get { return index; } set { index = value; } }


    private Slime slime;

    private void Start()
    {
        //버튼 스크립트에 이벤트 연결
        GetComponent<UnityEngine.UI.Button>().onClick.AddListener(delegate { Click(); });
    }

    public void Init()
    {
        slime = new Slime();
    }

    public void SetLevel()
    {

    }



    public void Click()
    {
        Debug.Log("click Slime " + gameObject.name);

        Alter_Manager.Instance.AlterSlimeInfo(Index);
    }
}
