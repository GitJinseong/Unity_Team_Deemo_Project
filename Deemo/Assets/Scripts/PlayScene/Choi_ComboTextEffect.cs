using TMPro;
using UnityEngine;

public class Choi_ComboTextEffect : MonoBehaviour
{
    public TMP_Text comboText;
    public TMP_Text comboText_Shadow;
    public float originalAlpha = 1.0f;
    public float finalAlpha = 0.0f;
    public float duration = 0.3f;

    private float currentTime = 0f;

    private void OnEnable()
    {
        currentTime = 0f;
    }

    private void Update()
    {
        currentTime += Time.deltaTime;
        float t = Mathf.Clamp01(currentTime / duration);
        float alphaValue = Mathf.Lerp(originalAlpha, finalAlpha, t);

        // �ؽ�Ʈ �� �׸����� ���� ���� ����
        Color comboColor = comboText.color;
        comboColor.a = alphaValue;
        comboText.color = comboColor;

        Color shadowColor = comboText_Shadow.color;
        shadowColor.a = alphaValue;
        comboText_Shadow.color = shadowColor;

        if (currentTime >= duration)
        {
            gameObject.SetActive(false);
        }
    }
}
