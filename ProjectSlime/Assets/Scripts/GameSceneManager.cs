using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    protected static GameSceneManager instance;
    public static GameSceneManager Instance { get { return instance; } }
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
    //   Scene

    //private void Awake()
    //{
    //    //StartCoroutine(LoadYourAsyncScene(1));        
    //    //StartCoroutine(LoadYourAsyncScene(2));
    //    //StartCoroutine(LoadYourAsyncScene(3));
    //    //StartCoroutine(LoadYourAsyncScene(4));
    //}

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RoadScene(int sceneNum)
    {
        
        //SceneManager.LoadSceneAsync(sceneNum);
        StartCoroutine(LoadYourAsyncScene(sceneNum));
    }

    IEnumerator LoadYourAsyncScene(int sceneNum)
    {        
        // The Application loads the Scene in the background at the same time as the current Scene.
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneNum, LoadSceneMode.Additive);

        // Wait until the last operation fully loads to return anything
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
