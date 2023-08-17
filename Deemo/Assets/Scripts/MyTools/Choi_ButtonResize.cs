using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class Choi_ButtonResize : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler, IPointerEnterHandler
{
    private RectTransform buttonRectTransform;
    private Vector2 originalScale;
    private bool isPressed = false;
    private bool isReleased = false;
    private bool isResizing = false;
    private bool isPointerOverButton = false;
    private bool isPointerDown = false;
    public float resizeScale = 0.93f; // Ŭ���� ���¿��� ũ�⸦ ���̴� ����
    public float resizeDuration = 0.3f; // ũ�� ������ �ɸ��� �ð�

    private void Start()
    {
        buttonRectTransform = GetComponent<RectTransform>();
        originalScale = buttonRectTransform.localScale;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isPointerDown = true;
        isPressed = true;
        isReleased = false;
        ResizeButtonImage(resizeScale); // �̹��� ����� ���
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (isPressed && !isReleased)
        {
            isPressed = false;
            isReleased = true;

            if (!isPointerOverButton)
            {
                ResetButtonImageScale(); // ���콺 Ŀ���� ��ư ������ �̵����� �� �̹��� ����� ���� ũ��� �ǵ���
            }
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isPointerOverButton = false;
        if (isPressed && !isReleased)
        {
            isPressed = false;
            isReleased = true;
            ResetButtonImageScale(); // ���콺 Ŀ���� ��ư ������ �̵����� �� �̹��� ����� ���� ũ��� �ǵ���
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isPointerOverButton = true;
    }

    private void Update()
    {
        if (isPointerDown && !isReleased)
        {
            // ��ư�� ����Ʈ�Ǿ� ������ ���¿��� �߰����� ������ ���Ѵٸ� ���⿡ �ʿ��� ������ �߰��ϼ���.
        }
    }

    private void ResizeButtonImage(float scaleFactor)
    {
        isResizing = true;
        buttonRectTransform.localScale = originalScale * scaleFactor;

        // �̹��� ����� ����� ��, �ǹ��� �����Ͽ� �߾� ���� ����
        buttonRectTransform.pivot = new Vector2(0.5f, 0.5f);

        isResizing = false;

        // ������ ���� �ڷ�ƾ ����
        StartCoroutine(InterpolateButtonScale(originalScale * scaleFactor, resizeDuration));
    }

    public void ResetButtonImageScale()
    {
        StartCoroutine(InterpolateButtonScale(originalScale, resizeDuration));
    }

    private IEnumerator InterpolateButtonScale(Vector2 targetScale, float duration)
    {
        float timeElapsed = 0.0f;
        Vector2 startScale = buttonRectTransform.localScale;

        while (timeElapsed < duration)
        {
            timeElapsed += Time.deltaTime;
            float t = Mathf.Clamp01(timeElapsed / duration);
            buttonRectTransform.localScale = Vector2.Lerp(startScale, targetScale, t);
            yield return null;
        }

        buttonRectTransform.localScale = targetScale;
    }
}
