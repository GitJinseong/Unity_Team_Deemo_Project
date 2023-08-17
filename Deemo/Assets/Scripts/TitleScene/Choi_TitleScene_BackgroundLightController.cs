using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Choi_TitleScene_BackgroundLightController : MonoBehaviour
{
    public float delay = 0.1f; // ������
    public int blinkInterval = 5; // ���� ���� ����
    public float stopTime = 3f; // ������ 1�� �� �� ������ �ð�
    public float startDelay = 4f; // ���� ���� ������

    private Image image;
    private float currentOpacity = 1f; // ���� ���� (1�� ���� ������, 0�� ���� ����)
    private bool increasingOpacity = true; // ���� ���� ����
    private bool isWaiting = false; // ��� ���� ����

    private void Start()
    {
        image = GetComponent<Image>();
        StartCoroutine(StartAfterDelay());
    }

    // ���� ������ 4�� �ķ� ���ߴ� �ڷ�ƾ
    private IEnumerator StartAfterDelay()
    {
        yield return new WaitForSeconds(startDelay);
        StartCoroutine(BlinkCoroutine());
    }

    // ���� ���� �Լ�
    private void SetTransparency()
    {
        if (isWaiting) return;

        // ���� ����
        currentOpacity += (increasingOpacity ? blinkInterval : -blinkInterval) * 0.01f;
        currentOpacity = Mathf.Clamp01(currentOpacity);

        // �̹����� ���� �������� ���� ����
        image.color = new Color(image.color.r, image.color.g, image.color.b, currentOpacity);

        // ������ 0 �Ǵ� 1�̸� ���� �ڷ�ƾ ����
        if (currentOpacity == 1f || currentOpacity == 0f)
        {
            StartCoroutine(WaitAndStartBlinking());
        }
    }

    // ���� ��ȭ�� �ֱ������� �����ϴ� �ڷ�ƾ
    private IEnumerator BlinkCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            SetTransparency();
        }
    }

    // ���� �ð���ŭ ����ϴ� �ڷ�ƾ
    private IEnumerator WaitAndStartBlinking()
    {
        isWaiting = true; // ��� ���·� ����
        yield return new WaitForSeconds(stopTime);
        isWaiting = false; // ��� ���� ����
        increasingOpacity = !increasingOpacity; // ���� ��ȭ ���� ����
    }
}