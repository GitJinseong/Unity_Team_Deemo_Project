using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Choi_BackgroundOpacityController : MonoBehaviour
{
    public Image target = default; // ���İ��� ������ ��� �̹���
    private Color originalColor; // ���� ������ �����ϱ� ���� ����
    private Color targetColor; // ��ǥ ������ �����ϱ� ���� ����
    private float duration = 0.5f; // ���İ��� ����Ǵµ� �ɸ��� �ð� (�� ����)
    private float startAlpha = 0f; // ���� ���İ�
    private float targetAlpha = 120f; // ��ǥ ���İ�
    

    private void Start()
    {
        // ���� ������ �����մϴ�.
        originalColor = target.color;
        // ��ǥ ������ �����մϴ�. (���İ��� 120�� ��)
        targetColor = new Color(originalColor.r, originalColor.g, originalColor.b, targetAlpha / 255f);
    }

    // �̹����� ���İ��� �����ϴ� �޼���
    public void ChangeOpacity()
    {
        // �ڷ�ƾ�� �����մϴ�.
        StartCoroutine(ChangeOpacityCoroutine());
    }

    private IEnumerator ChangeOpacityCoroutine()
    {
        float time = 0f; // ��� �ð��� �����ϱ� ���� ����

        while (time < duration)
        {
            // ��� �ð��� ������ŵ�ϴ�.
            time += Time.deltaTime;
            // ������ ���� 0���� 1 ���̰� �ǵ��� Ŭ�����մϴ�.
            float t = Mathf.Clamp01(time / duration);
            // ���İ��� ���� ���İ��� ��ǥ ���İ� ������ ���� ������ �����մϴ�.
            float currentAlpha = Mathf.Lerp(startAlpha, targetAlpha, t);
            // �̹����� ������ ���������� �����Ͽ� ���İ��� �����մϴ�.
            target.color = new Color(originalColor.r, originalColor.g, originalColor.b, currentAlpha / 255f);

            yield return null;
        }
    }
}
