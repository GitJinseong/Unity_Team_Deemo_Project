using UnityEngine;

public class Choi_PauseManager : MonoBehaviour
{
    private bool isPaused = false;

    private void Start()
    {
        //Time.timeScale = 0.5f;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)) // P Ű�� ������ �Ͻ�����/����
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    private void PauseGame()
    {
        Debug.Log("Game Paused");
        Time.timeScale = 0f; // ���� �Ͻ�����
        isPaused = true;
    }

    private void ResumeGame()
    {
        Debug.Log("Game Resumed");
        Time.timeScale = 1f; // ���� ����
        isPaused = false;
    }
}
