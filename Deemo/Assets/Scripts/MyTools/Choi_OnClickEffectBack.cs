using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class Choi_OnClickEffectBack : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler
{
    private RectTransform buttonRectTransform; // ��ư �̹����� RectTransform
    private Vector2 originalScale;         // ��ư�� ���� �������� �����ϱ� ���� ����
    private Vector2 pressedScale;
    private Vector2 overScale;
    private bool isPressed = false;
    private bool isPoint = false;

    public float resizeScale = 0.9f;

    private float durationFirst = 0.2f;
    private float durationSecound = 0.1f;

    private void Start()
    {
        buttonRectTransform = GetComponent<RectTransform>();
        originalScale = buttonRectTransform.localScale;
        pressedScale = originalScale * resizeScale;
        overScale = originalScale * 1.05f;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!isPressed)
        {
            isPressed = true;
            ResizeButtonImage(pressedScale);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (isPressed)
        {
            isPressed = false;

            if (!isPoint)
            {
                ResetButtonImageScale();
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isPoint = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isPoint = false;

        if (isPressed)
        {
            isPressed = false;
            ResetButtonImageScale();
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!isPressed)
        {
            isPressed = true;
            ResizeButtonImage(pressedScale);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (isPoint)
        {
            StartCoroutine(StartOverScale());
            isPressed = false;
        }
    }

    private void Update()
    {
        if (isPressed)
        {
            // ��ư�� ���� ���¿��� �߰����� ������ ���Ѵٸ� ���⿡ �ʿ��� ������ �߰��ϼ���.
        }
    }

    private void ResizeButtonImage(Vector2 scaleFactor)
    {
        buttonRectTransform.localScale = scaleFactor;
    }

    private void ResetButtonImageScale()
    {
        buttonRectTransform.localScale = originalScale;
    }

    private IEnumerator StartOverScale()
    {
        float timeElapsed = 0.0f;

        while (timeElapsed < durationFirst)
        {
            timeElapsed += Time.deltaTime;
            float time = Mathf.Clamp01(timeElapsed / durationFirst);
            buttonRectTransform.localScale = Vector2.Lerp(pressedScale, overScale, time);

            yield return null;
        }

        StartCoroutine(StartOrignalScale());
    }

    private IEnumerator StartOrignalScale()
    {
        float timeElapsed = 0.0f;

        while (timeElapsed < durationSecound)
        {
            timeElapsed += Time.deltaTime;
            float time = Mathf.Clamp01(timeElapsed / durationSecound);
            buttonRectTransform.localScale = Vector2.Lerp(overScale, originalScale, time);

            yield return null;
        }
    }
}
