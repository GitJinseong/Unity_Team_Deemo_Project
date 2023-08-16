using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScaleChildren : MonoBehaviour
{
    public float scaleMultiplier = 1.1f; // ũ�� ��ȯ ���� ����

    private Image[] childImages; // �ڽ� �̹��� ������Ʈ �迭
    private TMP_Text[] childTexts; // �ڽ� TMP �ؽ�Ʈ ������Ʈ �迭

    // Start is called before the first frame update
    void Start()
    {
        // �̹����� TMP �ؽ�Ʈ�� ũ�⸦ ��ȯ�ϴ� �Լ��� ȣ���մϴ�.
       // ScaleChildrenComponents();
    }

    // �̹��� ũ�� ��ȯ �Լ�
    private void ScaleImage(Image image)
    {
        Vector3 originalScale = image.rectTransform.localScale;
        Vector3 newScale = originalScale * scaleMultiplier;
        image.rectTransform.localScale = newScale;
    }

    // TMP �ؽ�Ʈ ũ�� ��ȯ �Լ�
    private void ScaleTMPText(TMP_Text text)
    {
        Vector3 originalScale = text.rectTransform.localScale;
        Vector3 newScale = originalScale * scaleMultiplier;
        text.rectTransform.localScale = newScale;
    }

    // �̹����� TMP �ؽ�Ʈ�� ũ�⸦ ��ȯ�ϴ� �Լ�
    public void ScaleChildrenComponents()
    {
        // �̹��� ������Ʈ�� ã�Ƽ� ũ�� ��ȯ�� �����մϴ�.
        childImages = GetComponentsInChildren<Image>();
        foreach (Image image in childImages)
        {
            ScaleImage(image);
        }

        // �̹����� �ڽ� ������Ʈ���� TMP �ؽ�Ʈ ������Ʈ�� ã�Ƽ� ũ�� ��ȯ�� �����մϴ�.
        childTexts = GetComponentsInChildren<TMP_Text>();
        foreach (TMP_Text text in childTexts)
        {
            ScaleTMPText(text);
        }
    }
}
