using System;
using System.Collections;
<<<<<<< HEAD
using UnityEngine;

public class Park_MoveContent : MonoBehaviour
{
    private Coroutine checkCoroutine;
    private Coroutine moveCoroutine;

    private RectTransform rectTransform;

    private float calculatePos;
    private float pastPos;
    private int titleCount;
    private float duration = 1.0f;
    private int currentIndex = -1;

    public bool isScroll;
    public bool isCoroutine = false;
=======
using System.Reflection;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class Park_MoveContent : MonoBehaviour
{
    public ScrollRect scrollRect;
    private RectTransform rectTransform;
    private Coroutine checkCoroutine;

    private int titleCount;

    private float pastPosition;
    private float nowPosition;

    public bool isStop = false;
    private bool isCoroutine = false;
    public bool isScrolling = false;
>>>>>>> origin/Park

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
<<<<<<< HEAD
        titleCount = Park_GameManager.instance.musicInformation["Title"].Count;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (checkCoroutine != null) { StopCoroutine(checkCoroutine); }
            if (moveCoroutine != null) { StopCoroutine(moveCoroutine); }

            isScroll = false;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isScroll = true;
        }

        if (isScroll == true)
        {
            checkCoroutine = StartCoroutine(Check());

            //isScroll = false;
        }

    }

    private IEnumerator Check()
    {
        pastPos = (rectTransform.anchoredPosition.y + titleCount * 360.0f) - 720.0f;

        yield return new WaitForSeconds(1.0f);

        calculatePos = (rectTransform.anchoredPosition.y + titleCount * 360.0f) - 720.0f;

        //Debug.LogFormat("{0},{1}", pastPos, calculatePos);
        Debug.Log(Mathf.Abs(pastPos - calculatePos));
        if (10.0f >= Mathf.Abs(pastPos - calculatePos))
        {
            for (int i = 0; i < titleCount; i++)
            {
                if (i * 720.0f - 360.0f < pastPos && pastPos < i * 720.0f + 360.0f)
                {
                    if (i != currentIndex)
                    {

                        moveCoroutine = StartCoroutine(Move(i));
                    }
                }
=======

        titleCount = Park_GameManager.instance.musicInformation["Title"].Count;
    }

    void Update()
    {
        if (isStop == true)
        {
            if (checkCoroutine != null)
            {
                StopCoroutine(checkCoroutine);
                isCoroutine = false;
                isStop = false;
            }
        }

        if (isScrolling == true)
        {
            if (isCoroutine == false)
            {
                checkCoroutine = StartCoroutine(Check());
>>>>>>> origin/Park
            }
        }
    }

<<<<<<< HEAD
    private IEnumerator Move(int i)
    {
        isCoroutine = true;

        currentIndex = i;

        float timeElapsed = 0.0f;

        while (timeElapsed < duration)
        {
            timeElapsed += Time.deltaTime;

            float time = Mathf.Clamp01(timeElapsed / duration);

            rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x,
                Mathf.Lerp((i * 720.0f) - (titleCount * 360.0f - 720.0f), rectTransform.anchoredPosition.y, time));

            yield return null;
        }
        isCoroutine = false;
    }
=======
    private IEnumerator Check()
    {
        isCoroutine = true;

        pastPosition = (rectTransform.anchoredPosition.y + titleCount * 360.0f) - 720.0f;

        yield return new WaitForSeconds(0.1f);

        nowPosition = (rectTransform.anchoredPosition.y + titleCount * 360.0f) - 720.0f;

        Debug.Log(Mathf.Abs(pastPosition - nowPosition));

        if (Mathf.Abs(pastPosition - nowPosition) <= 10.0f)
        {
            isScrolling = false;

            //scrollRect.inertia = false;
            for (int i = 0; i < titleCount; i++)
            {
                if (i * 720.0f - 360.0f < nowPosition && nowPosition < i * 720.0f + 360.0f)
                {
                    float timeElapsed = 0.0f;

                    while (timeElapsed < 5.0f)
                    {
                        timeElapsed += Time.deltaTime;

                        float time = Mathf.Clamp01(timeElapsed / 5.0f);

                        rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x,
                Mathf.Lerp(rectTransform.anchoredPosition.y, (i * 720.0f) - (titleCount * 360.0f - 720.0f), time));

                        yield return null;
                    }

                    break;

                }
            }
            //scrollRect.inertia = true;

            isCoroutine = false;
        }
        else
        {
            isCoroutine = false;
        }

    }

    //private void Update()
    //{
    //    if (isScrolling)
    //    {
    //        // �ε巯�� �̵� ����
    //        content.anchoredPosition = Vector2.Lerp(content.anchoredPosition, targetPosition, smoothSpeed * Time.deltaTime);

    //        // �̵� �Ϸ� ���� Ȯ��
    //        if (Vector2.Distance(content.anchoredPosition, targetPosition) < snapThreshold)
    //        {
    //            isScrolling = false;  // ��ũ�� �Ϸ�
    //        }
    //    }
    //}

    //// Ư�� ��ġ�� ��ũ�� �̵�
    //public void ScrollToPosition(float normalizedPosition)
    //{
    //    // ����ȭ�� ��ġ�� ���� �̵��� Y ��ǥ ���
    //    float targetY = Mathf.Lerp(0, content.sizeDelta.y - scrollRect.viewport.rect.height, normalizedPosition);

    //    // ��ǥ ��ġ ����
    //    targetPosition = new Vector2(content.anchoredPosition.x, targetY);

    //    // ��ũ�� �� ���·� ����
    //    isScrolling = true;
    //}
>>>>>>> origin/Park
}