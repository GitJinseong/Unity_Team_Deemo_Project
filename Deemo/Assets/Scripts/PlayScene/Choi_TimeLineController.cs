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
        Invoke("StartMoving", 3f); // 3초 후에 StartMoving 함수 호출
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
            // 움직임이 끝났을 때 필요한 처리
            enabled = false; // 이 스크립트를 비활성화하여 업데이트 중지
        }
    }

    private void StartMoving()
    {
        isStarted = true;
        startTime = Time.time;
    }
}
