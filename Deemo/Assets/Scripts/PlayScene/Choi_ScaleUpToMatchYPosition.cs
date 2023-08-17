using UnityEngine;

public class Choi_ScaleUpToMatchYPosition : MonoBehaviour
{
    public GameObject targetObject; // ���ϴ� ������Ʈ
    public float scaleIncreaseRate = 0.1f; // ������ ���� �ӵ�
    public float targetScaleMultiplier = 2.0f; // ��ǥ ������ ����
    public float moveSpeed = 1.0f; // �̵� �ӵ�

    private Vector3 initialScale; // �ʱ� ������
    private float targetYPosition; // ��ǥ y ��ǥ
    private Vector3 targetScale; // ��ǥ ������
    private float elapsedTime = 0f; // ��� �ð�
    private bool shouldGrow = false; // Ŀ���� ����
    private bool scaleReverted = false; // ������ ���� ����

    private void Start()
    {
        initialScale = transform.localScale;
        transform.localScale = initialScale * 2.5f; // ó�� ������ �� ������ 2.5�� ����
        targetYPosition = targetObject.transform.position.y;
        targetScale = initialScale * targetScaleMultiplier;
    }

    private void Update()
    {
        float screenHeight = Screen.height; // ������� ȭ�� ���� ũ��
        float scaleFactor = screenHeight / 720f; // 720p(1280x720) ȭ�� �������� ������ ����

        // ȭ�� ũ�⿡ ���� �̵� �ӵ��� ������ ���� �ӵ� ����
        float adjustedMoveSpeed = moveSpeed * scaleFactor;
        float adjustedScaleIncreaseRate = scaleIncreaseRate * scaleFactor;

        elapsedTime += Time.deltaTime;

        if (!scaleReverted && elapsedTime >= 0.1f)
        {
            transform.localScale = initialScale; // 0.1�� �Ŀ� ������� ������ ����
            scaleReverted = true;
        }

        if (transform.position.y < targetYPosition)
        {
            float newYPosition = Mathf.Lerp(transform.position.y, targetYPosition, adjustedMoveSpeed * Time.deltaTime);
            transform.position = new Vector3(transform.position.x, newYPosition, transform.position.z);
        }
        else
        {
            shouldGrow = true;
        }

        if (shouldGrow && transform.localScale.magnitude < targetScale.magnitude)
        {
            float scaleIncrement = 1 + (adjustedScaleIncreaseRate * Time.deltaTime);
            transform.localScale *= scaleIncrement;
        }
    }
}
