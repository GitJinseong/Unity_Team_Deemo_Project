using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Park_MainSceneOpacity : MonoBehaviour
{
    private Image image;

    public bool isCheck;

    public float duration;

    void Start()
    {
        image = GetComponent<Image>();

        StartCoroutine(StartOpacity());
    }

    void Update()
    {
        if (isCheck == true)
        {
            StartCoroutine(EndOpacity());

            isCheck = false;
        }
    }

    private IEnumerator StartOpacity()
    {
        Color startColor = image.color; // ���� ����
        Color endColor = new Color(startColor.r, startColor.g, startColor.b, 0.0f); // �� ���� (���� ������)

        float timeElapsed = 0.0f;

        while (timeElapsed < duration)
        {
            timeElapsed += Time.deltaTime;

            float time = Mathf.Clamp01(timeElapsed / duration);

            image.color = Color.Lerp(startColor, endColor, time);

            yield return null;
        }
    }

    private IEnumerator EndOpacity()
    {
        Color startColor = image.color; // ���� ����
        Color endColor = new Color(startColor.r, startColor.g, startColor.b, 1.0f); // �� ���� (���� ����)

        float timeElapsed = 0.0f;

        while (timeElapsed < duration)
        {
            timeElapsed += Time.deltaTime;

            float time = Mathf.Clamp01(timeElapsed / duration);

            image.color = Color.Lerp(startColor, endColor, time);

            yield return null;
        }
    }


}
