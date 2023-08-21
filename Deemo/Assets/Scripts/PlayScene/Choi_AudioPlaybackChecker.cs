using UnityEngine;
using System.Collections;

public class Choi_AudioPlaybackChecker : MonoBehaviour
{
    public AudioSource audioSource; // ����� �ҽ� ������Ʈ
    private float musicDelay = 30.0f;

    private bool isWait = true;

    private void Start()
    {
        StartCoroutine(WaitForStartMusic());
    }

    private void Update()
    {
        if (!audioSource.isPlaying && isWait == false)
        {
            Debug.Log("Audio playback has ended.");
            // ���⿡ ��� ���� �� ������ ���� �߰� ����
        }
    }

    private IEnumerator WaitForStartMusic()
    {
        yield return new WaitForSeconds(musicDelay);
        isWait = false;
    }
}