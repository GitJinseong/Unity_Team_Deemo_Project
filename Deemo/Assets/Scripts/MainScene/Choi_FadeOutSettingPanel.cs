using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Choi_FadeOutSettingPanel : MonoBehaviour
{
    public Image img_Panel; // ���̵� �ƿ��� ù ��° �̹���
    public Image img_Bg; // ���̵� �ƿ��� �� ��° �̹���

    public float fadeDuration = 1.0f;
    private float fadeDelay = 0.0f;

    private bool isFading = false; // ���̵� �ƿ� ������ ���θ� �����ϴ� ����

    //********************************************************

    //public GameObject img_Bg_obj;

    //private float timeElapsed = 0.0f;

    //********************************************************

    // �̹��� ���̵� �ƿ� ȿ���� �����ϴ� �Լ�
    public void StartFadeOut()
    {
        if (isFading)
        {
            return;
        }

        StartCoroutine(FadeOutCoroutine());
    }

    private IEnumerator FadeOutCoroutine()
    {
        

        isFading = true;

        img_Panel.raycastTarget = false; // �̹����� Ŭ������ ���ϵ��� Raycast Target�� ��Ȱ��ȭ
        img_Bg.raycastTarget = false;

        //********************************************************
        //(Legacy_01)

        //timeElapsed = 0.0f;

        //while (timeElapsed < fadeDuration)
        //{
        //    timeElapsed += Time.deltaTime;

        //    float time = Mathf.Clamp01(timeElapsed / fadeDuration);

        //    img_Bg_obj.GetComponent<CanvasGroup>().alpha = Mathf.Lerp(0.0f, 1.0f, time);

        //    yield return null;
        //}

        //timeElapsed = 0.0f;

        //Color panelStart = img_Panel.color;
        //Color panelEnd = new Color(panelStart.r, panelStart.g, panelStart.b, 0.0f);

        //while (timeElapsed < fadeDuration)
        //{


        //    timeElapsed += Time.deltaTime;

        //    float time = Mathf.Clamp01(timeElapsed / fadeDuration);

        //    img_Panel.color = Color.Lerp(panelEnd, panelStart, time);

        //    yield return null;
        //}

        //********************************************************
        //********************************************************

        //********************************************************
        float currentTime = 0f;
        float startAlpha1 = img_Panel.color.a;
        float startAlpha2 = img_Bg.color.a;

        while (currentTime < fadeDuration)
        {
            currentTime += Time.deltaTime;
            float normalizedTime = currentTime / 1f;
            float targetAlpha = Mathf.Lerp(startAlpha1, 0f, normalizedTime);

            Color color1 = img_Panel.color;
            color1.a = targetAlpha;
            img_Panel.color = color1;

            Color color2 = img_Bg.color;
            color2.a = targetAlpha;
            img_Bg.color = color2;

            yield return null;
        }

        //���̵� �ƿ��� ���� ��, ������ 0���� �����մϴ�.
        Color finalColor1 = img_Panel.color;
        finalColor1.a = 0f;
        img_Panel.color = finalColor1;

        Color finalColor2 = img_Bg.color;
        finalColor2.a = 0f;
        img_Bg.color = finalColor2;

        img_Panel.raycastTarget = true; // �̹����� ���̵� �ƿ��� ������ �ٽ� Ŭ�� �����ϵ��� Raycast Target Ȱ��ȭ
        img_Bg.raycastTarget = true;

        isFading = false; // ���̵� �ƿ��� �������Ƿ� isFading�� false�� �����մϴ�.
    }
}
