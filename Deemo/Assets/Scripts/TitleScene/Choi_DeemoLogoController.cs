using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Choi_DeemoLogoController : MonoBehaviour
{
    public float fadeInDuration = 5f; // ���̵� ���� �Ϸ�Ǵ� �ð�
    private Image image;

    private void Start()
    {
        image = GetComponent<Image>();
        StartCoroutine(FadeInCoroutine());
    }

    private IEnumerator FadeInCoroutine()
    {
        float startAlpha = 0f; // �ʱ� ���İ� (���� ����)
        float endAlpha = 1f; // ��ǥ ���İ� (���� ������)
        float elapsedTime = 0f;

        while (elapsedTime < fadeInDuration)
        {
            elapsedTime += Time.deltaTime;
            float percentage = elapsedTime / fadeInDuration;
            float currentAlpha = Mathf.Lerp(startAlpha, endAlpha, percentage);
            SetAlpha(currentAlpha);
            yield return null;
        }

        SetAlpha(endAlpha); // ���� ���İ��� �����Ͽ� ���� ���������� ����
    }

    // �̹����� ���İ��� �����ϴ� �Լ�
    private void SetAlpha(float alpha)
    {
        Color color = image.color;
        color.a = alpha;
        image.color = color;
    }
}