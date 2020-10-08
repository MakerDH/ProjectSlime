using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager_Script : MonoBehaviour
{
    public string str_target_sceneName;

    /// <summary>
    /// test code , 1번씬 불러옴
    /// </summary>
    public void SceneNext()
    {       
        SceneManager.LoadScene(str_target_sceneName);
    }
}
