using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Park_Setting : MonoBehaviour
{
    public GameObject optionUi;

    // ���� ���� �ڷ�ƾ �����ϱ�
    private Coroutine startOverScale;
    private Coroutine startOrignalScale;

    // ���콺 �����Ͱ� ������Ʈ ���� �ִ��� üũ �ϱ� ���� ����(Camera)
    public Camera mainCamera;

    // ���콺 �����Ͱ� ������Ʈ ���� �ִ��� üũ �ϱ� ���� ����(LayerMask)
    public LayerMask targetLayer;

    // �̹��� ũ�� ������ ���� ����
    private Vector2 orignalScale;
    private Vector2 pressedScale;
    private Vector2 overScale;

    // ó�� Ŭ���� ���콺 ��ġ
    private Vector2 startMousePosition;

    // ���� ���콺 ��ġ
    private Vector2 moveMousePosition;

    // �̹��� ũ�� ��� ������ ���� ����
    public float pressedMult;
    public float overMult;

    // ũ�� ������ �ε巴�� �ϱ� ���� ����
    private float durationFirst = 0.2f;
    private float durationSecound = 0.1f;

    private bool isPressed = false;
    private bool isPoint = false;
    private bool isCheck = false;
    // Start is called before the first frame update
    void Start()
    {
        optionUi.SetActive(false);

        // �̹��� ũ�� ����
        orignalScale = transform.localScale;
        pressedScale = orignalScale * pressedMult;
        overScale = orignalScale * overMult;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPressed == true)
        {
            moveMousePosition = Input.mousePosition;

            transform.localScale = pressedScale;
        }

        if (startMousePosition != (Vector2)Input.mousePosition)
        {
            isPoint = false;
        }
    }

    private void OnMouseDown()
    {
        // �ڷ�ƾ�� �����ϰ� ���ο� �ڷ�ƾ�� ����
        if (startOverScale != null) { StopCoroutine(startOverScale); }
        if (startOrignalScale != null) { StopCoroutine(startOrignalScale); }

        isPoint = true;

        isPressed = true;
    }

    private void OnMouseUp()
    {
        if (isPoint == true)
        {
            if (isCheck == false)
            {
                startOverScale = StartCoroutine(StartOverScale());

                optionUi.SetActive(true);
                optionUi.SetActive(false);
                optionUi.SetActive(true);

                isCheck = true;
            }
            else
            {
                optionUi.SetActive(true);
            }
        }

        isPressed = false;
    }

    private void OnMouseDrag()
    {
        // ���콺 ������ ��ġ�� ī�޶� ��ũ�� ��ǥ�� ��ȯ
        Vector3 mousePosition = Input.mousePosition;

        // ī�޶� ��ũ�� ��ǥ�� ���̷� ��ȯ
        Vector2 rayOrigin = mainCamera.ScreenToWorldPoint(mousePosition);

        // ����ĳ��Ʈ�� 2D ������Ʈ���� �浹 �˻�
        RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.zero, 0f, targetLayer);

        if (hit.collider != null)
        {
            isPoint = true;
        }
        else
        {
            StartCoroutine(StartOverScale());

            isPressed = false;
            isPoint = false;
        }
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
            transform.localScale = Vector2.Lerp(pressedScale, overScale, time);

            yield return null;
        }

        startOrignalScale = StartCoroutine(StartOrignalScale());
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
            transform.localScale = Vector2.Lerp(overScale, orignalScale, time);

            yield return null;
        }
    }
}