using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Park_PlaySceneBtn : MonoBehaviour
{
    public Park_MainSceneOpacity park_MainSceneOpacity;

    // ���콺 �����Ͱ� ������Ʈ ���� �ִ��� üũ �ϱ� ���� ����(Camera)
    public Camera mainCamera;

    // ���콺 �����Ͱ� ������Ʈ ���� �ִ��� üũ �ϱ� ���� ����(LayerMask)
    public LayerMask targetLayer;

    // �ε� ���� ����
    public Choi_LoadScene loadScene;

    public Park_PlaySceneBtn resume;
    public Park_PlaySceneBtn retry;
    public Park_PlaySceneBtn songs;
    public Park_PlaySceneBtn home;

    // �̹��� ũ�� ������ ���� ����
    private Vector2 orignalScale;
    private Vector2 pressedScale;
    private Vector2 overScale;

    // �� ������ ���� ����
    public string sceneName;
    public float delay = 0f;

    // ũ�� ������ �ε巴�� �ϱ� ���� ����
    private float durationFirst = 0.2f;
    private float durationSecound = 0.1f;

    private bool isCoroutine = false;

    public bool isResume = false;
    public bool isRetry = false;
    public bool isSongs = false;
    public bool isHome = false;

    // Start is called before the first frame update
    void Start()
    {
        orignalScale = new Vector3(0.4f, 0.4f, 1.0f);
        pressedScale = orignalScale * 0.9f;
        overScale = orignalScale * 1.05f;
    }

    private void OnMouseDown()
    {
        if (isCoroutine = false)
        {
            StartCoroutine(StartOverScale());

            if (isResume == true)
            {

            }
            else if (isRetry == true)
            {
                loadScene.Run(delay, sceneName);

                StartCoroutine(park_MainSceneOpacity.EndOpacity());
            }
            else if (isSongs == true)
            {
                loadScene.Run(delay, sceneName);

                StartCoroutine(park_MainSceneOpacity.EndOpacity());
            }
            else if (isHome == true)
            {
                loadScene.Run(delay, sceneName);

                StartCoroutine(park_MainSceneOpacity.EndOpacity());
            }
            else { /*Null*/}

        }
    }

    //private void OnMouseDown()
    //{
    //    if (isCoroutine == false)
    //    {
    //        // �ڷ�ƾ�� �����ϰ� ���ο� �ڷ�ƾ�� ����
    //        if (startOverScale != null) { StopCoroutine(startOverScale); }
    //        if (startOrignalScale != null) { StopCoroutine(startOrignalScale); }

    //        isPressed = true;
    //    }
    //}

    //private void OnMouseUp()
    //{
    //    if (isPoint == true)
    //    {
    //        startOverScale = StartCoroutine(StartOverScale());

    //        if (isResume == true)
    //        {

    //        }
    //        else if (isRetry == true)
    //        {
    //            loadScene.Run(delay, sceneName);

    //            StartCoroutine(park_MainSceneOpacity.EndOpacity());
    //        }
    //        else if (isSongs == true)
    //        {
    //            loadScene.Run(delay, sceneName);

    //            StartCoroutine(park_MainSceneOpacity.EndOpacity());
    //        }
    //        else if (isHome == true)
    //        {
    //            loadScene.Run(delay, sceneName);

    //            StartCoroutine(park_MainSceneOpacity.EndOpacity());
    //        }
    //        else { /*Null*/}

    //        isPressed = false;
    //    }
    //}

    //private void OnMouseDrag()
    //{
    //    // ���콺 ������ ��ġ�� ī�޶� ��ũ�� ��ǥ�� ��ȯ
    //    Vector3 mousePosition = Input.mousePosition;

    //    // ī�޶� ��ũ�� ��ǥ�� ���̷� ��ȯ
    //    Vector2 rayOrigin = mainCamera.ScreenToWorldPoint(mousePosition);

    //    // ����ĳ��Ʈ�� 2D ������Ʈ���� �浹 �˻�
    //    RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.zero, 0f, targetLayer);

    //    if (hit.collider != null)
    //    {
    //        isPoint = true;
    //    }
    //    else
    //    {
    //        StartCoroutine(StartOverScale());

    //        isPressed = false;
    //        isPoint = false;
    //    }
    //}

    public IEnumerator StartScale()
    {
        isCoroutine = true;

        float timeElapsed = 0.0f;

        while (timeElapsed < durationFirst)
        {
            timeElapsed += Time.deltaTime;

            float time = Mathf.Clamp01(timeElapsed / durationFirst);

            transform.localScale = Vector2.Lerp(new Vector2(0.0f, 0.0f), overScale, time);

            yield return null;
        }

        timeElapsed = 0.0f;

        while (timeElapsed < durationSecound)
        {
            timeElapsed += Time.deltaTime;

            float time = Mathf.Clamp01(timeElapsed / durationSecound);

            transform.localScale = Vector2.Lerp(overScale, orignalScale, time);

            yield return null;
        }

        isCoroutine = false;
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
            transform.localScale = Vector2.Lerp(overScale, new Vector2(0.0f, 0.0f), time);

            yield return null;
        }
    }
}
