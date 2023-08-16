using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeInSettingObjects : MonoBehaviour
{
    public float fadeDuration = 10.0f; // ���̵� �ο� �ɸ��� �ð� (��)
    public float targetAlpha = 1.0f; // ���̵� ���� �Ϸ�� ���� ���İ�
    public float scaleMultiplier = 1.1f; // ũ�� ��ȯ ���� ����

    private float currentTime = 0f; // ���� ��� �ð�

    private Image[] childImages; // �ڽ� �̹��� ������Ʈ �迭
    private TMP_Text[] childTexts; // �ڽ� TMP �ؽ�Ʈ ������Ʈ �迭

    private Color[] originalImageColors; // ���� �̹��� ���� �迭
    private Color[] originalTextColors; // ���� TMP �ؽ�Ʈ ���� �迭
    private Vector3[] originalScales; // ���� ũ�� �迭

    public void Awake()
    {
        childImages = GetComponentsInChildren<Image>();
        originalScales = new Vector3[childImages.Length];

        for (int i = 0; i < originalScales.Length; i++)
        {
            originalScales[i] = childImages[i].rectTransform.localScale;
        }
    }

    // ���̵� �� ȿ���� �����ϴ� �Լ�
    public void StartFadeIn()
    {
        currentTime = 0f; // ���̵� �ƿ� ���۽� ���� �ð��� �ʱ�ȭ�մϴ�.
        gameObject.SetActive(true); // ��ũ��Ʈ�� Ȱ��ȭ�� ������Ʈ�� Ȱ��ȭ�մϴ�.

        // �̹��� ������Ʈ�� ã�Ƽ� ���̵� �ƿ� ȿ���� �����մϴ�.
        originalImageColors = new Color[childImages.Length];
        for (int i = 0; i < childImages.Length; i++)
        {
            originalImageColors[i] = childImages[i].color;
            StartFadeOutImage(childImages[i]);
        }

        // �̹����� �ڽ� ������Ʈ���� TMP �ؽ�Ʈ ������Ʈ�� ã�Ƽ� ���̵� �� ȿ���� �����մϴ�.
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
        // ���̵� �� ȿ���� �����մϴ�.
        if (currentTime < fadeDuration)
        {
            currentTime += Time.deltaTime;
        }
    }

    // �̹��� ���̵� �� ȿ���� �����մϴ�.
    private void StartFadeOutImage(Image image)
    {
        StartCoroutine(FadeOutCoroutine(image, originalImageColors, originalScales));
    }

    // TMP �ؽ�Ʈ ���̵� �ƿ� ȿ���� �����մϴ�.
    private void StartFadeOutText(TMP_Text text)
    {
        StartCoroutine(FadeOutCoroutine(text, originalTextColors, null));
    }

    // ���̵� �ƿ� �ڷ�ƾ �Լ�
    private IEnumerator FadeOutCoroutine(Graphic graphic, Color[] originalColors, Vector3[] originalScales)
    {
        float startAlpha = graphic.color.a;
        Vector3 startScale = (originalScales != null) ? originalScales[0] : Vector3.one;

        while (currentTime < fadeDuration)
        {
            currentTime += Time.deltaTime;
            float normalizedTime = currentTime / fadeDuration;
            float currentAlpha = Mathf.Lerp(startAlpha, targetAlpha, normalizedTime); // startAlpha�� targetAlpha�� �ٲ��ݴϴ�.
            float currentScaleMultiplier = Mathf.Lerp(1f, scaleMultiplier, normalizedTime); // ũ�� ��ȯ�� ���� ���� ���

            Color color = originalColors[0];
            color.a = currentAlpha;
            graphic.color = color;

            if (originalScales != null)
            {
                Vector3 scale = startScale * currentScaleMultiplier;
                graphic.rectTransform.localScale = scale;
            }

            yield return null;
        }

        // ���̵� �ƿ��� ���� ��, ������ ũ�⸦ ��ǥ ������ �����մϴ�.
        Color finalColor = originalColors[0];
        finalColor.a = targetAlpha;
        graphic.color = finalColor;

        if (originalScales != null)
        {
            Vector3 finalScale = startScale * scaleMultiplier;
            graphic.rectTransform.localScale = finalScale;
        }
    }
}
