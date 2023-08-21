using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Park_TitleLoadSceneOpacity : MonoBehaviour
{
    private Image image;

    public bool isCheck;

    public float duration;

    void Start()
    {
        image = GetComponent<Image>();
    }

    void Update()
    {
        if (isCheck == true)
        {
            StartCoroutine(StartOpacity());

            isCheck = false;
        }
    }

    private IEnumerator StartOpacity()
    {
        Color startColor = image.color; // ���� ����
        Color endColor = new Color(startColor.r, startColor.g, startColor.b, 0.0f); // �� ���� (���� ����)

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
