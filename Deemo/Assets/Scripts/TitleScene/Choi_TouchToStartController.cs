using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Choi_TouchToStartController : MonoBehaviour
{
    public float delay = 0.1f; // ������
    public int blinkInterval = 10;  // ���� ���� ����
    public float stopTime = 2f; // ������ 1�� �� �� ������ �ð�

    private Image image;
    private float currentOpacity = 1f; // ���� ���� (1�� ���� ������, 0�� ���� ����)
    private bool increasingOpacity = true; // ���� ���� ����
    private bool isWaiting = false; // ��� ���� ����
    private bool isBlinkingInReverse = false; // ���� ���� ����

    private void Start()
    {
        image = GetComponent<Image>();
        StartCoroutine(BlinkCoroutine());
    }

    // ���� ���� �Լ�
    public void SetTransparency()
    {
        if (isWaiting) return;

        if (increasingOpacity)
        {
            currentOpacity += blinkInterval * 0.01f; // blinkInterval ���� 0.01�� ����� ���� ���� ����
            currentOpacity = Mathf.Clamp01(currentOpacity); // 0�� 1 ���̷� ���� ����
            if (currentOpacity >= 1f && !isWaiting)
            {
                increasingOpacity = false;
                if (isBlinkingInReverse)
                {
                    StartCoroutine(WaitAndStartBlinking());
                    isBlinkingInReverse = false;
                }
            }
        }
        else
        {
            currentOpacity -= blinkInterval * 0.01f; // blinkInterval ���� 0.01�� ����� ���� ���� ����
            currentOpacity = Mathf.Clamp01(currentOpacity); // 0�� 1 ���̷� ���� ����
            if (currentOpacity <= 0f)
            {
                increasingOpacity = true;
                isBlinkingInReverse = true;
            }
        }
        Color currentColor = image.color;
        currentColor.a = currentOpacity; // alpha ���� ����
        image.color = currentColor;
    }

    private IEnumerator BlinkCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            SetTransparency();
        }
    }

    private IEnumerator WaitAndStartBlinking()
    {
        isWaiting = true; // ��� ���·� ����
        yield return new WaitForSeconds(stopTime); // 2�� ���
        isWaiting = false; // ��� ���� ����
        increasingOpacity = true; // ���� ��ȭ �簳
    }
}