using System.Collections;
using System.Collections.Generic;
using UnityEngine;




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

    [SerializeField]
    private List<Slimes> slimes;


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
        GameObject[] objects = GameObject.FindGameObjectsWithTag("SlimeClone");

        for (ushort i = 0; i < objects.Length; ++i)
        {
            slimes.Add(objects[i].GetComponent<Slimes>());
            Debug.Log(slimes[i].gameObject.name);
            slimes[i].Index = i;
        }
    }

    public void AlterSlimeInfo(int _index)
    {
        string _str = string.Format("이름 {0}", slimes[_index].Index);

        UI_Manager.Instance.Click_Alter(_str);
    }
}
