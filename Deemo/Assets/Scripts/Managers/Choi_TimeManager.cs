using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Choi_TimeManager : MonoBehaviour
{
    public static Choi_TimeManager instance;

    private void Awake()
    {
        instance = this;
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
    }

    public IEnumerator DelayForPauseGame(float t)
    {
        yield return new WaitForSeconds(t);
        Time.timeScale = 0f;
    }

    public IEnumerator DelayForResumeGame(float t)
    {
        yield return new WaitForSeconds(t);
        Time.timeScale = 1f;
    }
}
