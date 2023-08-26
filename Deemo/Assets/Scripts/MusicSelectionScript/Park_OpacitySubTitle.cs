using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Park_OpacitySubTitle : MonoBehaviour
{
    private Park_ScrollSubTitle park_ScrollSubTitle;

    // ������Ʈ canvasGroup�� �����ϱ� ���� ����
    private CanvasGroup canvasGroup;

    // ������Ʈ RectTransform �� �ҷ����� ���� ����
    private RectTransform rectTransform;

    // ����������� ���������� ��ǥ(y)
    private float alphaDistance = 280.0f;

    // ���� ��ǥ(y)
    private float distance = 0.0f;

    private int count;

    // Start is called before the first frame update
    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        rectTransform = GetComponent<RectTransform>();

        count = transform.GetSiblingIndex();
    }

    // Update is called once per frame
    void Update()
    {
        park_ScrollSubTitle = GameObject.Find("TextTitleSub").GetComponent<Park_ScrollSubTitle>();

        if (Mathf.Abs(count * 15.0f + park_ScrollSubTitle.speed) <= 60)
        {
            canvasGroup.alpha = 1.0f - Mathf.Abs(count * 15.0f + park_ScrollSubTitle.speed) / 60.0f;
        }
        else
        {
            canvasGroup.alpha = 0.0f;
        }

        //distance = alphaDistance - Mathf.Abs(rectTransform.anchoredPosition.y);

        //canvasGroup.alpha = Mathf.Clamp01(distance / alphaDistance);
    }
}
