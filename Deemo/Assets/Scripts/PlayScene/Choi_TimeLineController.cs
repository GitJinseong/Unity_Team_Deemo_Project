using UnityEngine;

public class Choi_TimeLineController : MonoBehaviour
{
    public RectTransform movingObject;
    public float duration = 30f;
    private float startTime;
    private float startX = 0f;
    private float endX = 1280f;
    private bool isStarted = false;

    private void Start()
    {
        Invoke("StartMoving", 3f); // 3�� �Ŀ� StartMoving �Լ� ȣ��
    }

    private void Update()
    {
        if (!isStarted)
            return;

        float t = (Time.time - startTime) / duration;
        float newX = Mathf.Lerp(startX, endX, t);

        Vector3 newPosition = movingObject.anchoredPosition;
        newPosition.x = newX;
        movingObject.anchoredPosition = newPosition;

        if (t >= 1f)
        {
            // �������� ������ �� �ʿ��� ó��
            enabled = false; // �� ��ũ��Ʈ�� ��Ȱ��ȭ�Ͽ� ������Ʈ ����
        }
    }

    private void StartMoving()
    {
        isStarted = true;
        startTime = Time.time;
    }
}
