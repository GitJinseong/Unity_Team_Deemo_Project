using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Choi_HomeButtonController : MonoBehaviour
{
    public Choi_LoadScene loadScene;

    public void CallLoadScene()
    {
        Time.timeScale = 1.0f;
        loadScene.Run(0f, "MainSceneLoad");
    }
}
