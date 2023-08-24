using UnityEngine;

public class Choi_DelayedMusicPlayback : MonoBehaviour
{
    private AudioSource musicSource; // ������ ����� AudioSource ������Ʈ
    public float delayInSeconds = 1.0f; // ���� �ð� (��) // �⺻ 1��

    private bool isMusicStarted = false;
    private float elapsedTime = 0.0f;

    private void Awake()
    {
        musicSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        musicSource.volume = Park_GameManager.instance.bgm * 0.1f;

        for (int i = 0; i < Park_GameManager.instance.musicInformation["Title"].Count; i++)
        {
            if (Park_GameManager.instance.musicInformation["Title"][i] == Park_GameManager.instance.title)
            {
                musicSource.clip = Resources.Load<AudioClip>(Park_GameManager.instance.path + "MusicFileName/" + Park_GameManager.instance.musicInformation["MusicFileName"][i]);
            }
        }
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
