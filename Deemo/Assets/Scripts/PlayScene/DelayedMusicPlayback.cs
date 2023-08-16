using UnityEngine;

public class DelayedMusicPlayback : MonoBehaviour
{
    private AudioSource musicSource; // ������ ����� AudioSource ������Ʈ
    public float delayInSeconds = 1.0f; // ���� �ð� (��) // �⺻ 1��

    private bool isMusicStarted = false;
    private float elapsedTime = 0.0f;

    private void Awake()
    {
        musicSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (!isMusicStarted)
        {
            elapsedTime += Time.deltaTime;

            if (elapsedTime >= delayInSeconds)
            {
                StartMusic();
            }
        }
    }

    private void StartMusic()
    {
        musicSource.Play();
        isMusicStarted = true;
    }
}
