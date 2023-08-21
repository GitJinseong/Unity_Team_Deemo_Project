using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Choi_NoteMovement : MonoBehaviour
{
    public Vector3 endCoords = new Vector3(0f, -2f, -6.2f);
    public float moveDuration = 3.0f;

    private Vector3 startCoords = new Vector3(0f, 20f, 30f); // ��Ʈ ���� ��ġ(x�� �ٸ� ������ ������)
    private float startTime;

    private bool isMoving = true; // �̵� ������ ���θ� �Ǵ��ϴ� ����

    private void Start()
    {
        startCoords = transform.position; // ���� ��ġ�� ���� ��ġ�� ����
        endCoords.x = startCoords.x;
        startTime = Time.time;
    }

    private void Update()
    {
        if (isMoving)
        {
            float elapsedTime = Time.time - startTime;
            float t = Mathf.Clamp01(elapsedTime / moveDuration);

            // ������ ��ǥ ���
            Vector3 interpolatedCoords = Vector3.Lerp(startCoords, endCoords, t);

            // ������Ʈ �̵�
            transform.position = interpolatedCoords;

            // �����ϸ� �̵� ����
            if (t >= 1.0f)
            {
                isMoving = false;
            }
        }
    }

    // �ٽ� �̵��� �����ϴ� �Լ�
    public void ResumeMoving()
    {
        isMoving = true;
        startTime = Time.time;
        startCoords = transform.position;
    }

    // �ʱ� ��ġ�� �����ϰ� �ٽ� �̵��� �����ϴ� �Լ�
    public void ResetAndMove()
    {
        startCoords = transform.position; // �ʱ� ��ġ�� �̵��ϱ� ���� startCoords ���� ���� ��ġ�� ������Ʈ
        startCoords.y = 20f;
        startCoords.z = 30f;
        transform.position = startCoords; // �ʱ� ��ġ�� �̵�
        endCoords.x = startCoords.x;
        ResumeMoving(); // �̵� �簳
    }
}