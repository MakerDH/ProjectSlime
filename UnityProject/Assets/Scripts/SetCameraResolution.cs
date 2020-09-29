using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCameraResolution : MonoBehaviour
{
    /// <summary>
    /// 픽셀/유닛
    /// </summary>
    public int pixelperUnit = 32;

    /// <summary>
    /// 메인 카메라
    /// </summary>
    public Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera.orthographicSize = Screen.height / (pixelperUnit + 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
/*
 * 
unit 계산식
Resolution_height / (2 * camera_size)
ex) 1080x1920, camera_size == 10-> 1 unit == 96 pixel
   이때 1x1 size texture에
	pixels per unit을 96으로 하면 1x1해상도로 출력됨
	pixels per unit을 1으로 하면 96x96해상도로 출력됨

ex2) 1080x1920, camera_size == 960-> 1 unit == 1 pixel
    이때 1x1 size texture에
	 pixels per unit을 1/96으로 하면 96x96해상도로 출력됨
	 pixels per unit을 1으로 하면 1x1해상도로 출력됨

-Canvas의 RenderMode가 screen Space - Overlay/Camera 일때 Width, Height가 해상도에 고정되므로
 UI - Image	를 생성하여 Image에 Width, Height 수치를 조절해보면서 확인 할 수 있다.
*/