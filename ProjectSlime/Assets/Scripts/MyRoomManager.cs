﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}