using UnityEngine;

public class ButtonSound : MonoBehaviour
{
    public AudioClip buttonClickSound;
    public float volume = 1.0f; // ���� ũ�⸦ ������ ����

    // ����� Ŭ���� ����ϸ� ���� �������ؼ� ����� �ҽ��� ����
    // ����ϰ� ������.
    private AudioSource audioSource;

    private void Awake()
    {
        // AudioSource ������Ʈ�� �߰��ϰ� �����ɴϴ�.
        audioSource = gameObject.AddComponent<AudioSource>();
        // AudioClip�� �����մϴ�.
        audioSource.clip = buttonClickSound;

        // AudioSource�� null�� �ƴ� ���, playOnAwake �Ӽ��� false�� �����մϴ�.
        if (audioSource != null)
        {
            audioSource.playOnAwake = false;
        }
    }

    public void PlayButtonClickSound()
    {
        // ��ư Ŭ�� �Ҹ��� ����ϰ� ���� ũ�⸦ �����մϴ�.
        if (buttonClickSound != null)
        {
            audioSource.volume = volume;
            audioSource.Play();
        }
    }
}