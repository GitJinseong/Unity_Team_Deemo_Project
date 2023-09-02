using UnityEngine;
using UnityEngine.Video;

public class Choi_VideoPlayback : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public string videoFilePath; // ���� ������ ���

    private void Start()
    {
        // ���� ���� �ε� �� �Ҵ�
        videoPlayer.url = videoFilePath;

        // ���� ��� ����
        videoPlayer.Play();
    }
}
