using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Choi_RayarkLogoController : MonoBehaviour
{
    public float fadeInDuration = 3f; // ���̵� ���� �Ϸ�Ǵ� �ð�
    public float fadeOutDelay = 4f; // ���̵� �ƿ��� ���۵Ǵ� ������ �ð�
    public float fadeOutDuration = 1f; // ���̵� �ƿ��� �Ϸ�Ǵ� �ð�
    private Image image;

    private void Start()
    {
        image = GetComponent<Image>();
        StartCoroutine(FadeInCoroutine());
    }

    private IEnumerator FadeInCoroutine()
    {
        float startTime = Time.time;
        float startAlpha = 0f; // �ʱ� ���İ� (���� ����)
        float endAlpha = 1f; // ��ǥ ���İ� (���� ������)

        while (Time.time < startTime + fadeInDuration)
        {
            float elapsedTime = Time.time - startTime;
            float percentage = elapsedTime / fadeInDuration;
            float currentAlpha = Mathf.Lerp(startAlpha, endAlpha, percentage);

            SetAlpha(currentAlpha);
            yield return null;
        }

        SetAlpha(endAlpha); // ���� ���İ��� �����Ͽ� ���� ���������� ����

        StartCoroutine(FadeOutCoroutine()); // ���̵� ���� �Ϸ�� �� ���̵� �ƿ� ����
    }

    private IEnumerator FadeOutCoroutine()
    {
        yield return new WaitForSeconds(fadeOutDelay);

        float startTime = Time.time;
        float startAlpha = 1f; // �ʱ� ���İ� (���� ������)
        float endAlpha = 0f; // ��ǥ ���İ� (���� ����)

        while (Time.time < startTime + fadeOutDuration)
        {
            float elapsedTime = Time.time - startTime;
            float percentage = elapsedTime / fadeOutDuration;
            float currentAlpha = Mathf.Lerp(startAlpha, endAlpha, percentage);

            SetAlpha(currentAlpha);
            yield return null;
        }

        SetAlpha(endAlpha); // ���� ���İ��� �����Ͽ� ���� �������� ����
    }

    // �̹����� ���İ��� �����ϴ� �Լ�
    private void SetAlpha(float alpha)
    {
        Color color = image.color;
        color.a = alpha;
        image.color = color;
    }
}
