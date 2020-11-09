using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetButtonState : MonoBehaviour
{
    public GameObject[] buttons;

    public Animator[] scenes;

    private int nowSceneNum;

    private void Start()
    {
        nowSceneNum = 0;
       
        for(int i = 1; i< buttons.Length; ++i)
        {
            scenes[i].SetTrigger("Off");
            buttons[i].SetActive(true);
        }
    }

    public void Set_DisableButton(int buttonNum)
    {
        scenes[buttonNum].SetTrigger("On");
        buttons[buttonNum].SetActive(false);

        scenes[nowSceneNum].SetTrigger("Off");
        buttons[nowSceneNum].SetActive(true);                

        nowSceneNum = buttonNum;
    }
}
