using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ResetSettingObjects : MonoBehaviour
{
    public float fadeDuration = 1.0f; // ���̵� �ƿ��� �ɸ��� �ð� (��)
    public float targetAlpha = 0.5f; // ���̵� �ƿ��� �Ϸ�� ���� ���İ�

    private float currentTime = 0f; // ���� ��� �ð�

    private Image[] childImages; // �ڽ� �̹��� ������Ʈ �迭
    private TMP_Text[] childTexts; // �ڽ� TMP �ؽ�Ʈ ������Ʈ �迭

    private Color[] originalImageColors; // ���� �̹��� ���� �迭
    private Color[] originalTextColors; // ���� TMP �ؽ�Ʈ ���� �迭

    // ���̵� �ƿ� ȿ���� �����ϴ� �Լ�
    public void StartFadeOut()
    {
        currentTime = 0f; // ���̵� �ƿ� ���۽� ���� �ð��� �ʱ�ȭ�մϴ�.
        gameObject.SetActive(true); // ��ũ��Ʈ�� Ȱ��ȭ�� ������Ʈ�� Ȱ��ȭ�մϴ�.

        // �̹��� ������Ʈ�� ã�Ƽ� ���̵� �ƿ� ȿ���� �����մϴ�.
        childImages = GetComponentsInChildren<Image>();
        originalImageColors = new Color[childImages.Length];
        for (int i = 0; i < childImages.Length; i++)
        {
            originalImageColors[i] = childImages[i].color;
            StartFadeOutImage(childImages[i]);
        }

        // �̹����� �ڽ� ������Ʈ���� TMP �ؽ�Ʈ ������Ʈ�� ã�Ƽ� ���̵� �ƿ� ȿ���� �����մϴ�.
        childTexts = GetComponentsInChildren<TMP_Text>();
        originalTextColors = new Color[childTexts.Length];
        for (int i = 0; i < childTexts.Length; i++)
        {
            originalTextColors[i] = childTexts[i].color;
            StartFadeOutText(childTexts[i]);
        }
    }

    private void Update()
    {
        // ���̵� �ƿ� ȿ���� �����մϴ�.
        if (currentTime < fadeDuration)
        {
            currentTime += Time.deltaTime;
        }
    }

    // �̹��� ���̵� �ƿ� ȿ���� �����մϴ�.
    private void StartFadeOutImage(Image image)
    {
        StartCoroutine(FadeOutCoroutine(image, originalImageColors));
    }

    // TMP �ؽ�Ʈ ���̵� �ƿ� ȿ���� �����մϴ�.
    private void StartFadeOutText(TMP_Text text)
    {
        StartCoroutine(FadeOutCoroutine(text, originalTextColors));
    }

    // ���̵� �ƿ� �ڷ�ƾ �Լ�
    private IEnumerator FadeOutCoroutine(Graphic graphic, Color[] originalColors)
    {
        float startAlpha = graphic.color.a;

        while (currentTime < fadeDuration)
        {
            currentTime += Time.deltaTime;
            float normalizedTime = currentTime / fadeDuration;
            float currentAlpha = Mathf.Lerp(startAlpha, targetAlpha, normalizedTime);

            Color color = originalColors[0];
            color.a = currentAlpha;
            graphic.color = color;

            yield return null;
        }

        // ���̵� �ƿ��� ���� ��, ������ ��ǥ ���İ����� �����մϴ�.
        Color finalColor = originalColors[0];
        finalColor.a = targetAlpha;
        graphic.color = finalColor;
    }
}
