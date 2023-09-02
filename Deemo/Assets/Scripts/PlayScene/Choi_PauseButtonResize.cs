using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class Choi_PauseButtonResize : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler, IPointerEnterHandler
{
    private RectTransform buttonRectTransform;
    private Vector2 originalScale;
    private bool isPressed = false;
    private bool isPointerOverButton = false;
    private bool isPointerDown = false;
    private bool isFirstClick = true; // ó�� ��ư�� �������� ���θ� �Ǵ��ϴ� ����
    private float resizeScale = 0.9f; // ����� ������ ����
    private float resizeDuration = 0.5f; // ũ�� ������ �ɸ��� �ð�

    private void Start()
    {
        buttonRectTransform = GetComponent<RectTransform>();
        originalScale = buttonRectTransform.localScale;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (isFirstClick)
        {
            isFirstClick = false;
            originalScale = buttonRectTransform.localScale; // ó�� ��ư�� ������ �� �������� ������ ���� ����
        }

        isPointerDown = true;
        isPressed = true;
        ResizeButtonImage(resizeScale); // �̹��� ����� ���
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (isPointerDown && isPressed)
        {
            isPressed = false;

            if (!isPointerOverButton)
            {
                ResetButtonImageScale(); // ���콺 Ŀ���� ��ư ������ �̵����� �� �̹��� ����� ���� ũ��� �ǵ���
            }
            else
            {
                ResizeButtonImage(1f); // ���콺 Ŀ���� ��ư ���� ���� �� �̹��� ����� ���� ũ��� �ǵ���
            }
        }

        isPointerDown = false;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isPointerOverButton = false;
        if (isPressed)
        {
            isPressed = false;
            ResetButtonImageScale(); // ���콺 Ŀ���� ��ư ������ �̵����� �� �̹��� ����� ���� ũ��� �ǵ���
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isPointerOverButton = true;
    }

    private void Update()
    {
        if (isPointerDown)
        {
            // ��ư�� ����Ʈ�Ǿ� ������ ���¿��� �߰����� ������ ���Ѵٸ� ���⿡ �ʿ��� ������ �߰��ϼ���.
        }
    }

    private void ResizeButtonImage(float scaleFactor)
    {
        buttonRectTransform.localScale = originalScale * scaleFactor;

        // �̹��� ����� ����� ��, �ǹ��� �����Ͽ� �߾� ���� ����
        buttonRectTransform.pivot = new Vector2(0.5f, 0.5f);

        // ������ ���� �ڷ�ƾ ����
        StopAllCoroutines(); // ������ �ڷ�ƾ �ߴ�
        StartCoroutine(InterpolateButtonScale(originalScale * scaleFactor, resizeDuration));
    }

    public void ResetButtonImageScale()
    {
        StopAllCoroutines(); // ������ �ڷ�ƾ �ߴ�
        StartCoroutine(InterpolateButtonScale(originalScale, resizeDuration));
    }

    private IEnumerator InterpolateButtonScale(Vector2 targetScale, float duration)
    {
        float startTime = Time.realtimeSinceStartup;
        Vector2 startScale = buttonRectTransform.localScale;

        while (Time.realtimeSinceStartup - startTime < duration)
        {
            float elapsedTime = Time.realtimeSinceStartup - startTime;
            float t = Mathf.Clamp01(elapsedTime / duration);
            float easedT = Mathf.SmoothStep(0, 1, t); // ������ ���� 0�� 1 ���̷� �����ǵ��� ���� �Լ� ���
            buttonRectTransform.localScale = Vector2.Lerp(startScale, targetScale, easedT);
            yield return null;
        }

        buttonRectTransform.localScale = targetScale;
    }
}
