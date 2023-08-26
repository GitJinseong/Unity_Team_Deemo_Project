using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Choi_NoteMovement : MonoBehaviour
{
    public Vector3 endCoords = new Vector3(0f, -2f, -6.2f);
    public float moveDuration = 4.0f;

    private Vector3 startCoords = new Vector3(0f, 20f, 30f); // ��Ʈ ���� ��ġ(x�� �ٸ� ������ ������)
    private float startTime;

    private bool isMoving = true; // �̵� ������ ���θ� �Ǵ��ϴ� ����
    public float speed;

    private void Start()
    {
        speed = Park_GameManager.instance.speed;
        AdjustMoveDuration();
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

    private void AdjustMoveDuration()
    {
        if (speed == 5.0f)
        {
            moveDuration = 4.0f;
        }
        else if (speed == 1.5f)
        {
            moveDuration = 10.0f;
        }
        else if (speed == 8.5f)
        {
            moveDuration = 1.0f;
        }
        else if (speed > 1.5f && speed < 8.5f)
        {
            // speed�� 1.5���� ũ�� 8.5���� ���� ��
            // speed�� 1.5���� 8.5 ���̿� �ִ� ��쿡 ����Ͽ� moveDuration ���� ����
            float normalizedSpeed = (speed - 1.5f) / 7.0f; // 1.5���� 8.5������ ������ 0���� 1 ������ ������ ����ȭ
            moveDuration = Mathf.Lerp(10.0f, 1.0f, normalizedSpeed); // 1.0���� 10.0 ���̷� �����Ͽ� moveDuration ����
        }
    }

}