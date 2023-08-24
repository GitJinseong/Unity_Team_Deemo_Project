using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Park_BtnSetting : MonoBehaviour
{
    public GameObject settingBtn;
    public GameObject btnGroup;

    // ���콺 �����Ͱ� ������Ʈ ���� �ִ��� üũ �ϱ� ���� ����(Camera)
    public Camera mainCamera;

    // ���콺 �����Ͱ� ������Ʈ ���� �ִ��� üũ �ϱ� ���� ����(LayerMask)
    public LayerMask targetLayer;

    // �̹��� ũ�� ������ ���� ����
    private Vector2 orignalScale;
    private Vector2 pressedScale;
    private Vector2 overScale;

    // �̹��� ũ�� ��� ������ ���� ����
    public float pressedMult;
    public float overMult;

    // ũ�� ������ �ε巴�� �ϱ� ���� ����
    private float durationFirst = 0.2f;
    private float durationSecound = 0.1f;

    void Start()
    {
        // �̹��� ũ�� ����
        orignalScale = settingBtn.GetComponent<RectTransform>().localScale;
        pressedScale = orignalScale * pressedMult;
        overScale = orignalScale * overMult;
    }

    private void OnMouseDown()
    {
        StartCoroutine(StartOverScale());

        btnGroup.SetActive(true);
    }

    private IEnumerator StartOverScale()
    {
        float timeElapsed = 0.0f;

        while (timeElapsed < durationFirst)
        {
            // �ð� ����� ���� ������ �� ����
            timeElapsed += Time.deltaTime;

            // Lerp ���� 0 ~ 1 ���̷� ��ȯ
            float time = Mathf.Clamp01(timeElapsed / durationFirst);

            // ������ ���� ����Ͽ� ������ ���� ����
            settingBtn.GetComponent<RectTransform>().localScale = Vector2.Lerp(pressedScale, overScale, time);

            yield return null;
        }

        StartCoroutine(StartOrignalScale());
    }

    private IEnumerator StartOrignalScale()
    {
        float timeElapsed = 0.0f;

        while (timeElapsed < durationSecound)
        {
            // �ð� ����� ���� ������ �� ����
            timeElapsed += Time.deltaTime;

            // Lerp ���� 0 ~ 1 ���̷� ��ȯ
            float time = Mathf.Clamp01(timeElapsed / durationSecound);

            // ������ ���� ����Ͽ� ������ ���� ����
            settingBtn.GetComponent<RectTransform>().localScale = Vector2.Lerp(overScale, orignalScale, time);

            yield return null;
        }
    }
}
