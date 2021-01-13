using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DungeonType :ushort
{
    resource_0,
    resource_1,
    resource_2,
    resource_3,
    resource_4,
    resource_5,
    normal,
    gold,
    experience,
    boss        
}

public class Dungeon : MonoBehaviour
{
    [SerializeField]
    private ushort item; public ushort Item { get { return item; } }

    [SerializeField]
    private DungeonType type; public DungeonType Type { get { return type; } }

    [SerializeField]
    private ushort level; public ushort Level { get { return level; }  }

    [SerializeField]
    private float durationTime; public float DurationTime { get { return durationTime; } }

    [SerializeField]
    private string name; public string Name { get { return name; } }

    [SerializeField]
    private ushort index; public ushort Index { get { return index; } set { index = value; } }

    private void Start()
    {
        //버튼 스크립트에 이벤트 연결
        GetComponent<UnityEngine.UI.Button>().onClick.AddListener(delegate { Click(); });
    }
    

    public void Click()
    {
        Debug.Log("click " + gameObject.name);

        FieldManager.Instance.DungeonInfomation(Index);
    }
}
