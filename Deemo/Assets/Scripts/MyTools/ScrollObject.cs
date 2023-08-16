using System.Collections;
using UnityEngine;

public class ScrollObject : MonoBehaviour
{
    public Vector2 initialPosition = Vector2.zero;      // ���� ����
    public Vector2 targetPosition = Vector2.zero;       // ��ǥ ����
    public float duration = 1.0f;                       // �ɸ��� �ð�
    private Coroutine coroutine;
    private RectTransform rectTransform;

    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        coroutine = StartCoroutine(ScrollObjectCoroutine());
    }

    // ��ũ�� �ڷ�ƾ
    private IEnumerator ScrollObjectCoroutine()
    {
        float timeElapsed = 0.0f;

        while (timeElapsed < duration)
        {
            // �ð� ����� ���� �Ÿ� �� ����
            timeElapsed += Time.deltaTime;

            // Lerp ���� 0 ~ 1 ���̷� ����
            float time = Mathf.Clamp01(timeElapsed / duration);

            // ������ ���� ����Ͽ� ������ ���� ����
            Vector2 newPos = Vector2.Lerp(initialPosition, targetPosition, time);
            rectTransform.anchoredPosition = newPos;

            // ���� �����ӱ��� ���
            yield return null;
        }

        // ��ǥ ������ ��Ȯ�ϰ� ��ġ�ϵ��� ����
        rectTransform.anchoredPosition = targetPosition;
    }
}
