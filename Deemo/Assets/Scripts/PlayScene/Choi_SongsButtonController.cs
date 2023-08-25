using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Choi_SongsButtonController : MonoBehaviour
{
    public Choi_LoadScene loadScene;

    public void CallSongScene()
    {
        Time.timeScale = 1.0f;
        loadScene.Run(0f, "MusicSelectionSceneLoad");
    }
}
