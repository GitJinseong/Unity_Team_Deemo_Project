using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScene_BackgroundController : MonoBehaviour
{
    public Vector2 initialPosition = Vector2.zero;      // ���� ����
    public Vector2 targetPosition = Vector2.zero;       // ��ǥ ����
    public float duration = 1.0f;                       // �ɸ��� �ð�

    private RectTransform rectTransform;

    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        StartCoroutine(MoveBackgroundCoroutine());
    }

    // Coroutine for moving the background
    private IEnumerator MoveBackgroundCoroutine()
    {
        float timeElapsed = 0f;

        while (timeElapsed < duration)
        {
            // �ð� ����� ���� �Ÿ� �� ����
            timeElapsed += Time.deltaTime;

            // Lerp ���� 0 ~ 1 ���̷� ���� (easeOutQuad �Լ� ���)
            float time = Mathf.Clamp01(timeElapsed / duration);
            time = EaseOutQuad(time);

            // ������ ���� ����Ͽ� ������ ���� ����
            Vector2 newPos = Vector2.Lerp(initialPosition, targetPosition, time);
            rectTransform.anchoredPosition = newPos;

            yield return null;
        }

        // Ensure the final position is reached
        rectTransform.anchoredPosition = targetPosition;
    }

    // ������ �����ߴٰ� ������ �������� ��¡ �Լ� (easeOutQuad)
    private float EaseOutQuad(float t)
    {
        return 1f - Mathf.Pow(1f - t, 2f);
    }
}
