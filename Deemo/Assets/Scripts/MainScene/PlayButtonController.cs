using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButtonController : MonoBehaviour
{
    public LoadScene loadScene = default;

    public void LoadScene()
    {
        // ���� ������ ��ȯ
        loadScene.asyncLoadScene("PlayScene");
    }
}
