
using UnityEngine;

public class Choi_ComboCharmingEffect : MonoBehaviour
{
    SpriteRenderer sprite;
    public float originalScale = 0.8f;
    public float originalAlpha = 1.0f; // 1.0f�� ���� ������, 0.0f�� ���� ����
    public float finalScale = 1.4f;
    public float finalAlpha = 0.0f;
    public float duration = 0.3f; // �ִϸ��̼� ���� �ð�

    private float currentTime = 0f; // ���� ��� �ð�

    private void OnEnable()
    {
        currentTime = 0f;
        transform.localScale = new Vector3(transform.localScale.x, originalScale, 1f);
    }

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        // �ð� ��� ������Ʈ
        currentTime += Time.deltaTime;

        // ���� ���� ���
        float t = Mathf.Clamp01(currentTime / duration);

        // ������ ������ �� ���
        float scaledValue = Mathf.Lerp(originalScale, finalScale, t);

        // ������ ���� �� ���
        float alphaValue = Mathf.Lerp(originalAlpha, finalAlpha, t);

        // ������ & ���� �� ����
        transform.localScale = new Vector3(transform.localScale.x, scaledValue, 1f);
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
