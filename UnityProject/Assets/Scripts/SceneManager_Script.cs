using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager_Script : MonoBehaviour
{
    public string str_target_sceneName;

    private void Start()
    {
       //// Screen.SetResolution(1440, 2560, false);
        RescaleCamera();
    }

    /// <summary>
    /// test code , 1번씬 불러옴
    /// </summary>
    public void SceneNext()
    {       
        SceneManager.LoadScene(str_target_sceneName);
    }

    private int ScreenSizeX = 0;
    private int ScreenSizeY = 0;
    private void RescaleCamera()
    {

        if (Screen.width == ScreenSizeX && Screen.height == ScreenSizeY) return;

        float targetaspect = 9f / 16.0f;
        float windowaspect = (float)Screen.width / (float)Screen.height;
        float scaleheight = windowaspect / targetaspect;
        Camera camera = Camera.main;// GetComponent<Camera>();

        if (scaleheight < 1.0f)
        {
            Rect rect = camera.rect;

            rect.width = 1.0f;
            rect.height = scaleheight;
            rect.x = 0;
            rect.y = (1.0f - scaleheight) / 2.0f;

            camera.rect = rect;
        }
        else // add pillarbox
        {
            float scalewidth = 1.0f / scaleheight;

            Rect rect = camera.rect;

            rect.width = scalewidth;
            rect.height = 1.0f;
            rect.x = (1.0f - scalewidth) / 2.0f;
            rect.y = 0;

            camera.rect = rect;
        }

        ScreenSizeX = Screen.width;
        ScreenSizeY = Screen.height;
    }
}
