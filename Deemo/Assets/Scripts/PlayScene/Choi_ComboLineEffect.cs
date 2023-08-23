
using UnityEngine;

public class Choi_ComboLineEffect : MonoBehaviour
{
    SpriteRenderer sprite;
    public float originalPosX = 0f;
    public float originalAlpha = 1.0f; // 1.0f�� ���� ������, 0.0f�� ���� ����
    public float finalAlpha = 0.0f;
    public float finalPosX = 0f;
    public float duration = 0.3f; // �ִϸ��̼� ���� �ð�

    private float currentTime = 0f; // ���� ��� �ð�
    private RectTransform rectTransform;

    private void OnEnable()
    {
        currentTime = 0f;
    }

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        rectTransform = GetComponent<RectTransform>();
    }

    private void Update()
    {
        // �ð� ��� ������Ʈ
        currentTime += Time.deltaTime;

        // ���� ���� ���
        float t = Mathf.Clamp01(currentTime / duration);

        // ������ ������ �� ���
        float positionValue = Mathf.Lerp(originalPosX, finalPosX, t);

        // ������ ���� �� ���
        float alphaValue = Mathf.Lerp(originalAlpha, finalAlpha, t);

        // ������ �� ���� �� ����
        Vector2 anchoredPosition = rectTransform.anchoredPosition;
        anchoredPosition.x = positionValue;
        rectTransform.anchoredPosition = anchoredPosition;
        Color newColor = sprite.color;
        newColor.a = alphaValue;
        sprite.color = newColor;

        // �ִϸ��̼� ���� üũ
        if (currentTime >= duration)
        {
            // �ִϸ��̼� ���� �� ó�� (��: ������Ʈ ���� ��)
            gameObject.SetActive(false);
        }
    }
}
