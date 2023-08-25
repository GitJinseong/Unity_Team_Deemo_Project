using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Choi_ResumeButtonController : MonoBehaviour
{
    public GameObject obj_SettingUI;
    public void DoResume()
    {
        obj_SettingUI.SetActive(false);
        Time.timeScale = 1f;
    }
}
