using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Choi_PlayButtonController : MonoBehaviour
{
    public Choi_LoadScene loadScene = default;

    public void LoadScene()
    {
        // ���� ������ ��ȯ
        loadScene.asyncLoadScene("PlayScene");
    }
}
