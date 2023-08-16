using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TransparencyController
{
    public static IEnumerator BeginLateFadeOutImage(Image image, float lateDuration, float fadeDuration)
    {
        yield return new WaitForSeconds(lateDuration);

        float targetOpacity = 0f; // ��ǥ ���� (���� ����)
        float startOpacity = image.color.a; // ���� ����

        float startTime = Time.time;

        while (Time.time < startTime + fadeDuration)
        {
            float elapsedTime = Time.time - startTime;
            float percentage = elapsedTime / fadeDuration;
            float currentOpacity = Mathf.Lerp(startOpacity, targetOpacity, percentage);

            Color newColor = image.color;
            newColor.a = currentOpacity;
            image.color = newColor;

            yield return null;
        }

        // ������ ���� ������ �ǵ��� ����
        Color finalColor = image.color;
        finalColor.a = targetOpacity;
        image.color = finalColor;
    }

    public static IEnumerator FadeOutImage(Image image, float fadeDuration)
    {
        float targetOpacity = 0f; // ��ǥ ���� (���� ����)
        float startOpacity = image.color.a; // ���� ����

        float startTime = Time.time;

        while (Time.time < startTime + fadeDuration)
        {
            float elapsedTime = Time.time - startTime;
            float percentage = elapsedTime / fadeDuration;
            float currentOpacity = Mathf.Lerp(startOpacity, targetOpacity, percentage);

            Color newColor = image.color;
            newColor.a = currentOpacity;
            image.color = newColor;

            yield return null;
        }

        // ������ ���� ������ �ǵ��� ����
        Color finalColor = image.color;
        finalColor.a = targetOpacity;
        image.color = finalColor;
    }
}
