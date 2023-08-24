using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Park_Active : MonoBehaviour
{
    public GameObject activeObject;

    public GameObject targetObject;

    // ó�� Ŭ���� ���콺 ��ġ
    private Vector2 StartMousePosition;

    // ��ư Ŭ���� Ȯ��
    private bool isPoint = false;

    private float timeElapsed = 0.0f;

    void Start()
    {
        targetObject.SetActive(true);

        timeElapsed = 0.0f;
    }

    private void Update()
    {
        timeElapsed += Time.deltaTime;

        if (StartMousePosition != (Vector2)Input.mousePosition)
        {
            isPoint = false;
        }
    }

    private void OnMouseDown()
    {
        StartMousePosition = Input.mousePosition;

        isPoint = true;
    }

    private void OnMouseUp()
    {
        if (isPoint == true && activeObject.activeSelf == false && 5.0f <= timeElapsed)
        {
            activeObject.SetActive(true);
        }
    }
}
