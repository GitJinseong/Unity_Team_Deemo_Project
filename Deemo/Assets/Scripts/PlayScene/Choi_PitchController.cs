using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Choi_PitchController : MonoBehaviour
{
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        float key = Park_GameManager.instance.key;
        float pitch;

        if (key == 1.5f)
        {
            pitch = 0.5f;
        }
        else if (key == 5.0f)
        {
            pitch = 1.0f;
        }
        else if (key == 9.0f)
        {
            pitch = 1.5f;
        }
        else if (key > 1.5f && key < 5.0f)
        {
            // 1.5�� 5.0 ���� ���� ��� ������ �����Ͽ� �߰� pitch �� ����
            pitch = (key - 1.5f) * 0.1f + 0.5f;
        }
        else if (key > 5.0f && key < 9.0f)
        {
            // 5.0�� 8.5 ���� ���� ��� ������ �����Ͽ� �߰� pitch �� ����
            pitch = (key - 5.0f) * 0.1f + 1.0f;
        }
        else
        {
            // �⺻�� ���� (���ϴ� key ���� ���� ���)
            pitch = 1.0f;
        }

        audioSource.pitch = pitch;
    }
}
