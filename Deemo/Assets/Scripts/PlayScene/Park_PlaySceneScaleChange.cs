using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Park_PlaySceneScaleChange : MonoBehaviour
{
    public float scaleStart;
    public float scaleEnd;
    public float duration;
    private float originalScaleY;

    // Start is called before the first frame update
    void Start()
    {
        originalScaleY = GetComponent<Transform>().localScale.y;

        StartCoroutine(ScaleChange());
    }

    private IEnumerator ScaleChange()
    {
        float timeElapsed = 0.0f;

        while (timeElapsed < duration)
        {
            // �ð� ����� ���� ������ �� ����
            timeElapsed += Time.deltaTime;

            // Lerp ���� 0 ~ 1 ���̷� ��ȯ
            float time = Mathf.Clamp01(timeElapsed / duration);

            // ������ ���� ����Ͽ� ������ ���� ����
            GetComponent<Transform>().localScale = new Vector2(Mathf.Lerp(scaleStart, scaleEnd, time), originalScaleY);

            yield return null;
        }
    }
}
